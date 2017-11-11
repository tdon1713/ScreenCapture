using System;
using System.Configuration;
using System.Windows.Forms;

namespace ScreenCapture
{
    public partial class frmSettings : Form
    {
        public Action CompletionMethod { get; set; } = null;

        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            txtSaveLocation.Text = ConfigurationManager.AppSettings[Constants.SettingsKey.SaveLocation];
            txtArchiveLocation.Text = ConfigurationManager.AppSettings[Constants.SettingsKey.ArchiveLocation];
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SettingsManager.AddOrUpdateAppSettings(Constants.SettingsKey.ArchiveLocation, txtArchiveLocation.Text.Trim());
            SettingsManager.AddOrUpdateAppSettings(Constants.SettingsKey.SaveLocation, txtSaveLocation.Text.Trim());
            CompletionMethod?.Invoke();

            Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
