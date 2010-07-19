﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using GitCommands;
using System.IO;
using System.Collections;
using System.Collections.Specialized;
using ResourceManager.Translation;

namespace GitUI
{
    public partial class FormCommit : GitExtensionsForm
    {
        TranslationString closeDialogAfterCommitTooltip = new TranslationString("When checked the commit dialog is closed after each commit.\nOtherwise the dialog will only close when there are no modified files left.");
        TranslationString noUnstagedChanges = new TranslationString("There are no unstaged changes");
        TranslationString noStagedChanges = new TranslationString("There are no staged changes");
        TranslationString enterCommitMessageHint = new TranslationString("Enter commit message");
        TranslationString noFilesStaged = new TranslationString("There are no files staged for this commit. Are you sure you want to commit?");
        TranslationString mergeConflicts = new TranslationString("There are unresolved mergeconflicts, solve mergeconflicts before committing.");
        TranslationString mergeConflictsCaption = new TranslationString("Merge conflicts");
        TranslationString enterCommitMessage = new TranslationString("Please enter commit message");
        TranslationString enterCommitMessageCaption = new TranslationString("Commit message");
        TranslationString notOnBranch = new TranslationString("You are not working on a branch." + Environment.NewLine + "This commit will be unreferenced when switching to another brach and can be lost." + Environment.NewLine + "" + Environment.NewLine + "Do you want to continue?");
        TranslationString notOnBranchCaption = new TranslationString("Not on a branch.");
        TranslationString amendCommit = new TranslationString("You are about to rewrite history." + Environment.NewLine + "Only use amend if the commit is not published yet!" + Environment.NewLine + Environment.NewLine + "Do you want to continue?");
        TranslationString amendCommitCaption = new TranslationString("Amend commit");
        TranslationString resetChanges = new TranslationString("Are you sure you want to reset the changes of the selected files?");
        TranslationString resetChangesCaption = new TranslationString("Reset changes");
        TranslationString alsoDeleteUntrackedFiles = new TranslationString("Do you also want to delete the new files that are in the selection?" + Environment.NewLine + Environment.NewLine + "Choose 'No' to keep all new files.");
        TranslationString alsoDeleteUntrackedFilesCaption = new TranslationString("Delete");
        TranslationString deleteSelectedFiles = new TranslationString("Are you sure you want delete the selected file(s)?");
        TranslationString deleteSelectedFilesCaption = new TranslationString("Delete");
        TranslationString deleteFailed = new TranslationString("Delete file failed");
        TranslationString resetSelectedChanges = new TranslationString("Are you sure you want to reset all selected files?");
        TranslationString deleteUntrackedFiles = new TranslationString("Are you sure you want to delete all untracked files?");
        TranslationString deleteUntrackedFilesCaption = new TranslationString("Delete untracked files.");
        TranslationString onlyStageChunkOfSingleFileError = new TranslationString("You can only use this option when selecting a single file");
        TranslationString stageChunkOfFileCaption = new TranslationString("Stage chunk of file");
        TranslationString resetStageChunkOfFileCaption = new TranslationString("Unstage chunk of file");
        TranslationString stageDetails = new TranslationString("Stage Details");
        TranslationString stageFiles = new TranslationString("Stage {0} files");

        private readonly SynchronizationContext syncContext;

        public FormCommit()
        {
            syncContext = SynchronizationContext.Current;

            InitializeComponent(); Translate();
            SelectedDiff.ExtraDiffArgumentsChanged += new EventHandler<EventArgs>(SelectedDiff_ExtraDiffArgumentsChanged);

            CloseCommitDialogTooltip.SetToolTip(CloseDialogAfterCommit, closeDialogAfterCommitTooltip.Text);

            CloseDialogAfterCommit.Checked = Settings.CloseCommitDialogAfterCommit;

            Unstaged.SetNoFilesText(noUnstagedChanges.Text);
            Staged.SetNoFilesText(noStagedChanges.Text);
            Message.SetEmptyMessage(enterCommitMessageHint.Text);

            Unstaged.SelectedIndexChanged += new EventHandler(Untracked_SelectionChanged);
            Staged.SelectedIndexChanged += new EventHandler(Tracked_SelectionChanged);
        }


