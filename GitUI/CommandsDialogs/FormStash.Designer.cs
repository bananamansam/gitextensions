using System.Windows.Forms;
using GitUI.Editor;

namespace GitUI.CommandsDialogs
{
    partial class FormStash
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStash));
            this.gitStashBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new GitUI.ToolStripEx();
            this.Stash = new System.Windows.Forms.ToolStripButton();
            this.Apply = new System.Windows.Forms.ToolStripButton();
            this.Clear = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_customMessage = new System.Windows.Forms.ToolStripButton();
            this.StashMessage = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Loading = new System.Windows.Forms.PictureBox();
            this.Stashed = new GitUI.FileStatusList();
            this.Stashes = new GitUI.UserControls.StashTreeView();
            this.View = new GitUI.Editor.FileViewer();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.StashKeepIndex = new System.Windows.Forms.ToolStripButton();
            this.chkIncludeUntrackedFiles = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.gitStashBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Loading)).BeginInit();
            this.SuspendLayout();
            // 
            // gitStashBindingSource
            // 
            this.gitStashBindingSource.DataSource = typeof(GitCommands.GitStash);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Panel1MinSize = 170;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.View);
            this.splitContainer1.Size = new System.Drawing.Size(829, 716);
            this.splitContainer1.SplitterDistance = 170;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer2_SplitterMoved);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.StashMessage, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.Stashes, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(170, 716);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.ClickThrough = true;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Stash,
            this.Apply,
            this.Clear,
            this.toolStripButton1,
            this.toolStripButton_customMessage,
            this.StashKeepIndex,
            this.chkIncludeUntrackedFiles});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip1.Size = new System.Drawing.Size(170, 25);
            this.toolStrip1.TabIndex = 1;
            // 
            // Stash
            // 
            this.Stash.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Stash.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Stash.Image = global::GitUI.Properties.Resources.IconSave;
            this.Stash.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Stash.Name = "Stash";
            this.Stash.Size = new System.Drawing.Size(23, 22);
            this.Stash.Text = "btnSaveStash";
            this.Stash.ToolTipText = "Save local changes to a new stash, then revert local changes";
            this.Stash.Click += new System.EventHandler(this.StashClick);
            // 
            // Apply
            // 
            this.Apply.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Apply.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Apply.Image = global::GitUI.Properties.Resources.stashApply;
            this.Apply.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Apply.Name = "Apply";
            this.Apply.Size = new System.Drawing.Size(23, 22);
            this.Apply.Text = "Apply Stash";
            this.Apply.ToolTipText = "Apply selected stash on top of current working directory state";
            this.Apply.Click += new System.EventHandler(this.ApplyClick);
            // 
            // Clear
            // 
            this.Clear.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Clear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Clear.Image = ((System.Drawing.Image)(resources.GetObject("Clear.Image")));
            this.Clear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(23, 22);
            this.Clear.Text = "Delete Stash";
            this.Clear.ToolTipText = "Remove selected stash from the list";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::GitUI.Properties.Resources.arrow_refresh;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Refresh";
            this.toolStripButton1.Click += new System.EventHandler(this.RefreshClick);
            // 
            // toolStripButton_customMessage
            // 
            this.toolStripButton_customMessage.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_customMessage.CheckOnClick = true;
            this.toolStripButton_customMessage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_customMessage.Enabled = false;
            this.toolStripButton_customMessage.Image = global::GitUI.Properties.Resources.Modified;
            this.toolStripButton_customMessage.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButton_customMessage.Name = "toolStripButton_customMessage";
            this.toolStripButton_customMessage.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripButton_customMessage.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_customMessage.Text = "Custom stash message";
            this.toolStripButton_customMessage.ToolTipText = "Write custom stash message";
            this.toolStripButton_customMessage.Click += new System.EventHandler(this.toolStripButton_customMessage_Click);
            this.toolStripButton_customMessage.EnabledChanged += new System.EventHandler(this.toolStripButton_customMessage_EnabledChanged);
            // 
            // StashMessage
            // 
            this.StashMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StashMessage.BackColor = System.Drawing.SystemColors.Info;
            this.StashMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StashMessage.Location = new System.Drawing.Point(3, 131);
            this.StashMessage.Name = "StashMessage";
            this.StashMessage.ReadOnly = true;
            this.StashMessage.Size = new System.Drawing.Size(164, 44);
            this.StashMessage.TabIndex = 3;
            this.StashMessage.Text = "";
            this.StashMessage.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.StashMessage_MouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.Loading);
            this.panel1.Controls.Add(this.Stashed);
            this.panel1.Location = new System.Drawing.Point(3, 181);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(164, 532);
            this.panel1.TabIndex = 4;
            // 
            // Loading
            // 
            this.Loading.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Loading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Loading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Loading.Location = new System.Drawing.Point(0, 0);
            this.Loading.Name = "Loading";
            this.Loading.Size = new System.Drawing.Size(164, 532);
            this.Loading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Loading.TabIndex = 12;
            this.Loading.TabStop = false;
            this.Loading.Visible = false;
            // 
            // Stashed
            // 
            this.Stashed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Stashed.Location = new System.Drawing.Point(0, 0);
            this.Stashed.Margin = new System.Windows.Forms.Padding(4);
            this.Stashed.Name = "Stashed";
            this.Stashed.Size = new System.Drawing.Size(164, 532);
            this.Stashed.TabIndex = 2;
            this.Stashed.SelectedIndexChanged += new System.EventHandler(this.StashedSelectedIndexChanged);
            // 
            // Stashes
            // 
            this.Stashes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Stashes.Location = new System.Drawing.Point(3, 28);
            this.Stashes.MinimumSize = new System.Drawing.Size(20, 20);
            this.Stashes.Name = "Stashes";
            this.Stashes.Size = new System.Drawing.Size(164, 97);
            this.Stashes.TabIndex = 15;
            // 
            // View
            // 
            this.View.Dock = System.Windows.Forms.DockStyle.Fill;
            this.View.Location = new System.Drawing.Point(0, 0);
            this.View.Margin = new System.Windows.Forms.Padding(4);
            this.View.Name = "View";
            this.View.Size = new System.Drawing.Size(655, 716);
            this.View.TabIndex = 0;
            // 
            // StashKeepIndex
            // 
            this.StashKeepIndex.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.StashKeepIndex.CheckOnClick = true;
            this.StashKeepIndex.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StashKeepIndex.Image = ((System.Drawing.Image)(resources.GetObject("StashKeepIndex.Image")));
            this.StashKeepIndex.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StashKeepIndex.Name = "StashKeepIndex";
            this.StashKeepIndex.Size = new System.Drawing.Size(68, 19);
            this.StashKeepIndex.Text = "Keep Index";
            // 
            // chkIncludeUntrackedFiles
            // 
            this.chkIncludeUntrackedFiles.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.chkIncludeUntrackedFiles.CheckOnClick = true;
            this.chkIncludeUntrackedFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.chkIncludeUntrackedFiles.Image = ((System.Drawing.Image)(resources.GetObject("chkIncludeUntrackedFiles.Image")));
            this.chkIncludeUntrackedFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.chkIncludeUntrackedFiles.Name = "chkIncludeUntrackedFiles";
            this.chkIncludeUntrackedFiles.Size = new System.Drawing.Size(133, 19);
            this.chkIncludeUntrackedFiles.Text = "Include Untracked Files";
            // 
            // FormStash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(829, 716);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(640, 478);
            this.Name = "FormStash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stash";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormStashFormClosing);
            this.Load += new System.EventHandler(this.FormStashLoad);
            this.Shown += new System.EventHandler(this.FormStashShown);
            this.Resize += new System.EventHandler(this.FormStash_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.gitStashBindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Loading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private FileStatusList Stashed;
        private System.Windows.Forms.BindingSource gitStashBindingSource;
        private System.Windows.Forms.RichTextBox StashMessage;
        private FileViewer View;
        private ToolStripEx toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private PictureBox Loading;
        private ToolStripButton toolStripButton_customMessage;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel1;
        private ToolTip toolTip;
        private ToolStripButton Stash;
        private ToolStripButton Clear;
        private ToolStripButton Apply;
        private UserControls.StashTreeView Stashes;
        private ToolStripButton StashKeepIndex;
        private ToolStripButton chkIncludeUntrackedFiles;
    }
}