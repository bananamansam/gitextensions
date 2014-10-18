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
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.Stashes = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton_customMessage = new System.Windows.Forms.ToolStripButton();
            this.Stash = new System.Windows.Forms.ToolStripButton();
            this.Apply = new System.Windows.Forms.ToolStripButton();
            this.Clear = new System.Windows.Forms.ToolStripButton();
            this.StashKeepIndex = new System.Windows.Forms.CheckBox();
            this.chkIncludeUntrackedFiles = new System.Windows.Forms.CheckBox();
            this.StashMessage = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Loading = new System.Windows.Forms.PictureBox();
            this.Stashed = new GitUI.FileStatusList();
            this.View = new GitUI.Editor.FileViewer();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
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
            this.splitContainer1.Size = new System.Drawing.Size(708, 520);
            this.splitContainer1.SplitterDistance = 380;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer2_SplitterMoved);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.StashKeepIndex, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.chkIncludeUntrackedFiles, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.StashMessage, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(380, 520);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.ClickThrough = true;
            this.tableLayoutPanel2.SetColumnSpan(this.toolStrip1, 2);
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripLabel1,
            this.Stashes,
            this.toolStripButton_customMessage,
            this.Stash,
            this.Apply,
            this.Clear});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(380, 25);
            this.toolStrip1.TabIndex = 1;
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
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripLabel1.Size = new System.Drawing.Size(39, 22);
            this.toolStripLabel1.Text = "Show:";
            // 
            // Stashes
            // 
            this.Stashes.AutoSize = false;
            this.Stashes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Stashes.DropDownWidth = 200;
            this.Stashes.MaxDropDownItems = 30;
            this.Stashes.Name = "Stashes";
            this.Stashes.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.Stashes.Size = new System.Drawing.Size(141, 25);
            this.Stashes.ToolTipText = "Select a stash";
            this.Stashes.SelectedIndexChanged += new System.EventHandler(this.StashesSelectedIndexChanged);
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
            this.Clear.Click += this.ClearClick;
            // 
            // StashKeepIndex
            // 
            this.StashKeepIndex.AutoSize = true;
            this.StashKeepIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StashKeepIndex.Location = new System.Drawing.Point(193, 28);
            this.StashKeepIndex.Name = "StashKeepIndex";
            this.StashKeepIndex.Size = new System.Drawing.Size(184, 19);
            this.StashKeepIndex.TabIndex = 13;
            this.StashKeepIndex.Text = "Keep index";
            this.toolTip.SetToolTip(this.StashKeepIndex, "All changes already added to the index are left intact");
            this.StashKeepIndex.UseVisualStyleBackColor = true;
            // 
            // chkIncludeUntrackedFiles
            // 
            this.chkIncludeUntrackedFiles.AutoSize = true;
            this.chkIncludeUntrackedFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkIncludeUntrackedFiles.Location = new System.Drawing.Point(3, 28);
            this.chkIncludeUntrackedFiles.Name = "chkIncludeUntrackedFiles";
            this.chkIncludeUntrackedFiles.Size = new System.Drawing.Size(184, 19);
            this.chkIncludeUntrackedFiles.TabIndex = 14;
            this.chkIncludeUntrackedFiles.Text = "Include untracked files";
            this.toolTip.SetToolTip(this.chkIncludeUntrackedFiles, "All untracked files are also stashed and then cleaned");
            this.chkIncludeUntrackedFiles.UseVisualStyleBackColor = true;
            // 
            // StashMessage
            // 
            this.StashMessage.BackColor = System.Drawing.SystemColors.Info;
            this.StashMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel2.SetColumnSpan(this.StashMessage, 2);
            this.StashMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StashMessage.Location = new System.Drawing.Point(3, 53);
            this.StashMessage.Name = "StashMessage";
            this.StashMessage.ReadOnly = true;
            this.StashMessage.Size = new System.Drawing.Size(374, 44);
            this.StashMessage.TabIndex = 3;
            this.StashMessage.Text = "";
            this.StashMessage.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.StashMessage_MouseDoubleClick);
            // 
            // panel1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.Loading);
            this.panel1.Controls.Add(this.Stashed);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 414);
            this.panel1.TabIndex = 4;
            // 
            // Loading
            // 
            this.Loading.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Loading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Loading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Loading.Location = new System.Drawing.Point(0, 0);
            this.Loading.Name = "Loading";
            this.Loading.Size = new System.Drawing.Size(374, 414);
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
            this.Stashed.Size = new System.Drawing.Size(374, 414);
            this.Stashed.TabIndex = 2;
            this.Stashed.SelectedIndexChanged += new System.EventHandler(this.StashedSelectedIndexChanged);
            // 
            // View
            // 
            this.View.Dock = System.Windows.Forms.DockStyle.Fill;
            this.View.Location = new System.Drawing.Point(0, 0);
            this.View.Margin = new System.Windows.Forms.Padding(4);
            this.View.Name = "View";
            this.View.Size = new System.Drawing.Size(324, 520);
            this.View.TabIndex = 0;
            // 
            // FormStash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(708, 520);
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
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox Stashes;
        private PictureBox Loading;
        private CheckBox StashKeepIndex;
        private ToolStripButton toolStripButton_customMessage;
        private CheckBox chkIncludeUntrackedFiles;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel1;
        private ToolTip toolTip;
        private ToolStripButton Stash;
        private ToolStripButton Clear;
        private ToolStripButton Apply;
    }
}