        ~FormCommit()  // destructor
        {
            gitGetUnstagedCommand.Kill();
        }

        private void FormCommit_Load(object sender, EventArgs e)
        {
            RestorePosition("commit");
        }

        GitCommands.GitCommands gitGetUnstagedCommand = new GitCommands.GitCommands();

        private bool IsLoadingUnstagedFiles()
        {
            if (gitGetUnstagedCommand.Process == null)
                return false;

            return !gitGetUnstagedCommand.Process.HasExited;
        }

        private void Initialize()
        {
            UnstageFiles.Enabled = false;
            AddFiles.Enabled = false;
            filesListedToCommitToolStripMenuItem.Enabled = false;
            workingToolStripMenuItem.Enabled = false;

            Cursor.Current = Cursors.WaitCursor;

            //Load unstaged files
            gitGetUnstagedCommand.Exited += new EventHandler(gitCommands_Exited);
            gitGetUnstagedCommand.CmdStartProcess(Settings.GitCommand, GitCommands.GitCommands.GetAllChangedFilesCmd(!showIgnoredFilesToolStripMenuItem.Checked, showUntrackedFilesToolStripMenuItem.Checked));
            Loading.Visible = true;
            AddFiles.Enabled = false;

            InitializedStagedAsync();

            Commit.Focus();
            AcceptButton = Commit;
        }

        private void InitializedStaged()
        {
            Cursor.Current = Cursors.WaitCursor;
            Staged.GitItemStatusses = null;
            SolveMergeconflicts.Visible = GitCommands.GitCommands.InTheMiddleOfConflictedMerge();
            Staged.GitItemStatusses = GitCommands.GitCommands.GetStagedFiles();
        }

        private void InitializedStagedAsync()
        {
            Cursor.Current = Cursors.WaitCursor;

            ThreadPool.QueueUserWorkItem(delegate
            {
                bool inTheMiddleOfConflictedMerge = GitCommands.GitCommands.InTheMiddleOfConflictedMerge();
                List<GitItemStatus> stagedFiles = GitCommands.GitCommands.GetStagedFiles();

                syncContext.Post(delegate
                {
                    Staged.GitItemStatusses = null;
                    SolveMergeconflicts.Visible = inTheMiddleOfConflictedMerge;
                    Staged.GitItemStatusses = stagedFiles;
                }, null);
            });
        }

        // This method is passed in to the SetTextCallBack delegate
        // to set the Text property of textBox1.
        private void LoadUnstagedOutput()
        {
            Unstaged.GitItemStatusses = GitCommands.GitCommands.GetAllChangedFilesFromString(gitGetUnstagedCommand.Output.ToString());
            Loading.Visible = false;
            AddFiles.Enabled = true;

            UnstageFiles.Enabled = true;
            AddFiles.Enabled = true;
            filesListedToCommitToolStripMenuItem.Enabled = true;
            workingToolStripMenuItem.Enabled = true;
        }

        void gitCommands_Exited(object sender, EventArgs e)
        {
            syncContext.Post(_ => LoadUnstagedOutput(), null);
        }

        private GitItemStatus currentItem;
        private bool currentItemStaged;
        protected void ShowChanges(GitItemStatus item, bool staged)
        {
            currentItem = item;
            currentItemStaged = staged;

            if (item == null)
                return;

            if (item.Name.EndsWith(".png"))
            {
                SelectedDiff.ViewFile(item.Name);
            }
            else
                if (item.IsTracked)
                {
                    SelectedDiff.ViewCurrentChanges(item.Name, staged);
                }
                else
                {
                    SelectedDiff.ViewFile(item.Name);
                }
        }

        private void Tracked_SelectionChanged(object sender, EventArgs e)
        {
            if (Staged.SelectedItems.Count == 0) return;

            Unstaged.SelectedItem = null;
            ShowChanges(Staged.SelectedItems[0], true);
        }

        private void Untracked_SelectionChanged(object sender, EventArgs e)
        {
            if (Unstaged.SelectedItems.Count == 0) return;

            Staged.SelectedItem = null;
            ShowChanges(Unstaged.SelectedItems[0], false);
        }

