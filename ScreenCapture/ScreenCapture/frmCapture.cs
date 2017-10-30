using System;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCapture
{
    public partial class frmCapture : Form
    {
        public frmCapture()
        {
            InitializeComponent();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                using (Bitmap screenCap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(screenCap))
                    {
                        g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                            Screen.PrimaryScreen.Bounds.Y,
                            0, 0,
                            screenCap.Size,
                            CopyPixelOperation.SourceCopy);

                        screenCap.Save($"{ConfigurationManager.AppSettings[Constants.SettingsKey.SaveLocation]}{DateTime.Now.Ticks}.png", ImageFormat.Png);
                    }
                }
            });
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCapture_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
