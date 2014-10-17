namespace GitUI.CommandsDialogs.SettingsDialog.Pages
{
    partial class StashDialogSettingsPage
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
            this.label1 = new System.Windows.Forms.Label();
            this.rbWorkingDirectoryChanges = new System.Windows.Forms.RadioButton();
            this.rbMostRecentStash = new System.Windows.Forms.RadioButton();
            this.groupBoxBehaviour.SuspendLayout();
            this.tableLayoutPanelBehaviour.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxBehaviour
            // 
            this.groupBoxBehaviour.AutoSize = true;
            this.groupBoxBehaviour.Controls.Add(this.tableLayoutPanelBehaviour);
            this.groupBoxBehaviour.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxBehaviour.Location = new System.Drawing.Point(0, 0);
            this.groupBoxBehaviour.Name = "groupBoxBehaviour";
            this.groupBoxBehaviour.Size = new System.Drawing.Size(1402, 47);
            this.groupBoxBehaviour.TabIndex = 56;
            this.groupBoxBehaviour.TabStop = false;
            this.groupBoxBehaviour.Text = "Behaviour";
            // 
            // tableLayoutPanelBehaviour
            // 
            this.tableLayoutPanelBehaviour.AutoSize = true;
            this.tableLayoutPanelBehaviour.ColumnCount = 3;
            this.tableLayoutPanelBehaviour.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.tableLayoutPanelBehaviour.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBehaviour.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBehaviour.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanelBehaviour.Controls.Add(this.rbWorkingDirectoryChanges, 1, 0);
            this.tableLayoutPanelBehaviour.Controls.Add(this.rbMostRecentStash, 2, 0);
            this.tableLayoutPanelBehaviour.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelBehaviour.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanelBehaviour.Name = "tableLayoutPanelBehaviour";
            this.tableLayoutPanelBehaviour.RowCount = 6;
            this.tableLayoutPanelBehaviour.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBehaviour.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBehaviour.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBehaviour.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBehaviour.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBehaviour.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBehaviour.Size = new System.Drawing.Size(1396, 25);
            this.tableLayoutPanelBehaviour.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 25);
            this.label1.TabIndex = 57;
            this.label1.Text = "Default Selected Stash";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbWorkingDirectoryChanges
            // 
            this.rbWorkingDirectoryChanges.AutoSize = true;
            this.rbWorkingDirectoryChanges.Location = new System.Drawing.Point(148, 3);
            this.rbWorkingDirectoryChanges.Name = "rbWorkingDirectoryChanges";
            this.rbWorkingDirectoryChanges.Size = new System.Drawing.Size(170, 19);
            this.rbWorkingDirectoryChanges.TabIndex = 1;
            this.rbWorkingDirectoryChanges.TabStop = true;
            this.rbWorkingDirectoryChanges.Text = "Working Directory Changes";
            this.rbWorkingDirectoryChanges.UseVisualStyleBackColor = true;
            // 
            // rbMostRecentStash
            // 
            this.rbMostRecentStash.AutoSize = true;
            this.rbMostRecentStash.Location = new System.Drawing.Point(324, 3);
            this.rbMostRecentStash.Name = "rbMostRecentStash";
            this.rbMostRecentStash.Size = new System.Drawing.Size(122, 19);
            this.rbMostRecentStash.TabIndex = 2;
            this.rbMostRecentStash.TabStop = true;
            this.rbMostRecentStash.Text = "Most Recent Stash";
            this.rbMostRecentStash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbMostRecentStash.UseVisualStyleBackColor = true;
            // 
            // StashDialogSettingsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.Controls.Add(this.groupBoxBehaviour);
            this.Name = "StashDialogSettingsPage";
            this.Size = new System.Drawing.Size(1402, 871);
            this.groupBoxBehaviour.ResumeLayout(false);
            this.groupBoxBehaviour.PerformLayout();
            this.tableLayoutPanelBehaviour.ResumeLayout(false);
            this.tableLayoutPanelBehaviour.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxBehaviour;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBehaviour;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbWorkingDirectoryChanges;
        private System.Windows.Forms.RadioButton rbMostRecentStash;
    }
}
