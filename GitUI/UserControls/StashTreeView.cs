using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GitCommands;
using ResourceManager;

namespace GitUI.UserControls
{
    public partial class StashTreeView : GitModuleControl
    {
        public event TreeViewEventHandler AfterSelect;

        public StashTreeView()
        {
            InitializeComponent();
            Translate();
            this.MinimumSize = new System.Drawing.Size(20, 20);
            StashTree.AfterSelect += StashTree_AfterSelect;
            StashTree.HideSelection = false;
        }

        private void StashTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (AfterSelect != null && StashTree.SelectedNode.Tag != null)
            {
                AfterSelect(sender, e);
            }
        }

        public void LoadStashTree()
        {
            IList<GitStash> stashedItems = Module.GetStashes();
            StashCount = stashedItems.Count;

            GitStash currentWorkingDirStashItem = new GitStash
            {
                Name = _currentWorkingDirChanges.Text,
                Message = _currentWorkingDirChanges.Text
            };

            StashTree.Nodes.Clear();

            WorkingDirectoryNode = BuildStashNode(currentWorkingDirStashItem);
            StashTree.Nodes.Add(WorkingDirectoryNode);

            MostRecentStash = null;
            foreach (var stashGroup in stashedItems.GroupBy(x => x.Branch).OrderBy(x => x.Key))
            {
                TreeNode groupNode = new TreeNode();
                groupNode.Text = stashGroup.Key;

                foreach (var stash in stashGroup)
                {
                    TreeNode stashNode = BuildStashNode(stash);
                    groupNode.Nodes.Add(stashNode);

                    if (stash == stashedItems[0])
                    {
                        MostRecentStash = stashNode;
                    }
                }

                StashTree.Nodes.Add(groupNode);
            }

            StashTree.ExpandAll();
        }

        private TreeNode MostRecentStash { get; set; }
        private TreeNode WorkingDirectoryNode { get; set; }

        private TreeNode BuildStashNode(GitStash stash)
        {
            TreeNode n = new TreeNode();
            n.Text = stash.Message;
            n.Name = stash.Name;
            n.Tag = stash;
            return n;
        }

        public void SelectWorkingDirectoryNode()
        {
            StashTree.SelectedNode = WorkingDirectoryNode;
        }
        
        public void SelectMostRecentStash()
        {
            if (MostRecentStash != null)
            {
                StashTree.SelectedNode = MostRecentStash;
            }
            else
            {
                SelectWorkingDirectoryNode();
            }
        }

        public Int32 StashCount { get; private set; }

        public GitStash SelectedItem
        {
            get { return StashTree.SelectedNode.Tag as GitStash; }
        }

        readonly TranslationString _currentWorkingDirChanges = new TranslationString("Current working directory changes");
    }
}
