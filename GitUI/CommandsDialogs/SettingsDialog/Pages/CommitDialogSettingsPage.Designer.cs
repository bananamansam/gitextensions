namespace GitUI.CommandsDialogs.SettingsDialog.Pages
{
    partial class CommitDialogSettingsPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxBehaviour = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelBehaviour = new System.Windows.Forms.TableLayoutPanel();
            this.cbRememberAmendCommitState = new System.Windows.Forms.CheckBox();
            this.chkAutocomplete = new System.Windows.Forms.CheckBox();
            this._NO_TRANSLATE_CommitDialogNumberOfPreviousMessages = new System.Windows.Forms.NumericUpDown();
            this.lblCommitDialogNumberOfPreviousMessages = new System.Windows.Forms.Label();
            this.chkShowErrorsWhenStagingFiles = new System.Windows.Forms.CheckBox();
            this.chkWriteCommitMessageInCommitWindow = new System.Windows.Forms.CheckBox();
            this.grpAdditionalButtons = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.chkShowCommitAndPush = new System.Windows.Forms.CheckBox();
            this.chkShowResetUnstagedChanges = new System.Windows.Forms.CheckBox();
            this.chkShowResetAllChanges = new System.Windows.Forms.CheckBox();
            this.tblPullOptions = new System.Windows.Forms.TableLayoutPanel();
            this.grpDefaultPullAction = new System.Windows.Forms.GroupBox();
            this.rbRebase = new System.Windows.Forms.RadioButton();
            this.rbMerge = new System.Windows.Forms.RadioButton();
            this.chkPull = new System.Windows.Forms.CheckBox();
            this.chkAddNewlineToCommitMessageWhenMissing = new System.Windows.Forms.CheckBox();
            this.chkCurrentUserPreviousCommitMessages = new System.Windows.Forms.CheckBox();
            this.groupBoxBehaviour.SuspendLayout();
            this.tableLayoutPanelBehaviour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._NO_TRANSLATE_CommitDialogNumberOfPreviousMessages)).BeginInit();
            this.grpAdditionalButtons.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tblPullOptions.SuspendLayout();
            this.grpDefaultPullAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxBehaviour
            // 
            this.groupBoxBehaviour.AutoSize = true;
            this.groupBoxBehaviour.Controls.Add(this.tableLayoutPanelBehaviour);
            this.groupBoxBehaviour.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxBehaviour.Location = new System.Drawing.Point(0, 0);
            this.groupBoxBehaviour.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxBehaviour.Name = "groupBoxBehaviour";
            this.groupBoxBehaviour.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxBehaviour.Size = new System.Drawing.Size(2319, 415);
            this.groupBoxBehaviour.TabIndex = 56;
            this.groupBoxBehaviour.TabStop = false;
            this.groupBoxBehaviour.Text = "Behaviour";
            // 
            // tableLayoutPanelBehaviour
            // 
            this.tableLayoutPanelBehaviour.AutoSize = true;
            this.tableLayoutPanelBehaviour.ColumnCount = 2;
            this.tableLayoutPanelBehaviour.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBehaviour.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBehaviour.Controls.Add(this.cbRememberAmendCommitState, 0, 6);
            this.tableLayoutPanelBehaviour.Controls.Add(this.chkAutocomplete, 0, 0);
            this.tableLayoutPanelBehaviour.Controls.Add(this._NO_TRANSLATE_CommitDialogNumberOfPreviousMessages, 1, 4);
            this.tableLayoutPanelBehaviour.Controls.Add(this.lblCommitDialogNumberOfPreviousMessages, 0, 4);
            this.tableLayoutPanelBehaviour.Controls.Add(this.chkShowErrorsWhenStagingFiles, 0, 1);
            this.tableLayoutPanelBehaviour.Controls.Add(this.chkWriteCommitMessageInCommitWindow, 0, 3);
            this.tableLayoutPanelBehaviour.Controls.Add(this.grpAdditionalButtons, 0, 7);
            this.tableLayoutPanelBehaviour.Controls.Add(this.chkAddNewlineToCommitMessageWhenMissing, 0, 2);
            this.tableLayoutPanelBehaviour.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelBehaviour.Location = new System.Drawing.Point(4, 20);
            this.tableLayoutPanelBehaviour.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanelBehaviour.Name = "tableLayoutPanelBehaviour";
            this.tableLayoutPanelBehaviour.RowCount = 8;
            this.tableLayoutPanelBehaviour.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBehaviour.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBehaviour.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBehaviour.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBehaviour.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBehaviour.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBehaviour.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBehaviour.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBehaviour.Size = new System.Drawing.Size(2311, 391);
            this.tableLayoutPanelBehaviour.TabIndex = 57;
            // 
            // cbRememberAmendCommitState
            // 
            this.cbRememberAmendCommitState.AutoSize = true;
            this.cbRememberAmendCommitState.Location = new System.Drawing.Point(4, 168);
            this.cbRememberAmendCommitState.Margin = new System.Windows.Forms.Padding(4);
            this.cbRememberAmendCommitState.Name = "cbRememberAmendCommitState";
            this.cbRememberAmendCommitState.Size = new System.Drawing.Size(401, 21);
            this.cbRememberAmendCommitState.TabIndex = 5;
            this.cbRememberAmendCommitState.Text = "Remember \'Amend commit\' checkbox on commit form close";
            this.cbRememberAmendCommitState.UseVisualStyleBackColor = true;
            // 
            // chkAutocomplete
            // 
            this.chkAutocomplete.AutoSize = true;
            this.chkAutocomplete.Location = new System.Drawing.Point(4, 4);
            this.chkAutocomplete.Margin = new System.Windows.Forms.Padding(4);
            this.chkAutocomplete.Name = "chkAutocomplete";
            this.chkAutocomplete.Size = new System.Drawing.Size(283, 21);
            this.chkAutocomplete.TabIndex = 0;
            this.chkAutocomplete.Text = "Provide auto-completion in commit dialog";
            this.chkAutocomplete.UseVisualStyleBackColor = true;
            // 
            // _NO_TRANSLATE_CommitDialogNumberOfPreviousMessages
            // 
            this._NO_TRANSLATE_CommitDialogNumberOfPreviousMessages.Location = new System.Drawing.Point(413, 137);
            this._NO_TRANSLATE_CommitDialogNumberOfPreviousMessages.Margin = new System.Windows.Forms.Padding(4);
            this._NO_TRANSLATE_CommitDialogNumberOfPreviousMessages.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this._NO_TRANSLATE_CommitDialogNumberOfPreviousMessages.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._NO_TRANSLATE_CommitDialogNumberOfPreviousMessages.Name = "_NO_TRANSLATE_CommitDialogNumberOfPreviousMessages";
            this._NO_TRANSLATE_CommitDialogNumberOfPreviousMessages.Size = new System.Drawing.Size(154, 23);
            this._NO_TRANSLATE_CommitDialogNumberOfPreviousMessages.TabIndex = 4;
            this._NO_TRANSLATE_CommitDialogNumberOfPreviousMessages.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCommitDialogNumberOfPreviousMessages
            // 
            this.lblCommitDialogNumberOfPreviousMessages.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCommitDialogNumberOfPreviousMessages.AutoSize = true;
            this.lblCommitDialogNumberOfPreviousMessages.Location = new System.Drawing.Point(4, 140);
            this.lblCommitDialogNumberOfPreviousMessages.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCommitDialogNumberOfPreviousMessages.Name = "lblCommitDialogNumberOfPreviousMessages";
            this.lblCommitDialogNumberOfPreviousMessages.Size = new System.Drawing.Size(295, 17);
            this.lblCommitDialogNumberOfPreviousMessages.TabIndex = 2;
            this.lblCommitDialogNumberOfPreviousMessages.Text = "Number of previous messages in commit dialog";
            // 
            // chkShowErrorsWhenStagingFiles
            // 
            this.chkShowErrorsWhenStagingFiles.AutoSize = true;
            this.chkShowErrorsWhenStagingFiles.Location = new System.Drawing.Point(4, 33);
            this.chkShowErrorsWhenStagingFiles.Margin = new System.Windows.Forms.Padding(4);
            this.chkShowErrorsWhenStagingFiles.Name = "chkShowErrorsWhenStagingFiles";
            this.chkShowErrorsWhenStagingFiles.Size = new System.Drawing.Size(214, 21);
            this.chkShowErrorsWhenStagingFiles.TabIndex = 1;
            this.chkShowErrorsWhenStagingFiles.Text = "Show errors when staging files";
            this.chkShowErrorsWhenStagingFiles.UseVisualStyleBackColor = true;
            // 
            // chkWriteCommitMessageInCommitWindow
            // 
            this.chkWriteCommitMessageInCommitWindow.AutoSize = true;
            this.chkWriteCommitMessageInCommitWindow.Location = new System.Drawing.Point(4, 91);
            this.chkWriteCommitMessageInCommitWindow.Margin = new System.Windows.Forms.Padding(4);
            this.chkWriteCommitMessageInCommitWindow.Name = "chkWriteCommitMessageInCommitWindow";
            this.chkWriteCommitMessageInCommitWindow.Size = new System.Drawing.Size(376, 38);
            this.chkWriteCommitMessageInCommitWindow.TabIndex = 3;
            this.chkWriteCommitMessageInCommitWindow.Text = "Compose commit messages in Commit dialog\r\n(otherwise the message will be requeste" +
    "d during commit)";
            this.chkWriteCommitMessageInCommitWindow.UseVisualStyleBackColor = true;
            // 
            // grpAdditionalButtons
            // 
            this.grpAdditionalButtons.AutoSize = true;
            this.grpAdditionalButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelBehaviour.SetColumnSpan(this.grpAdditionalButtons, 2);
            this.grpAdditionalButtons.Controls.Add(this.flowLayoutPanel1);
            this.grpAdditionalButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAdditionalButtons.Location = new System.Drawing.Point(4, 197);
            this.grpAdditionalButtons.Margin = new System.Windows.Forms.Padding(4);
            this.grpAdditionalButtons.Name = "grpAdditionalButtons";
            this.grpAdditionalButtons.Padding = new System.Windows.Forms.Padding(4);
            this.grpAdditionalButtons.Size = new System.Drawing.Size(2303, 190);
            this.grpAdditionalButtons.TabIndex = 6;
            this.grpAdditionalButtons.TabStop = false;
            this.grpAdditionalButtons.Text = "Show additional buttons in commit button area";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.chkShowCommitAndPush);
            this.flowLayoutPanel1.Controls.Add(this.chkShowResetUnstagedChanges);
            this.flowLayoutPanel1.Controls.Add(this.chkShowResetAllChanges);
            this.flowLayoutPanel1.Controls.Add(this.tblPullOptions);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 20);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(2295, 166);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // chkShowCommitAndPush
            // 
            this.chkShowCommitAndPush.AutoSize = true;
            this.chkShowCommitAndPush.Location = new System.Drawing.Point(4, 4);
            this.chkShowCommitAndPush.Margin = new System.Windows.Forms.Padding(4);
            this.chkShowCommitAndPush.Name = "chkShowCommitAndPush";
            this.chkShowCommitAndPush.Size = new System.Drawing.Size(125, 21);
            this.chkShowCommitAndPush.TabIndex = 0;
            this.chkShowCommitAndPush.Text = "Commit && Push";
            this.chkShowCommitAndPush.UseVisualStyleBackColor = true;
            // 
            // chkShowResetUnstagedChanges
            // 
            this.chkShowResetUnstagedChanges.AutoSize = true;
            this.chkShowResetUnstagedChanges.Location = new System.Drawing.Point(4, 33);
            this.chkShowResetUnstagedChanges.Margin = new System.Windows.Forms.Padding(4);
            this.chkShowResetUnstagedChanges.Name = "chkShowResetUnstagedChanges";
            this.chkShowResetUnstagedChanges.Size = new System.Drawing.Size(183, 21);
            this.chkShowResetUnstagedChanges.TabIndex = 1;
            this.chkShowResetUnstagedChanges.Text = "Reset Unstaged Changes";
            this.chkShowResetUnstagedChanges.UseVisualStyleBackColor = true;
            // 
            // chkShowResetAllChanges
            // 
            this.chkShowResetAllChanges.AutoSize = true;
            this.chkShowResetAllChanges.Location = new System.Drawing.Point(4, 62);
            this.chkShowResetAllChanges.Margin = new System.Windows.Forms.Padding(4);
            this.chkShowResetAllChanges.Name = "chkShowResetAllChanges";
            this.chkShowResetAllChanges.Size = new System.Drawing.Size(137, 21);
            this.chkShowResetAllChanges.TabIndex = 2;
            this.chkShowResetAllChanges.Text = "Reset All Changes";
            this.chkShowResetAllChanges.UseVisualStyleBackColor = true;
            // 
            // tblPullOptions
            // 
            this.tblPullOptions.AutoSize = true;
            this.tblPullOptions.ColumnCount = 2;
            this.tblPullOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblPullOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblPullOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblPullOptions.Controls.Add(this.grpDefaultPullAction, 1, 0);
            this.tblPullOptions.Controls.Add(this.chkPull, 0, 0);
            this.tblPullOptions.Location = new System.Drawing.Point(4, 91);
            this.tblPullOptions.Margin = new System.Windows.Forms.Padding(4);
            this.tblPullOptions.Name = "tblPullOptions";
            this.tblPullOptions.RowCount = 1;
            this.tblPullOptions.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblPullOptions.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblPullOptions.Size = new System.Drawing.Size(220, 71);
            this.tblPullOptions.TabIndex = 4;
            // 
            // grpDefaultPullAction
            // 
            this.grpDefaultPullAction.AutoSize = true;
            this.grpDefaultPullAction.Controls.Add(this.rbRebase);
            this.grpDefaultPullAction.Controls.Add(this.rbMerge);
            this.grpDefaultPullAction.Enabled = false;
            this.grpDefaultPullAction.Location = new System.Drawing.Point(59, 3);
            this.grpDefaultPullAction.Name = "grpDefaultPullAction";
            this.grpDefaultPullAction.Size = new System.Drawing.Size(158, 65);
            this.grpDefaultPullAction.TabIndex = 5;
            this.grpDefaultPullAction.TabStop = false;
            this.grpDefaultPullAction.Text = "Pull Action";
            // 
            // rbRebase
            // 
            this.rbRebase.AutoSize = true;
            this.rbRebase.Location = new System.Drawing.Point(79, 22);
            this.rbRebase.Name = "rbRebase";
            this.rbRebase.Size = new System.Drawing.Size(73, 21);
            this.rbRebase.TabIndex = 4;
            this.rbRebase.TabStop = true;
            this.rbRebase.Text = "Rebase";
            this.rbRebase.UseVisualStyleBackColor = true;
            // 
            // rbMerge
            // 
            this.rbMerge.AutoSize = true;
            this.rbMerge.Location = new System.Drawing.Point(14, 22);
            this.rbMerge.Name = "rbMerge";
            this.rbMerge.Size = new System.Drawing.Size(66, 21);
            this.rbMerge.TabIndex = 5;
            this.rbMerge.TabStop = true;
            this.rbMerge.Text = "Merge";
            this.rbMerge.UseVisualStyleBackColor = true;
            // 
            // chkPull
            // 
            this.chkPull.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.chkPull.AutoSize = true;
            this.chkPull.Location = new System.Drawing.Point(3, 3);
            this.chkPull.Name = "chkPull";
            this.chkPull.Size = new System.Drawing.Size(50, 65);
            this.chkPull.TabIndex = 3;
            this.chkPull.Text = "Pull";
            this.chkPull.UseVisualStyleBackColor = true;
            this.chkPull.CheckedChanged += new System.EventHandler(this.chkPull_CheckedChanged);
            // 
            // chkAddNewlineToCommitMessageWhenMissing
            // 
            this.chkAddNewlineToCommitMessageWhenMissing.AutoSize = true;
            this.chkAddNewlineToCommitMessageWhenMissing.Location = new System.Drawing.Point(4, 62);
            this.chkAddNewlineToCommitMessageWhenMissing.Margin = new System.Windows.Forms.Padding(4);
            this.chkAddNewlineToCommitMessageWhenMissing.Name = "chkAddNewlineToCommitMessageWhenMissing";
            this.chkAddNewlineToCommitMessageWhenMissing.Size = new System.Drawing.Size(346, 21);
            this.chkAddNewlineToCommitMessageWhenMissing.TabIndex = 2;
            this.chkAddNewlineToCommitMessageWhenMissing.Text = "Ensure the second line of commit message is empty";
            this.chkAddNewlineToCommitMessageWhenMissing.UseVisualStyleBackColor = true;
            // 
            // chkCurrentUserPreviousCommitMessages
            // 
            this.chkCurrentUserPreviousCommitMessages.AutoSize = true;
            this.chkCurrentUserPreviousCommitMessages.Location = new System.Drawing.Point(3, 68);
            this.chkCurrentUserPreviousCommitMessages.Name = "chkCurrentUserPreviousCommitMessages";
            this.chkCurrentUserPreviousCommitMessages.Size = new System.Drawing.Size(288, 19);
            this.chkCurrentUserPreviousCommitMessages.TabIndex = 6;
            this.chkCurrentUserPreviousCommitMessages.Text = "Only show previous messages for the current user";
            this.chkCurrentUserPreviousCommitMessages.UseVisualStyleBackColor = true;
            // 
            // CommitDialogSettingsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.Controls.Add(this.groupBoxBehaviour);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CommitDialogSettingsPage";
            this.Size = new System.Drawing.Size(2319, 785);
            this.groupBoxBehaviour.ResumeLayout(false);
            this.groupBoxBehaviour.PerformLayout();
            this.tableLayoutPanelBehaviour.ResumeLayout(false);
            this.tableLayoutPanelBehaviour.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._NO_TRANSLATE_CommitDialogNumberOfPreviousMessages)).EndInit();
            this.grpAdditionalButtons.ResumeLayout(false);
            this.grpAdditionalButtons.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tblPullOptions.ResumeLayout(false);
            this.tblPullOptions.PerformLayout();
            this.grpDefaultPullAction.ResumeLayout(false);
            this.grpDefaultPullAction.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxBehaviour;
        private System.Windows.Forms.CheckBox chkWriteCommitMessageInCommitWindow;
        private System.Windows.Forms.CheckBox chkShowErrorsWhenStagingFiles;
        private System.Windows.Forms.Label lblCommitDialogNumberOfPreviousMessages;
        private System.Windows.Forms.NumericUpDown _NO_TRANSLATE_CommitDialogNumberOfPreviousMessages;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBehaviour;
        private System.Windows.Forms.GroupBox grpAdditionalButtons;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox chkShowCommitAndPush;
        private System.Windows.Forms.CheckBox chkShowResetUnstagedChanges;
        private System.Windows.Forms.CheckBox chkShowResetAllChanges;
        private System.Windows.Forms.CheckBox chkAddNewlineToCommitMessageWhenMissing;
        private System.Windows.Forms.CheckBox chkAutocomplete;
        private System.Windows.Forms.CheckBox cbRememberAmendCommitState;
        private System.Windows.Forms.CheckBox chkCurrentUserPreviousCommitMessages;
        private System.Windows.Forms.TableLayoutPanel tblPullOptions;
        private System.Windows.Forms.CheckBox chkPull;
        private System.Windows.Forms.RadioButton rbMerge;
        private System.Windows.Forms.RadioButton rbRebase;
        private System.Windows.Forms.GroupBox grpDefaultPullAction;
    }
}