        public bool NeedRefresh = false;

        private void Commit_Click(object sender, EventArgs e)
        {
            if (Staged.GitItemStatusses.Count == 0)
            {
                if (MessageBox.Show(noFilesStaged.Text, noStagedChanges.Text, MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }

            DoCommit(false);
        }

        private void DoCommit(bool amend)
        {
            if (GitCommands.GitCommands.InTheMiddleOfConflictedMerge())
            {
                MessageBox.Show(mergeConflicts.Text, mergeConflictsCaption.Text);
                return;
            }
            if (Message.Text.Length < 2)
            {
                MessageBox.Show(enterCommitMessage.Text, enterCommitMessageCaption.Text);
                return;
            }

            if (GitCommands.GitCommands.GetSelectedBranch().CompareTo("(no branch)") == 0)
            {
                if (MessageBox.Show(notOnBranch.Text, notOnBranchCaption.Text, MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }

            try
            {
                using (StreamWriter textWriter = new StreamWriter(GitCommands.Settings.WorkingDirGitDir() + "\\COMMITMESSAGE", false, Settings.Encoding))
                {
                    int lineNumber = 0;
                    foreach (string line in Message.Text.Split('\n'))
                    {
                        if (lineNumber == 1 && !string.IsNullOrEmpty(line))
                            textWriter.WriteLine();

                        textWriter.WriteLine(line);
                        lineNumber++;
                    }
                }

                FormProcess form = new FormProcess(GitCommands.GitCommands.CommitCmd(amend));
                form.ShowDialog();

                NeedRefresh = true;

                if (!form.ErrorOccured())
                {
                    Message.Text = string.Empty;

                    if (CloseDialogAfterCommit.Checked)
                    {
                        Close();
                    }
                    else
                    {
                        foreach (GitItemStatus gitItemStatus in Unstaged.GitItemStatusses)
                        {
                            if (gitItemStatus.IsTracked)
                            {
                                InitializedStaged();
                                return;
                            }
                        }

                        Close();
                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: " + e.Message);
            }
        }

        private void Scan_Click(object sender, EventArgs e)
        {
            Scan.Enabled = false;
            Initialize();
            Scan.Enabled = true;
        }

        private void Stage_Click(object sender, EventArgs e)
        {
            IList<GitItemStatus> gitItemStatusses = Unstaged.SelectedItems;
            Stage(gitItemStatusses);
        }

        private void Stage(IList<GitItemStatus> gitItemStatusses)
        {
            UnstageFiles.Enabled = false;
            AddFiles.Enabled = false;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //Loading.Visible = true;
                progressBar.Visible = true;
                progressBar.Maximum = gitItemStatusses.Count * 2;
                progressBar.Value = 0;

                List<GitItemStatus> files = new List<GitItemStatus>();

                foreach (GitItemStatus gitItemStatus in gitItemStatusses)
                {
                    progressBar.Value = Math.Min(progressBar.Maximum - 1, progressBar.Value + 1);
                    files.Add(gitItemStatus);
                }

                /*OutPut.Text = */
                FormStatus.ProcessStart processStart = new FormStatus.ProcessStart
                    (
                        delegate(FormStatus form)
                        {
                            form.AddOutput(string.Format(stageFiles.Text, files.Count));
                            string output = GitCommands.GitCommands.StageFiles(files);
                            form.AddOutput(output);
                            form.Done(string.IsNullOrEmpty(output));
                        }
                    );
                FormStatus process = new FormStatus(processStart, null);
                process.Text = stageDetails.Text;
                process.ShowDialogOnError();

                InitializedStaged();
                List<GitItemStatus> stagedFiles = (List<GitItemStatus>)Staged.GitItemStatusses;
                List<GitItemStatus> unStagedFiles = (List<GitItemStatus>)Unstaged.GitItemStatusses;
                Unstaged.GitItemStatusses = null;

                unStagedFiles.RemoveAll(item => stagedFiles.Exists(i => i.Name == item.Name));

                Unstaged.GitItemStatusses = unStagedFiles;

                progressBar.Value = progressBar.Maximum;

                //Initialize();
                progressBar.Visible = false;
            }
            catch
            {
            }
            UnstageFiles.Enabled = true;
            AddFiles.Enabled = true;

            Commit.Enabled = true;
            Amend.Enabled = true;
            AcceptButton = Commit;
            Commit.Focus();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            if (Abort.AbortCurrentAction())
            {
                Initialize();
                NeedRefresh = true;
            }

        }

        private void UnstageFiles_Click(object sender, EventArgs e)
        {
            UnstageFiles.Enabled = false;
            AddFiles.Enabled = false;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (Staged.GitItemStatusses.Count > 10 && Staged.SelectedItems.Count == Staged.GitItemStatusses.Count)
                {
                    Loading.Visible = true;
                    /*OutPut.Text =*/
                    GitCommands.GitCommands.ResetMixed("HEAD");
                    Initialize();
                }
                else
                {
                    //Loading.Visible = true;
                    progressBar.Visible = true;
                    progressBar.Maximum = Staged.SelectedItems.Count * 2;
                    progressBar.Value = 0;

                    List<GitItemStatus> files = new List<GitItemStatus>();
                    List<GitItemStatus> allFiles = new List<GitItemStatus>();
                    string result = "";

                    foreach (GitItemStatus item in Staged.SelectedItems)
                    {
                        progressBar.Value = Math.Min(progressBar.Maximum - 1, progressBar.Value + 1);
                        if (!item.IsNew)
                        {
                            progressBar.Value = Math.Min(progressBar.Maximum - 1, progressBar.Value + 1);
                            result = GitCommands.GitCommands.UnstageFileToRemove(item.Name);
                        }
                        else
                        {
                            files.Add(item);
                        }
                        allFiles.Add(item);
                    }

                    /*OutPut.Text = result + Environment.NewLine + */
                    GitCommands.GitCommands.UnstageFiles(files);

                    InitializedStaged();
                    List<GitItemStatus> stagedFiles = (List<GitItemStatus>)Staged.GitItemStatusses;
                    List<GitItemStatus> unStagedFiles = (List<GitItemStatus>)Unstaged.GitItemStatusses;
                    Unstaged.GitItemStatusses = null;
                    foreach (GitItemStatus item in allFiles)
                    {
                        if (!stagedFiles.Exists(i => i.Name == item.Name))
                        {
                            if (!unStagedFiles.Exists(i => i.Name == item.Name))
                            {
                                if (item.IsNew && !item.IsChanged && !item.IsDeleted)
                                    item.IsTracked = false;
                                else
                                    item.IsTracked = true;

                                unStagedFiles.Add(item);
                            }
                        }
                    }
                    Staged.GitItemStatusses = stagedFiles;
                    Unstaged.GitItemStatusses = unStagedFiles;

                    progressBar.Value = progressBar.Maximum;
                }
                //Initialize();
                progressBar.Visible = false;
            }
            catch
            {
            }
            UnstageFiles.Enabled = true;
            AddFiles.Enabled = true;

        }

        private void splitContainer8_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void Staged_Click(object sender, EventArgs e)
        {
            Tracked_SelectionChanged(sender, e);
        }

        private void Unstaged_Click(object sender, EventArgs e)
        {
            Untracked_SelectionChanged(sender, e);
        }

        private void Amend_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (string.IsNullOrEmpty(Message.Text))
            {
                Message.Text = GitCommands.GitCommands.GetPreviousCommitMessage(0);
                return;
            }

            if (MessageBox.Show(amendCommit.Text, amendCommitCaption.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DoCommit(true);
            }
        }

        private void ResetSoft_Click(object sender, EventArgs e)
        {
            if (Unstaged.SelectedItem != null && MessageBox.Show(resetChanges.Text, resetChangesCaption.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool deleteNewFiles = false;
                bool askToDeleteNewFiles = true;
                StringBuilder output = new StringBuilder();
                foreach (GitItemStatus item in Unstaged.SelectedItems)
                {
                    if (item.IsNew)
                    {
                        if (!deleteNewFiles && askToDeleteNewFiles)
                        {
                            DialogResult result = MessageBox.Show(alsoDeleteUntrackedFiles.Text, alsoDeleteUntrackedFilesCaption.Text, MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                                deleteNewFiles = true;

                            askToDeleteNewFiles = false;
                        }

                        if (deleteNewFiles)
                        {
                            File.Delete(GitCommands.Settings.WorkingDir + item.Name);
                        }
                    }
                    else
                    {
                        output.Append(GitCommands.GitCommands.ResetFile(item.Name));
                    }
                }

                if (!string.IsNullOrEmpty(output.ToString()))
                    MessageBox.Show(output.ToString(), "Reset changes");

                Initialize();
            }
        }

        private void Unstaged_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void deleteFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SelectedDiff.ViewText("", "");
                if (Unstaged.SelectedItem != null && MessageBox.Show(deleteSelectedFiles.Text, deleteSelectedFilesCaption.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (GitItemStatus item in Unstaged.SelectedItems)
                    {
                        File.Delete(GitCommands.Settings.WorkingDir + item.Name);
                    }

                    Initialize();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(deleteFailed.Text + Environment.NewLine + ex.Message);
            }
        }

        private void SolveMergeconflicts_Click(object sender, EventArgs e)
        {
            if (GitUICommands.Instance.StartResolveConflictsDialog())
                Initialize();
        }

        private void deleteSelectedFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(deleteSelectedFiles.Text, deleteSelectedFilesCaption.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    foreach (GitItemStatus gitItemStatus in Unstaged.SelectedItems)
                    {
                        File.Delete(GitCommands.Settings.WorkingDir + gitItemStatus.Name);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(deleteFailed.Text + Environment.NewLine + ex.ToString());
                }
                Initialize();
            }
        }

        private void resetSelectedFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(resetSelectedChanges.Text, resetChangesCaption.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (GitItemStatus gitItemStatus in Unstaged.SelectedItems)
                {
                    string output = GitCommands.GitCommands.ResetFile(gitItemStatus.Name);
                }
                Initialize();
            }
        }

        private void resetAlltrackedChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reset_Click(null, null);
        }

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GitUICommands.Instance.StartEditGitIgnoreDialog();
            Initialize();
        }

        private void stageAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IList<GitItemStatus> rows = Unstaged.GitItemStatusses;
            Stage(rows);
        }

        private void unstageAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*OutPut.Text =*/
            GitCommands.GitCommands.ResetMixed("HEAD");
            Initialize();
        }

