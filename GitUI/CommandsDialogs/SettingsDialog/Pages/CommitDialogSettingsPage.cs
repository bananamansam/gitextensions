using GitCommands;

namespace GitUI.CommandsDialogs.SettingsDialog.Pages
{
    public partial class CommitDialogSettingsPage : SettingsPageWithHeader
    {
        public CommitDialogSettingsPage()
        {
            InitializeComponent();
            Text = "Commit dialog";
            Translate();
            
        }

        protected override void SettingsToPage()
        {
            chkShowErrorsWhenStagingFiles.Checked = AppSettings.ShowErrorsWhenStagingFiles;
            chkAddNewlineToCommitMessageWhenMissing.Checked = AppSettings.AddNewlineToCommitMessageWhenMissing;
            chkWriteCommitMessageInCommitWindow.Checked = AppSettings.UseFormCommitMessage;
            _NO_TRANSLATE_CommitDialogNumberOfPreviousMessages.Value = AppSettings.CommitDialogNumberOfPreviousMessages;
            chkShowCommitAndPush.Checked = AppSettings.ShowCommitAndPush;
            chkShowResetUnstagedChanges.Checked = AppSettings.ShowResetUnstagedChanges;
            chkShowResetAllChanges.Checked = AppSettings.ShowResetAllChanges;
            chkAutocomplete.Checked = AppSettings.ProvideAutocompletion;
            cbRememberAmendCommitState.Checked = AppSettings.RememberAmendCommitState;
            chkCurrentUserPreviousCommitMessages.Checked = AppSettings.CommitMessagesFilteredByAuthor;
            chkPull.Checked = AppSettings.CommitDialogShowPullButton;
            rbMerge.Checked = AppSettings.CommitDialogPullAction == AppSettings.PullAction.Merge;
            rbRebase.Checked = AppSettings.CommitDialogPullAction == AppSettings.PullAction.Rebase;
        }

        protected override void PageToSettings()
        {
            AppSettings.ShowErrorsWhenStagingFiles = chkShowErrorsWhenStagingFiles.Checked;
            AppSettings.AddNewlineToCommitMessageWhenMissing = chkAddNewlineToCommitMessageWhenMissing.Checked;
            AppSettings.UseFormCommitMessage = chkWriteCommitMessageInCommitWindow.Checked;
            AppSettings.CommitDialogNumberOfPreviousMessages = (int) _NO_TRANSLATE_CommitDialogNumberOfPreviousMessages.Value;
            AppSettings.ShowCommitAndPush = chkShowCommitAndPush.Checked;
            AppSettings.ShowResetUnstagedChanges = chkShowResetUnstagedChanges.Checked;
            AppSettings.ShowResetAllChanges = chkShowResetAllChanges.Checked;
            AppSettings.ProvideAutocompletion = chkAutocomplete.Checked;
            AppSettings.RememberAmendCommitState = cbRememberAmendCommitState.Checked;
            AppSettings.CommitMessagesFilteredByAuthor = chkCurrentUserPreviousCommitMessages.Checked;
            AppSettings.CommitDialogShowPullButton = chkPull.Checked;
            AppSettings.CommitDialogPullAction = rbMerge.Checked ? GitCommands.AppSettings.PullAction.Merge : AppSettings.PullAction.Rebase;
        }

        private void chkPull_CheckedChanged(object sender, System.EventArgs e)
        {
            grpDefaultPullAction.Enabled = chkPull.Checked;
        }
    }
}
