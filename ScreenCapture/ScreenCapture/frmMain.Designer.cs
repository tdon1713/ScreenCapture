namespace ScreenCapture
{
    partial class frmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openPrimaryCaptureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fswCaptures = new System.IO.FileSystemWatcher();
            this.lstFiles = new System.Windows.Forms.ListView();
            this.filesHeaderFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.filesHeaderFullName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fswCaptures)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openPrimaryCaptureToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openPrimaryCaptureToolStripMenuItem
            // 
            this.openPrimaryCaptureToolStripMenuItem.Name = "openPrimaryCaptureToolStripMenuItem";
            this.openPrimaryCaptureToolStripMenuItem.Size = new System.Drawing.Size(137, 20);
            this.openPrimaryCaptureToolStripMenuItem.Text = "Open Primary Capture";
            this.openPrimaryCaptureToolStripMenuItem.Click += new System.EventHandler(this.openPrimaryCaptureToolStripMenuItem_Click);
            // 
            // fswCaptures
            // 
            this.fswCaptures.EnableRaisingEvents = true;
            this.fswCaptures.SynchronizingObject = this;
            this.fswCaptures.Created += new System.IO.FileSystemEventHandler(this.fswCaptures_Created);
            this.fswCaptures.Deleted += new System.IO.FileSystemEventHandler(this.fswCaptures_Deleted);
            this.fswCaptures.Renamed += new System.IO.RenamedEventHandler(this.fswCaptures_Renamed);
            // 
            // lstFiles
            // 
            this.lstFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(38)))), ((int)(((byte)(57)))));
            this.lstFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.filesHeaderFileName,
            this.filesHeaderFullName});
            this.lstFiles.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFiles.ForeColor = System.Drawing.Color.White;
            this.lstFiles.FullRowSelect = true;
            this.lstFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstFiles.Location = new System.Drawing.Point(0, 24);
            this.lstFiles.MultiSelect = false;
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(514, 657);
            this.lstFiles.TabIndex = 1;
            this.lstFiles.UseCompatibleStateImageBehavior = false;
            this.lstFiles.View = System.Windows.Forms.View.Details;
            this.lstFiles.SelectedIndexChanged += new System.EventHandler(this.lstFiles_SelectedIndexChanged);
            this.lstFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstFiles_MouseDoubleClick);
            // 
            // filesHeaderFileName
            // 
            this.filesHeaderFileName.Text = "Name";
            this.filesHeaderFileName.Width = 300;
            // 
            // filesHeaderFullName
            // 
            this.filesHeaderFullName.Text = "Full Name";
            this.filesHeaderFullName.Width = 200;
            // 
            // picPreview
            // 
            this.picPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPreview.Location = new System.Drawing.Point(0, 0);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(750, 657);
            this.picPreview.TabIndex = 2;
            this.picPreview.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picPreview);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(514, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 657);
            this.panel1.TabIndex = 3;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(38)))), ((int)(((byte)(57)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Capture - Main";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fswCaptures)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openPrimaryCaptureToolStripMenuItem;
        private System.IO.FileSystemWatcher fswCaptures;
        private System.Windows.Forms.ListView lstFiles;
        private System.Windows.Forms.ColumnHeader filesHeaderFileName;
        private System.Windows.Forms.ColumnHeader filesHeaderFullName;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Panel panel1;
    }
}