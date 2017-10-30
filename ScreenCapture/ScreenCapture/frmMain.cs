using System;
using System.Collections;
using System.Collections.Generic;
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
            fswCaptures.Path = Constants.FileSaveLocation;

            List<string> _currentFiles = new List<string>();

            Task.Run(() =>
            {
                _currentFiles.AddRange(Directory.EnumerateFiles(Constants.FileSaveLocation).Select(x => x));

            }).ContinueWith((continueWith) =>
            {
                if (continueWith.Status != TaskStatus.RanToCompletion)
                {
                    return;
                }

                IEnumerable<ListViewItem> items = _currentFiles.Select(x => genNewListItem(x));

                this.Invoke((MethodInvoker)delegate
                {
                    lstFiles.Items.AddRange(items.Where(x => (x as ListViewItem).SubItems[0].Text.ToLower() != AppDomain.CurrentDomain.FriendlyName.ToLower()).ToArray());
                });
            });
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

        #region Menu Events

        private void openPrimaryCaptureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCapture capture = new frmCapture();
            capture.Show();
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

        #endregion
    }
}
