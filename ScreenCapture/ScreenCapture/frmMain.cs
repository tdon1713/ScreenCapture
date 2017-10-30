﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCapture
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadImagesFromPath();
        }

        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFiles.SelectedIndices.Count == 0)
            {
                picPreview.Image = null;
                return;
            }

            picPreview.SizeMode = PictureBoxSizeMode.Zoom;
            picPreview.ImageLocation = lstFiles.SelectedItems[0].Tag.ToString();
        }

        private void lstFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenSelectedInPaint();
        }

        private void lstFiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteSelectedImage();
            }
        }

        #region Menu Events

        private void caputreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCustomDialog<frmCapture>();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCustomDialog<frmSettings>(LoadImagesFromPath);
        }

        #endregion

        #region Selected Image Events

        private void btnDeleteImage_Click(object sender, EventArgs e)
        {
            DeleteSelectedImage();
        }

        private void btnOpenImage_Click(object sender, EventArgs e)
        {
            OpenSelectedInPaint();
        }

        #endregion

        #region File Watcher Events

        private void fswCaptures_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            lstFiles.Items.Add(genNewListItem(e.FullPath));
        }

        private void fswCaptures_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {
            lstFiles.Items.Remove(lstFiles.Items[e.Name]);
        }

        private void fswCaptures_Renamed(object sender, System.IO.RenamedEventArgs e)
        {
            if (lstFiles.SelectedItems.Count > 0)
            {
                if (lstFiles.SelectedItems[0] == lstFiles.Items[e.OldName])
                {
                    lstFiles.SelectedItems[0].Selected = false;
                }
            }

            lstFiles.Items[e.OldName].SubItems[0].Text = e.Name;
            lstFiles.Items[e.OldName].SubItems[1].Text = e.FullPath;
            lstFiles.Items[e.OldName].Tag = e.FullPath;
            lstFiles.Items[e.OldName].Name = e.Name;
        }

        #endregion

        #region Private Methods

        public void LoadImagesFromPath()
        {
            if (!Directory.Exists(ConfigurationManager.AppSettings[Constants.SettingsKey.SaveLocation]))
            {
                return; 
            }

            fswCaptures.Path = ConfigurationManager.AppSettings[Constants.SettingsKey.SaveLocation];

            List<string> _currentFiles = new List<string>();

            Task.Run(() =>
            {
                _currentFiles.AddRange(Directory.EnumerateFiles(ConfigurationManager.AppSettings[Constants.SettingsKey.SaveLocation]).Select(x => x));

            }).ContinueWith((continueWith) =>
            {
                if (continueWith.Status != TaskStatus.RanToCompletion)
                {
                    return;
                }

                IEnumerable<ListViewItem> items = _currentFiles.Select(x => genNewListItem(x));

                this.Invoke((MethodInvoker)delegate
                {
                    lstFiles.Items.Clear();
                    picPreview.Image = null;
                    lstFiles.Items.AddRange(items.Where(x => (x as ListViewItem).SubItems[0].Text.ToLower() != AppDomain.CurrentDomain.FriendlyName.ToLower()).ToArray());
                });
            });
        }

        private void DeleteSelectedImage()
        {
            if (lstFiles.SelectedIndices.Count == 0)
            {
                return;
            }

            DialogResult result = MessageBox.Show($"Are you sure you want to delete {lstFiles.SelectedItems[0].SubItems[0].Text}?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.No)
            {
                return;
            }

            File.Delete(lstFiles.SelectedItems[0].Tag.ToString());
        }

        private ListViewItem genNewListItem(string filePath)
        {
            FileInfo info = new FileInfo(filePath);
            ListViewItem item = new ListViewItem(new string[]
            {
                info.Name,
                info.FullName
            });

            item.Tag = info.FullName;
            item.Name = info.Name;

            return item;
        }

        private void OpenSelectedInPaint()
        {
            if (lstFiles.SelectedIndices.Count == 0)
            {
                return;
            }

            Clipboard.SetText(lstFiles.SelectedItems[0].Tag.ToString());
            ProcessStartInfo startInfo = new ProcessStartInfo(lstFiles.SelectedItems[0].Tag.ToString());
            startInfo.Verb = "edit";

            Process.Start(startInfo);
        }

        private void OpenCustomDialog<T>(Action completionMethod = null) where T : Form, new()
        {
            T frmToShow = new T();
            if (frmToShow is frmSettings)
            {
                (frmToShow as frmSettings).CompletionMethod = completionMethod;
            }

            frmToShow.StartPosition = FormStartPosition.Manual;
            frmToShow.Location = new Point(Location.X + 15, Location.Y + 15);
            frmToShow.Width = Width - 30;
            frmToShow.Height = Height - 30;
            frmToShow.ShowDialog(this);
        }

        #endregion
    }
}
