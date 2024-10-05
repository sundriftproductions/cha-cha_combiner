namespace ChaChaCombiner
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnClearSelected;
        private System.Windows.Forms.Button btnProcessAll;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ListBox lbImages;

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            btnAddImage = new Button();
            btnClearAll = new Button();
            btnClearSelected = new Button();
            btnProcessAll = new Button();
            btnCancel = new Button();
            lbImages = new ListBox();
            txtOutputDirectory = new TextBox();
            lblOutputDirectory = new Label();
            radInputLeftImageInChaCha = new RadioButton();
            radInput2DImage = new RadioButton();
            grpImageInputFormat = new GroupBox();
            pbHelp2DImage = new PictureBox();
            btnOutputDirectory = new Button();
            ssStatus = new StatusStrip();
            tsslStatus = new ToolStripStatusLabel();
            pbPrefs = new PictureBox();
            pbPrefsLight = new PictureBox();
            toolTip = new ToolTip(components);
            pbHelpProcessAll = new PictureBox();
            grpImageInputFormat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbHelp2DImage).BeginInit();
            ssStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPrefs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPrefsLight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbHelpProcessAll).BeginInit();
            SuspendLayout();
            // 
            // btnAddImage
            // 
            btnAddImage.Location = new Point(12, 114);
            btnAddImage.Name = "btnAddImage";
            btnAddImage.Size = new Size(139, 32);
            btnAddImage.TabIndex = 3;
            btnAddImage.Text = "&Add Image";
            btnAddImage.UseVisualStyleBackColor = true;
            btnAddImage.Click += btnAddImage_Click;
            // 
            // btnClearAll
            // 
            btnClearAll.Location = new Point(12, 190);
            btnClearAll.Name = "btnClearAll";
            btnClearAll.Size = new Size(139, 32);
            btnClearAll.TabIndex = 5;
            btnClearAll.Text = "Cl&ear All";
            btnClearAll.UseVisualStyleBackColor = true;
            btnClearAll.Click += btnClearAll_Click;
            // 
            // btnClearSelected
            // 
            btnClearSelected.Location = new Point(12, 152);
            btnClearSelected.Name = "btnClearSelected";
            btnClearSelected.Size = new Size(139, 32);
            btnClearSelected.TabIndex = 4;
            btnClearSelected.Text = "&Clear Selected";
            btnClearSelected.UseVisualStyleBackColor = true;
            btnClearSelected.Click += btnClearSelected_Click;
            // 
            // btnProcessAll
            // 
            btnProcessAll.Location = new Point(270, 468);
            btnProcessAll.Name = "btnProcessAll";
            btnProcessAll.Size = new Size(139, 36);
            btnProcessAll.TabIndex = 10;
            btnProcessAll.Text = "&Process All";
            btnProcessAll.UseVisualStyleBackColor = true;
            btnProcessAll.Click += btnProcessAll_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(478, 468);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(139, 36);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lbImages
            // 
            lbImages.FormattingEnabled = true;
            lbImages.Location = new Point(157, 114);
            lbImages.Name = "lbImages";
            lbImages.SelectionMode = SelectionMode.MultiExtended;
            lbImages.Size = new Size(630, 284);
            lbImages.TabIndex = 6;
            // 
            // txtOutputDirectory
            // 
            txtOutputDirectory.Location = new Point(157, 413);
            txtOutputDirectory.Name = "txtOutputDirectory";
            txtOutputDirectory.Size = new Size(591, 27);
            txtOutputDirectory.TabIndex = 8;
            // 
            // lblOutputDirectory
            // 
            lblOutputDirectory.AutoSize = true;
            lblOutputDirectory.Location = new Point(21, 416);
            lblOutputDirectory.Name = "lblOutputDirectory";
            lblOutputDirectory.Size = new Size(123, 20);
            lblOutputDirectory.TabIndex = 7;
            lblOutputDirectory.Text = "&Output Directory:";
            // 
            // radInputLeftImageInChaCha
            // 
            radInputLeftImageInChaCha.AutoSize = true;
            radInputLeftImageInChaCha.Checked = true;
            radInputLeftImageInChaCha.Location = new Point(6, 26);
            radInputLeftImageInChaCha.Name = "radInputLeftImageInChaCha";
            radInputLeftImageInChaCha.Size = new Size(189, 24);
            radInputLeftImageInChaCha.TabIndex = 1;
            radInputLeftImageInChaCha.TabStop = true;
            radInputLeftImageInChaCha.Text = "&Left Image in a Cha-Cha";
            radInputLeftImageInChaCha.UseVisualStyleBackColor = true;
            // 
            // radInput2DImage
            // 
            radInput2DImage.AutoSize = true;
            radInput2DImage.Location = new Point(6, 56);
            radInput2DImage.Name = "radInput2DImage";
            radInput2DImage.Size = new Size(370, 24);
            radInput2DImage.TabIndex = 2;
            radInput2DImage.Text = "&2D Image (which needs to be autoconverted to 3D)";
            radInput2DImage.UseVisualStyleBackColor = true;
            // 
            // grpImageInputFormat
            // 
            grpImageInputFormat.Controls.Add(pbHelp2DImage);
            grpImageInputFormat.Controls.Add(radInput2DImage);
            grpImageInputFormat.Controls.Add(radInputLeftImageInChaCha);
            grpImageInputFormat.Location = new Point(157, 12);
            grpImageInputFormat.Name = "grpImageInputFormat";
            grpImageInputFormat.Size = new Size(630, 96);
            grpImageInputFormat.TabIndex = 0;
            grpImageInputFormat.TabStop = false;
            grpImageInputFormat.Text = "Input Image Format";
            // 
            // pbHelp2DImage
            // 
            pbHelp2DImage.BackgroundImage = (Image)resources.GetObject("pbHelp2DImage.BackgroundImage");
            pbHelp2DImage.BackgroundImageLayout = ImageLayout.Stretch;
            pbHelp2DImage.Location = new Point(382, 60);
            pbHelp2DImage.Name = "pbHelp2DImage";
            pbHelp2DImage.Size = new Size(20, 20);
            pbHelp2DImage.TabIndex = 21;
            pbHelp2DImage.TabStop = false;
            toolTip.SetToolTip(pbHelp2DImage, "You must have the nunif-prompt.bat path set in order to convert images to 3D. Click the gear icon for more information.");
            // 
            // btnOutputDirectory
            // 
            btnOutputDirectory.Location = new Point(754, 408);
            btnOutputDirectory.Name = "btnOutputDirectory";
            btnOutputDirectory.Size = new Size(33, 36);
            btnOutputDirectory.TabIndex = 9;
            btnOutputDirectory.Text = "...";
            btnOutputDirectory.UseVisualStyleBackColor = true;
            btnOutputDirectory.Click += btnOutputDirectory_Click;
            // 
            // ssStatus
            // 
            ssStatus.ImageScalingSize = new Size(20, 20);
            ssStatus.Items.AddRange(new ToolStripItem[] { tsslStatus });
            ssStatus.Location = new Point(0, 542);
            ssStatus.Name = "ssStatus";
            ssStatus.Size = new Size(807, 22);
            ssStatus.TabIndex = 18;
            ssStatus.Text = "Test";
            // 
            // tsslStatus
            // 
            tsslStatus.Name = "tsslStatus";
            tsslStatus.Size = new Size(0, 16);
            // 
            // pbPrefs
            // 
            pbPrefs.BackgroundImage = (Image)resources.GetObject("pbPrefs.BackgroundImage");
            pbPrefs.BackgroundImageLayout = ImageLayout.Stretch;
            pbPrefs.Cursor = Cursors.Hand;
            pbPrefs.Location = new Point(761, 499);
            pbPrefs.Name = "pbPrefs";
            pbPrefs.Size = new Size(30, 30);
            pbPrefs.TabIndex = 19;
            pbPrefs.TabStop = false;
            toolTip.SetToolTip(pbPrefs, "Preferences");
            pbPrefs.Click += pbPrefs_Click;
            pbPrefs.MouseLeave += pbPrefs_MouseLeave;
            // 
            // pbPrefsLight
            // 
            pbPrefsLight.BackgroundImage = (Image)resources.GetObject("pbPrefsLight.BackgroundImage");
            pbPrefsLight.BackgroundImageLayout = ImageLayout.Stretch;
            pbPrefsLight.Cursor = Cursors.Hand;
            pbPrefsLight.Location = new Point(761, 499);
            pbPrefsLight.Name = "pbPrefsLight";
            pbPrefsLight.Size = new Size(30, 30);
            pbPrefsLight.TabIndex = 20;
            pbPrefsLight.TabStop = false;
            pbPrefsLight.MouseEnter += pbPrefsLight_MouseEnter;
            // 
            // pbHelpProcessAll
            // 
            pbHelpProcessAll.BackgroundImage = (Image)resources.GetObject("pbHelpProcessAll.BackgroundImage");
            pbHelpProcessAll.BackgroundImageLayout = ImageLayout.Stretch;
            pbHelpProcessAll.Location = new Point(415, 476);
            pbHelpProcessAll.Name = "pbHelpProcessAll";
            pbHelpProcessAll.Size = new Size(20, 20);
            pbHelpProcessAll.TabIndex = 22;
            pbHelpProcessAll.TabStop = false;
            toolTip.SetToolTip(pbHelpProcessAll, "You must have the StereoAutoAlign.exe path set in order to process images with Cha-Cha Converter. Click the gear icon for more information.");
            // 
            // frmMain
            // 
            ClientSize = new Size(807, 564);
            Controls.Add(pbHelpProcessAll);
            Controls.Add(pbPrefsLight);
            Controls.Add(pbPrefs);
            Controls.Add(ssStatus);
            Controls.Add(btnOutputDirectory);
            Controls.Add(grpImageInputFormat);
            Controls.Add(lblOutputDirectory);
            Controls.Add(txtOutputDirectory);
            Controls.Add(lbImages);
            Controls.Add(btnCancel);
            Controls.Add(btnProcessAll);
            Controls.Add(btnClearSelected);
            Controls.Add(btnClearAll);
            Controls.Add(btnAddImage);
            Cursor = Cursors.Hand;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmMain";
            Text = "Cha-Cha Combiner";
            FormClosing += Form1_FormClosing;
            Load += frmMain_Load;
            grpImageInputFormat.ResumeLayout(false);
            grpImageInputFormat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbHelp2DImage).EndInit();
            ssStatus.ResumeLayout(false);
            ssStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbPrefs).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPrefsLight).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbHelpProcessAll).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox txtOutputDirectory;
        private Label lblOutputDirectory;
        private RadioButton radInputLeftImageInChaCha;
        private RadioButton radInput2DImage;
        private GroupBox grpImageInputFormat;
        private Button btnOutputDirectory;
        private StatusStrip ssStatus;
        private ToolStripStatusLabel tsslStatus;
        private PictureBox pbPrefs;
        private PictureBox pbPrefsLight;
        private ToolTip toolTip;
        private PictureBox pbHelp2DImage;
        private PictureBox pbHelpProcessAll;
    }
}
