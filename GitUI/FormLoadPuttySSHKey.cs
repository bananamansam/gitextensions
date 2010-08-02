﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using GitCommands.Repository;

namespace GitUI
{
    public partial class FormLoadPuttySSHKey : GitExtensionsForm
    {
        public FormLoadPuttySSHKey()
        {
            InitializeComponent(); Translate();
        }

        private void PrivateKeypath_DropDown(object sender, EventArgs e)
        {
            PrivateKeypath.DataSource = Repositories.RepositoryHistory.Repositories;
            PrivateKeypath.DisplayMember = "Path";

        }

        private void LoadSSHKey_Click(object sender, EventArgs e)
        {
            if (!File.Exists(GitCommands.Settings.Pageant))
                MessageBox.Show("Cannot load SSH key. PuTTY is not configured properly.", "PuTTY");
            else
            {
                Repositories.RepositoryHistory.AddMostRecentRepository(PrivateKeypath.Text);
                if (!string.IsNullOrEmpty(PrivateKeypath.Text))
                {
                    GitCommands.GitCommands.StartPageantWithKey(PrivateKeypath.Text);
                    Close();
                }
                else
                {
                    MessageBox.Show("Could not load key.", "PuTTY");
                }
            }
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Private key (*.ppk)|*.ppk";
            dialog.InitialDirectory = ".";
            dialog.Title = "Select ssh key file";
            if (dialog.ShowDialog() == DialogResult.OK)
                PrivateKeypath.Text = dialog.FileName;
        }
    }
}
