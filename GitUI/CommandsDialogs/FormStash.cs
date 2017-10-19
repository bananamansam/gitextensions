using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GitCommands;
using PatchApply;
using ResourceManager;

namespace GitUI.CommandsDialogs
{
    public sealed partial class FormStash : GitModuleForm
    {
        readonly TranslationString currentWorkingDirChanges = new TranslationString("Current working directory changes");
        readonly TranslationString noStashes = new TranslationString("There are no stashes.");
        readonly TranslationString stashUntrackedFilesNotSupportedCaption = new TranslationString("Stash untracked files");
        readonly TranslationString stashUntrackedFilesNotSupported = new TranslationString("Stash untracked files is not supported in the version of msysgit you are using. Please update msysgit to at least version 1.7.7 to use this option.");
        readonly TranslationString stashDropConfirmTitle = new TranslationString("Drop Stash Confirmation");
        readonly TranslationString cannotBeUndone = new TranslationString("This action cannot be undone.");
        readonly TranslationString areYouSure = new TranslationString("Are you sure you want to drop the stash? This action cannot be undone.");
        readonly TranslationString dontShowAgain = new TranslationString("Don't show me this message again.");

        private AsyncLoader _asyncLoader = new AsyncLoader();

        private FormStash()
            : this(null)
        { }

        public FormStash(GitUICommands aCommands)
            : base(aCommands)
        {
            InitializeComponent();
            KeyPreview = true;
            Loading.Image = global::GitUI.Properties.Resources.loadingpanel;
            Translate();
            View.ExtraDiffArgumentsChanged += ViewExtraDiffArgumentsChanged;

            Stashes.UICommandsSource = this;
            Stashes.AfterSelect += this.Stashes_AfterSelect;
        }

        private void ViewExtraDiffArgumentsChanged(object sender, EventArgs e)
        {
            StashedSelectedIndexChanged(null, null);
        }

        private void FormStashFormClosing(object sender, FormClosingEventArgs e)
        {
            AppSettings.StashKeepIndex = StashKeepIndex.Checked;
            AppSettings.IncludeUntrackedFilesInManualStash = chkIncludeUntrackedFiles.Checked;
            AppSettings.StashDialogSplitter = splitContainer1.SplitterDistance;
        }

        private void FormStashLoad(object sender, EventArgs e)
        {
            StashKeepIndex.Checked = AppSettings.StashKeepIndex;
            chkIncludeUntrackedFiles.Checked = AppSettings.IncludeUntrackedFilesInManualStash;
            if (AppSettings.StashDialogSplitter != -1)
            {
                splitContainer1.SplitterDistance = AppSettings.StashDialogSplitter;
            }
            else
            {
                splitContainer2_SplitterMoved(null, null);
            }
        }

        private void Initialize()
        {
            StashMessage.Text = "";
            Stashes.LoadStashTree();

            if (AppSettings.SelectMostRecentStashOnFormLoad)
            {
                Stashes.SelectMostRecentStash();
            }
            else
            {
                Stashes.SelectWorkingDirectoryNode();
            }
        }

        private void InitializeSoft()
        {
            GitStash gitStash = Stashes.SelectedItem as GitStash;

            Stashed.GitItemStatuses = null;

            Loading.Visible = true;
            Stashes.Enabled = false;
            toolStripButton1.Enabled = false;
            toolStripButton_customMessage.Enabled = false;

            foreach (MenuItem item in Stashes.ContextMenu.MenuItems)
            {
                item.Enabled = false;
            }

            if (gitStash == null)
            {
                Stashed.GitItemStatuses = null;
            }
            else if(gitStash.Branch == null) // working dir
            {
                toolStripButton_customMessage.Enabled = true;
                _asyncLoader.Load(() => Module.GetAllChangedFiles(), LoadGitItemStatuses);
                Clear.Enabled = false; // disallow Drop  (of current working directory)
                Apply.Enabled = false; // disallow Apply (of current working directory)
            }
            else
            {
                _asyncLoader.Load(() => Module.GetStashDiffFiles(gitStash.Name), LoadGitItemStatuses);
                Clear.Enabled = true; // allow Drop
                Apply.Enabled = true; // allow Apply

                foreach (MenuItem item in Stashes.ContextMenu.MenuItems)
                {
                    item.Enabled = true;
                }
            }
        }

        private void LoadGitItemStatuses(IList<GitItemStatus> gitItemStatuses)
        {
            Stashed.GitItemStatuses = gitItemStatuses;
            Loading.Visible = false;
            Stashes.Enabled = true;
            toolStripButton1.Enabled = true;
        }

        private void StashedSelectedIndexChanged(object sender, EventArgs e)
        {
            GitStash gitStash = Stashes.SelectedItem as GitStash;
            GitItemStatus stashedItem = Stashed.SelectedItem;
            Cursor.Current = Cursors.WaitCursor;

            if (stashedItem != null &&
                gitStash.Branch == null) //current working directory
            {
                View.ViewCurrentChanges(stashedItem);
            }
            else if (stashedItem != null)
            {
                if (stashedItem.IsNew && !stashedItem.IsTracked)
                {
                    if (!stashedItem.IsSubmodule)
                        View.ViewGitItem(stashedItem.Name, stashedItem.TreeGuid);
                    else
                        View.ViewText(stashedItem.Name,
                            LocalizationHelpers.GetSubmoduleText(Module, stashedItem.Name, stashedItem.TreeGuid));
                }
                else
                {
                    string extraDiffArguments = View.GetExtraDiffArguments();
                    Encoding encoding = this.View.Encoding;
                    View.ViewPatch(() =>
                    {
                        Patch patch = Module.GetSingleDiff(gitStash.Name, gitStash.Name + "^", stashedItem.Name, stashedItem.OldName, extraDiffArguments, encoding, false);
                        if (patch == null)
                            return String.Empty;
                        if (stashedItem.IsSubmodule)
                            return LocalizationHelpers.ProcessSubmodulePatch(Module, stashedItem.Name, patch);
                        return patch.Text;
                    });
                }
            }
            else
                View.ViewText(string.Empty, string.Empty);
            Cursor.Current = Cursors.Default;
        }

