﻿using Monitor.Core.Utilities;
using System;
using System.IO;
using System.Windows.Forms;

namespace JunctionManager {
    class Program {

        [STAThread]
        static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length == 0) {
                Application.Run(new ConfigurationForm());
            } else {
                Application.Run(new TransferForm(args[0]));
            }
        }

        static public String GetOtherDiskPath(String path) {
            return Properties.Settings.Default.StorageLocation + path.Substring(2, path.Length - 2);
        }

        static public void CopyFolder(string sourceFolder, string destFolder) {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);
            string[] files = Directory.GetFiles(sourceFolder);
            foreach (string file in files) {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                File.Copy(file, dest);
            }
            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders) {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyFolder(folder, dest);
            }
        }
    }
}
