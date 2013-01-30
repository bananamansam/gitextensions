﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ResourceManager.Translation;
using System.Diagnostics;

namespace TranslationApp
{
    static class TranslationHelpers
    {
        public static void SaveTranslation(string languageCode, IEnumerable<TranslationItemWithCategory> items, string filename)
        {
            Translation foreignTranslation = new Translation { GitExVersion = GitCommands.Settings.GitExtensionsVersionString, LanguageCode = languageCode };
            foreach (TranslationItemWithCategory translateItem in items)
            {
                if (translateItem.Status == TranslationType.Obsolete &&
                    (String.IsNullOrEmpty(translateItem.TranslatedValue) || String.IsNullOrEmpty(translateItem.NeutralValue)))
                    continue;

                TranslationItem ti = translateItem.GetTranslationItem().Clone();
                if (ti.Status == TranslationType.New)
                    ti.Status = TranslationType.Unfinished;
                Debug.Assert(!string.IsNullOrEmpty(ti.Value) || ti.Status != TranslationType.Translated);
                ti.Value = ti.Value ?? String.Empty;
                Debug.Assert(ti.Status != TranslationType.Translated || translateItem.IsSourceEqual(ti.Source));
                ti.Source = translateItem.OldNeutralValue;
                foreignTranslation.FindOrAddTranslationCategory(translateItem.Category).AddTranslationItem(ti);
            }
            TranslationSerializer.Serialize(foreignTranslation, filename);
        }

        public static IList<TranslationItemWithCategory> LoadNeutralItems()
        {
            string language = GitCommands.Settings.Translation;

            Translation neutralTranslation = new Translation();
            try
            {
                //Set language to neutral to get neutral translations
                GitCommands.Settings.Translation = "";

                List<Type> translatableTypes = TranslationUtl.GetTranslatableTypes();
                foreach (Type type in translatableTypes)
                {
                    ITranslate obj = TranslationUtl.CreateInstanceOfClass(type) as ITranslate;
                    if (obj != null)
                        obj.AddTranslationItems(neutralTranslation);
                }
            }
            finally
            {
                neutralTranslation.Sort();

                //Restore translation
                GitCommands.Settings.Translation = language;
            }

            IList<TranslationItemWithCategory> neutralItems =
                (from translationCategory in neutralTranslation.GetTranslationCategories()
                 from translationItem in translationCategory.GetTranslationItems()
                 select new TranslationItemWithCategory(translationCategory.Name, translationItem)).ToList();
            return neutralItems;
        }

        public static List<TranslationItemWithCategory> LoadTranslation(Translation translation, IEnumerable<TranslationItemWithCategory> neutralItems)
        {
            List<TranslationItemWithCategory> translateItems = new List<TranslationItemWithCategory>();

            var oldTranslationItems =
                (from translationCategory in translation.GetTranslationCategories()
                 from translationItem in translationCategory.GetTranslationItems()
                 select new TranslationItemWithCategory(translationCategory.Name, translationItem)).ToList();

            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (var item in neutralItems)
            {
                var curItem =
                    (from trItem in oldTranslationItems
                     where trItem.Category.TrimStart('_') == item.Category.TrimStart('_') &&
                     trItem.Name.TrimStart('_') == item.Name.TrimStart('_') &&
                     trItem.Property == item.Property
                     select trItem).FirstOrDefault();

                if (curItem == null)
                {
                    curItem = item.Clone();
                    translateItems.Add(curItem);
                    continue;
                }

                oldTranslationItems.Remove(curItem);
                curItem.Category = item.Category;
                curItem.Name = item.Name;
                if (curItem.Status == TranslationType.Translated)
                {
                    string source = curItem.OldNeutralValue ?? item.NeutralValue;
                    if (!String.IsNullOrEmpty(curItem.TranslatedValue) && !dict.ContainsKey(source))
                        dict.Add(source, curItem.TranslatedValue);
                }
                if (curItem.Status == TranslationType.Translated && !curItem.IsSourceEqual(item.NeutralValue) ||
                    curItem.Status == TranslationType.Obsolete)
                    curItem.Status = TranslationType.Unfinished;
                curItem.NeutralValue = item.NeutralValue;
                translateItems.Add(curItem);
            }

            foreach (var item in oldTranslationItems)
            {
                if (String.IsNullOrEmpty(item.TranslatedValue))
                    continue;

                if ((item.Status == TranslationType.Translated || item.Status == TranslationType.Obsolete) && 
                    item.NeutralValue != null && !dict.ContainsKey(item.NeutralValue))
                    dict.Add(item.NeutralValue, item.TranslatedValue);

                item.Status = TranslationType.Obsolete;
                translateItems.Add(item);
            }

            // update untranslated items
            var untranlatedItems = from trItem in translateItems
                                   where trItem.Status == TranslationType.New &&
                                   dict.ContainsKey(trItem.NeutralValue)
                                   select trItem;

            foreach (var untranlatedItem in untranlatedItems)
            {
                untranlatedItem.Status = TranslationType.Unfinished;
                untranlatedItem.TranslatedValue = dict[untranlatedItem.NeutralValue];
            }
            return translateItems;
        }
    }
}
