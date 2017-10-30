using System;
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

        private void button1_Click(object sender, EventArgs e)
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

                        screenCap.Save($"{Constants.FileSaveLocation}{DateTime.Now.Ticks}.png", ImageFormat.Png);
                    }
                }
            });
        }
    }
}
