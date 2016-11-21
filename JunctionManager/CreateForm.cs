﻿using Monitor.Core.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JunctionManager {
    public partial class CreateForm : Form {
        public CreateForm() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            //Start the folder browser with the new folder button enabled
            folderBrowserDialog1.ShowNewFolderButton = true;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                junctionTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void targetBrowseButton_Click(object sender, EventArgs e) {
            //Start the folder browser with the new folder button enabled
            folderBrowserDialog1.ShowNewFolderButton = true;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                targetTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void createButton_Click(object sender, EventArgs e) {
            string origin = junctionTextBox.Text;
            string target = targetTextBox.Text;
            if (origin.Length == 0) {
                ActiveControl = junctionTextBox;
                System.Media.SystemSounds.Exclamation.Play();
                return;
            } else if (target.Length == 0) {
                ActiveControl = targetTextBox;
                System.Media.SystemSounds.Exclamation.Play();
                return;
            }

            if (!Directory.Exists(target)) {
                DialogResult recursionCaution = MessageBox.Show("There is no folder at " + target + ", please select a folder that the junction can target", "Folder doesn't exist", MessageBoxButtons.OK);
            }

            JunctionPoint.Create(origin, target, true);

            SQLiteManager.AddJunction(origin, target);
        }
    }
}
