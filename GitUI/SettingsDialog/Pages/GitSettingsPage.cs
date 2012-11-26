﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using GitCommands;
using ResourceManager.Translation;

namespace GitUI.SettingsDialog.Pages
{
    public partial class GitSettingsPage : SettingsPageBase
    {
        private readonly TranslationString _homeIsSetToString = new TranslationString("HOME is set to:");

        ////CommonLogic _commonLogic;
        CheckSettingsLogic _checkSettingsLogic;

        public GitSettingsPage(
            ////CommonLogic commonLogic,
            CheckSettingsLogic checkSettingsLogic)
        {
            InitializeComponent();

            ////_commonLogic = commonLogic;
            _checkSettingsLogic = checkSettingsLogic;

            Text = "Git";
        }

        public override void RefreshView()
        {
            GitPath.Text = Settings.GitCommand;
        }

        public override void LoadSettings()
        {
            GitCommandHelpers.SetEnvironmentVariable();
            homeIsSetToLabel.Text = string.Concat(_homeIsSetToString.Text, " ", GitCommandHelpers.GetHomeDir());

            GitPath.Text = Settings.GitCommand;
            GitBinPath.Text = Settings.GitBinDir;
        }

        public override void SaveSettings()
        {
            Settings.GitCommand = GitPath.Text;
            Settings.GitBinDir = GitBinPath.Text;
        }

        private void BrowseGitPath_Click(object sender, EventArgs e)
        {
            _checkSettingsLogic.SolveGitCommand();

            using (var browseDialog = new OpenFileDialog
            {
                FileName = Settings.GitCommand,
                Filter = "Git.cmd (git.cmd)|git.cmd|Git.exe (git.exe)|git.exe|Git (git)|git"
            })
            {

                if (browseDialog.ShowDialog(this) == DialogResult.OK)
                {
                    GitPath.Text = browseDialog.FileName;
                }
            }
        }

        private void BrowseGitBinPath_Click(object sender, EventArgs e)
        {
            _checkSettingsLogic.SolveLinuxToolsDir();

            using (var browseDialog = new FolderBrowserDialog { SelectedPath = Settings.GitBinDir })
            {

                if (browseDialog.ShowDialog(this) == DialogResult.OK)
                {
                    GitBinPath.Text = browseDialog.SelectedPath;
                }
            }
        }

        private void GitPath_TextChanged(object sender, EventArgs e)
        {
            // TODO
            ////if (loadingSettings)
            ////    return;

            Settings.GitCommand = GitPath.Text;
            LoadSettings();
        }

        private void downloadMsysgit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"http://msysgit.github.com/");
        }

        private void ChangeHomeButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException(@"
            Save();
            using (var frm = new FormFixHome()) frm.ShowDialog(this);
            LoadSettings();
            Rescan_Click(null, null);
            ");
        }
    }
}
