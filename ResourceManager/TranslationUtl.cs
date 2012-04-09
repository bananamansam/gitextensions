﻿using System;
using System.Reflection;
using System.ComponentModel;
using System.Windows.Forms;

namespace ResourceManager.Translation
{
    public static class TranslationUtl
    {

        public static void AddTranslationItemsFromFields(string category, object obj, Translation translation)
        {
            if (obj == null)
                return;

            Action<string, object, PropertyInfo> action = delegate(string item, object itemObj, PropertyInfo propertyInfo)
            {
                var value = (string)propertyInfo.GetValue(itemObj, null);
                if (!string.IsNullOrEmpty(value))
                {
                    translation.AddTranslationItem(category, item, propertyInfo.Name, value);
                }
            };
            ForEachField(obj, action);
        }


        public static void TranslateItemsFromFields(string category, object obj, Translation translation)
        {
            if (obj == null)
                return;

            Action<string, object, PropertyInfo> action = delegate(string item, object itemObj, PropertyInfo propertyInfo)
            {
                string value = translation.TranslateItem(category, item, propertyInfo.Name, null);
                if (value != null)
                    propertyInfo.SetValue(itemObj, value, null);
            };
            ForEachField(obj, action);
        }

        public static void ForEachField(object obj,  Action<string, object, PropertyInfo> action)
        {
            if (obj == null)
                return;
            foreach (FieldInfo fieldInfo in obj.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
            {
                Action<PropertyInfo> paction = delegate(PropertyInfo propertyInfo) 
                {
                    action(fieldInfo.Name, fieldInfo.GetValue(obj), propertyInfo);
                };

                //Skip controls with a name started with "_NO_TRANSLATE_"
                //this is a naming convention, these are not translated
                if (fieldInfo.Name.StartsWith("_NO_TRANSLATE_"))
                    continue;
                if (fieldInfo.FieldType.IsSubclassOf(typeof(Component)))
                {
                    Component c = fieldInfo.GetValue(obj) as Component;

                    Func<PropertyInfo, bool> IsTranslatableItem = delegate(PropertyInfo propertyInfo)
                    {
                        return IsTranslatableItemInComponent(propertyInfo);
                    };         

                    ForEachProperty(c, paction, IsTranslatableItem);
                }
                else if (fieldInfo.FieldType.IsSubclassOf(typeof(DataGridViewColumn)))
                {
                    DataGridViewColumn c = fieldInfo.GetValue(obj) as DataGridViewColumn;

                    Func<PropertyInfo, bool> IsTranslatableItem = delegate(PropertyInfo propertyInfo)
                    {
                        return IsTranslatableItemInDataGridViewColumn(propertyInfo, c);
                    };         

                    ForEachProperty(c, paction, IsTranslatableItem);
                    
                }
            }

        }


        public static void ForEachProperty(object obj, Action<PropertyInfo> action, Func<PropertyInfo, bool> IsTranslatableItem)
        {
            if (obj != null)
                foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic))
                    if (IsTranslatableItem(propertyInfo))
                        action(propertyInfo);
        }

        public static bool IsTranslatableItemInComponent(PropertyInfo propertyInfo)
        {
            if (propertyInfo.PropertyType != typeof(string))
                return false;
            if (propertyInfo.Name.Equals("Caption", StringComparison.CurrentCultureIgnoreCase))
                return true;
            if (propertyInfo.Name.Equals("Text", StringComparison.CurrentCultureIgnoreCase))
                return true;
            if (propertyInfo.Name.Equals("ToolTipText", StringComparison.CurrentCultureIgnoreCase))
                return true;
            if (propertyInfo.Name.Equals("Title", StringComparison.CurrentCultureIgnoreCase))
                return true;
            return false;
        }

        public static bool IsTranslatableItemInDataGridViewColumn(PropertyInfo propertyInfo, DataGridViewColumn viewCol)
        {
            if (propertyInfo.Name.Equals("HeaderText", StringComparison.CurrentCultureIgnoreCase))
            {               
                if (viewCol.Visible)
                    return true;
                else
                    return false;
            }
            return false;
        }


    }
}
