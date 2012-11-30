﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GitCommands;

namespace GitUI.SettingsDialog
{
    /// <summary>
    /// set Text property in derived classes to set the title
    /// </summary>
    public class SettingsPageBase : UserControl
    {
        /// <summary>
        /// called when SettingsPage is shown (again)
        /// 
        /// TODO: call
        /// </summary>
        public virtual void RefreshView()
        {
            // to be overridden
        }

        // TODO: is this needed here or globally for all settings?
        protected bool loadingSettings;

        public void LoadSettings()
        {
            loadingSettings = true;
            OnLoadSettings();
            loadingSettings = false;
        }

        ////public void SaveSettings()
        ////{
        ////    OnSaveSettings();
        ////}

        /// <summary>
        /// use GitCommands.Settings to load settings
        /// 
        /// TODO: call
        /// </summary>
        /// <param name="settings"></param>
        protected virtual void OnLoadSettings()
        {
            // to be overridden
        }

        /// <summary>
        /// use GitCommands.Settings to save settings
        /// 
        /// TODO: call
        /// </summary>
        /// <param name="settings"></param>
        public virtual void SaveSettings()
        {
            // to be overridden
        }

        /// <summary>
        /// override to provide search keywords
        /// </summary>
        public virtual IEnumerable<string> GetSearchKeywords()
        {
            return new List<string>();
        }
    }
}