        private void StashClick(object sender, EventArgs e)
        {
            if (chkIncludeUntrackedFiles.Checked && !GitCommandHelpers.VersionInUse.StashUntrackedFilesSupported)
            {
                if (MessageBox.Show(stashUntrackedFilesNotSupported.Text, stashUntrackedFilesNotSupportedCaption.Text, MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
                    return;
            }

            Cursor.Current = Cursors.WaitCursor;

            var msg = toolStripButton_customMessage.Checked ? " " + StashMessage.Text.Trim() : string.Empty;
            UICommands.StashSave(this, chkIncludeUntrackedFiles.Checked, StashKeepIndex.Checked, msg);
            Initialize();
            Cursor.Current = Cursors.Default;
        }

        private void ClearClick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var stashName = GetStashName();
            if (AppSettings.StashConfirmDropShow)
            {
                DialogResult res = PSTaskDialog.cTaskDialog.MessageBox(
                                        this,
                                       stashDropConfirmTitle.Text,
                                       cannotBeUndone.Text,
                                       areYouSure.Text,
                                       "",
                                       "",
                                       dontShowAgain.Text,
                                       PSTaskDialog.eTaskDialogButtons.OKCancel,
                                       PSTaskDialog.eSysIcons.Information,
                                       PSTaskDialog.eSysIcons.Information);
                if (res == DialogResult.OK)
                {
                    UICommands.StashDrop(this, ((GitStash)Stashes.SelectedItem).Name);
                    Initialize();
                    Cursor.Current = Cursors.Default;
                }

                if (PSTaskDialog.cTaskDialog.VerificationChecked)
                {
                    AppSettings.StashConfirmDropShow = false;
                }
            }
            else
            {
                if (Stashes.SelectedItem != null)
                {
                    UICommands.StashDrop(this, Stashes.SelectedItem.Name);
                    Initialize();
                    Cursor.Current = Cursors.Default;
                }
                else if (Stashes.ChildItems.Count > 0)
                {
                    foreach (GitStash item in Stashes.ChildItems)
                    {
                        UICommands.StashDrop(this, item.Name);
                    }

                    Initialize();
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private string GetStashName()
        {
            return ((GitStash)Stashes.SelectedItem).Name;
        }

        private void ApplyClick(object sender, EventArgs e)
        {
            Stashed.ClearSelected();
            ApplyStash();
        }

        void Stashed_ApplySelectedItems(object sender, System.EventArgs e)
        {
            ApplyStash();
        }

        private void ApplyStash()
        {
            if (Stashed.SelectedItems.Any())
            {
                foreach (var item in Stashed.SelectedItems.Where(x => !x.IsDeleted))
                {
                    UICommands.StashApply(this, Stashes.SelectedItem.Name, item.Name);
                }
            }
            else
            {
                UICommands.StashApply(this, ((GitStash)Stashes.SelectedItem).Name);
            }

            Initialize();
        }

        private void Stashes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            InitializeSoft();

            if (Stashes.SelectedItem != null)
                StashMessage.Text = ((GitStash)Stashes.SelectedItem).Message;

            if (Stashes.StashCount == 0)
                StashMessage.Text = noStashes.Text;

            Cursor.Current = Cursors.Default;
        }

        private void RefreshClick(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void RefreshAll()
        {
            Cursor.Current = Cursors.WaitCursor;
            Initialize();
            Cursor.Current = Cursors.Default;
        }

        private void FormStashShown(object sender, EventArgs e)
        {
            // shown when form is first displayed
            RefreshAll();
        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {
        }

        private void FormStash_Resize(object sender, EventArgs e)
        {
            splitContainer2_SplitterMoved(null, null);
        }


        private void toolStripButton_customMessage_Click(object sender, EventArgs e)
        {
            if (toolStripButton_customMessage.Enabled)
            {
                if (((ToolStripButton)sender).Checked)
                {
                    this.StashMessage.ReadOnly = false;
                    this.StashMessage.Focus();
                    this.StashMessage.SelectAll();
                }
                else
                {
                    this.StashMessage.ReadOnly = true;
                }
            }
        }

        private void StashMessage_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            if (toolStripButton_customMessage.Enabled)
            {
                if (!toolStripButton_customMessage.Checked)
                    toolStripButton_customMessage.PerformClick();
            }
        }

        private void toolStripButton_customMessage_EnabledChanged(object sender, EventArgs e)
        {
            var button = (ToolStripButton)sender;
            if (!button.Enabled)
            {
                StashMessage.ReadOnly = true;
            }
            else if (button.Enabled && button.Checked)
            {
                StashMessage.ReadOnly = false;
            }
        }

    }
}