        private void FormCommit_Shown(object sender, EventArgs e)
        {
            Initialize();

            string message = GitCommands.GitCommands.GetMergeMessage();
            if (string.IsNullOrEmpty(message) && File.Exists(Settings.WorkingDirGitDir() + "\\COMMITMESSAGE"))
                message = File.ReadAllText(Settings.WorkingDirGitDir() + "\\COMMITMESSAGE", Settings.Encoding);
            if (!string.IsNullOrEmpty(message))
                Message.Text = message;

            ThreadPool.QueueUserWorkItem(delegate
            {
                string text = "Commit to " + GitCommands.GitCommands.GetSelectedBranch() + " (" + Settings.WorkingDir + ")";

                syncContext.Post(delegate
                {
                    Text = text;
                }, null);
            });
        }

        private void Staged_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SpellCheck_Click(object sender, EventArgs e)
        {
            Message.CheckSpelling();
        }

        private void Message_Load(object sender, EventArgs e)
        {

        }

        private void FormCommit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrEmpty(Message.Text))
            {
                using (StreamWriter textWriter = new StreamWriter(GitCommands.Settings.WorkingDirGitDir() + "\\COMMITMESSAGE", false))
                {
                    textWriter.Write(Message.Text);
                    textWriter.Close();
                }
            }
            else
            {
                File.Delete(GitCommands.Settings.WorkingDirGitDir() + "\\COMMITMESSAGE");
            }
            SavePosition("commit");
        }

        private void deleteAllUntrackedFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(deleteUntrackedFiles.Text, deleteUntrackedFilesCaption.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                new FormProcess("clean -f").ShowDialog();
                Initialize();
            }
        }

        private void stageChunkOfFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Unstaged.SelectedItems.Count != 1)
            {
                MessageBox.Show(onlyStageChunkOfSingleFileError.Text, stageChunkOfFileCaption.Text);
                return;
            }

            foreach (GitItemStatus gitItemStatus in Unstaged.SelectedItems)
            {
                GitCommands.GitCommands.RunRealCmd(Settings.GitCommand, "add -p \"" + gitItemStatus.Name + "\"");
                Initialize();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void showIgnoredFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showIgnoredFilesToolStripMenuItem.Checked = !showIgnoredFilesToolStripMenuItem.Checked;
            Scan_Click(null, null);
        }

        private void commitMessageToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            commitMessageToolStripMenuItem.DropDownItems.Clear();
            AddCommitMessageToMenu(0);
            AddCommitMessageToMenu(1);
            AddCommitMessageToMenu(2);
            AddCommitMessageToMenu(3);
        }

        private void AddCommitMessageToMenu(int numberBack)
        {
            string commitMessage = GitCommands.GitCommands.GetPreviousCommitMessage(numberBack);
            if (string.IsNullOrEmpty(commitMessage))
                return;

            ToolStripMenuItem toolStripItem = new ToolStripMenuItem();
            toolStripItem.Tag = commitMessage;
            toolStripItem.Text = commitMessage.Substring(0, Math.Min(Math.Min(50, commitMessage.Length), commitMessage.IndexOf('\n'))) + "...";

            commitMessageToolStripMenuItem.DropDownItems.Add(toolStripItem);
        }

        private void commitMessageToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Message.Text = (string)e.ClickedItem.Tag;
        }

        private void addFileTogitignoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Unstaged.SelectedItems.Count == 0) return;

            SelectedDiff.ViewText("", "");
            GitItemStatus item = Unstaged.SelectedItem;
            new FormAddToGitIgnore(item.Name).ShowDialog();
            Initialize();
        }

        void SelectedDiff_ExtraDiffArgumentsChanged(object sender, EventArgs e)
        {
            ShowChanges(currentItem, currentItemStaged);
        }

        private void splitContainer3_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void showUntrackedFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showUntrackedFilesToolStripMenuItem.Checked = !showUntrackedFilesToolStripMenuItem.Checked;
            Scan_Click(null, null);
        }

        private void commitMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rescanChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scan_Click(null, null);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Unstaged.SelectedItems.Count == 0) return;

            GitItemStatus item = Unstaged.SelectedItem;
            string fileName = item.Name;

            System.Diagnostics.Process.Start(Settings.WorkingDir + fileName);
        }

        private void openWithToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Unstaged.SelectedItems.Count == 0) return;

            GitItemStatus item = Unstaged.SelectedItem;
            string fileName = item.Name;

            OpenWith.OpenAs(Settings.WorkingDir + fileName);
        }

        private void CloseDialogAfterCommit_CheckedChanged(object sender, EventArgs e)
        {
            Settings.CloseCommitDialogAfterCommit = CloseDialogAfterCommit.Checked;
        }

        private void filenameToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Unstaged.SelectedItems.Count == 0) return;

            GitItemStatus item = Unstaged.SelectedItem;
            string fileName = Settings.WorkingDir + item.Name;

            Clipboard.SetText(fileName.Replace('/', '\\'));
        }

        private void openWithDifftoolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Unstaged.SelectedItems.Count == 0) return;

            GitItemStatus item = Unstaged.SelectedItem;
            string fileName = item.Name;

            string cmdOutput = GitCommands.GitCommands.OpenWithDifftool(fileName);

            if (!string.IsNullOrEmpty(cmdOutput))
                MessageBox.Show(cmdOutput);
        }


        private void resetPartOfFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Unstaged.SelectedItems.Count != 1)
            {
                MessageBox.Show(onlyStageChunkOfSingleFileError.Text, resetStageChunkOfFileCaption.Text);
                return;
            }

            foreach (GitItemStatus gitItemStatus in Unstaged.SelectedItems)
            {
                GitCommands.GitCommands.RunRealCmd(Settings.GitCommand, "checkout -p \"" + gitItemStatus.Name + "\"");
                Initialize();
            }
        }

    }
}
