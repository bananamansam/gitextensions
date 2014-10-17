using GitCommands;

namespace GitUI.CommandsDialogs.SettingsDialog.Pages
{
    public partial class StashDialogSettingsPage : SettingsPageWithHeader
    {
        public StashDialogSettingsPage()
        {
            InitializeComponent();
            Text = "Stash dialog";
            Translate();
        }

        protected override void SettingsToPage()
        {
            rbMostRecentStash.Checked = AppSettings.SelectMostRecentStashOnFormLoad;
        }

        protected override void PageToSettings()
        {
            AppSettings.SelectMostRecentStashOnFormLoad = rbMostRecentStash.Checked;
        }
    }
}
