namespace ChaChaCombiner
{
    partial class frmPrefs
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrefs));
            btnOK = new Button();
            btnCancel = new Button();
            btnStereoAutoAlignEXEPath = new Button();
            lblOutputDirectory = new Label();
            txtStereoAutoAlignEXEPath = new TextBox();
            btnRawTherapeeCLIEXEPath = new Button();
            label1 = new Label();
            txtRawTherapeeCLIEXEPath = new TextBox();
            btnNunifPromptBATPath = new Button();
            label2 = new Label();
            txtNunifPromptBATPath = new TextBox();
            lblInstructions = new Label();
            pbHelpStereoAutoAlignEXE = new PictureBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            toolTip1 = new ToolTip(components);
            llStereoPhotoMaker = new LinkLabel();
            llNUNIFIW3 = new LinkLabel();
            llRawTherapee = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pbHelpStereoAutoAlignEXE).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // btnOK
            // 
            btnOK.Location = new Point(595, 313);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(94, 29);
            btnOK.TabIndex = 0;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(695, 313);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnStereoAutoAlignEXEPath
            // 
            btnStereoAutoAlignEXEPath.Location = new Point(755, 106);
            btnStereoAutoAlignEXEPath.Name = "btnStereoAutoAlignEXEPath";
            btnStereoAutoAlignEXEPath.Size = new Size(33, 36);
            btnStereoAutoAlignEXEPath.TabIndex = 5;
            btnStereoAutoAlignEXEPath.Text = "...";
            btnStereoAutoAlignEXEPath.UseVisualStyleBackColor = true;
            btnStereoAutoAlignEXEPath.Click += btnStereoAutoAlignEXEPath_Click;
            // 
            // lblOutputDirectory
            // 
            lblOutputDirectory.AutoSize = true;
            lblOutputDirectory.Location = new Point(12, 88);
            lblOutputDirectory.Name = "lblOutputDirectory";
            lblOutputDirectory.Size = new Size(180, 20);
            lblOutputDirectory.TabIndex = 3;
            lblOutputDirectory.Text = "&StereoAutoAlign.exe Path:";
            // 
            // txtStereoAutoAlignEXEPath
            // 
            txtStereoAutoAlignEXEPath.Location = new Point(12, 111);
            txtStereoAutoAlignEXEPath.Name = "txtStereoAutoAlignEXEPath";
            txtStereoAutoAlignEXEPath.PlaceholderText = "C:\\Programs\\StereoPhoto Maker\\StereoAutoAlign.exe";
            txtStereoAutoAlignEXEPath.Size = new Size(737, 27);
            txtStereoAutoAlignEXEPath.TabIndex = 4;
            // 
            // btnRawTherapeeCLIEXEPath
            // 
            btnRawTherapeeCLIEXEPath.Location = new Point(755, 242);
            btnRawTherapeeCLIEXEPath.Name = "btnRawTherapeeCLIEXEPath";
            btnRawTherapeeCLIEXEPath.Size = new Size(33, 36);
            btnRawTherapeeCLIEXEPath.TabIndex = 13;
            btnRawTherapeeCLIEXEPath.Text = "...";
            btnRawTherapeeCLIEXEPath.UseVisualStyleBackColor = true;
            btnRawTherapeeCLIEXEPath.Click += btnRawTherapeeCLIEXEPath_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 222);
            label1.Name = "label1";
            label1.Size = new Size(174, 20);
            label1.TabIndex = 11;
            label1.Text = "&rawtherapee-cli.exe Path:";
            // 
            // txtRawTherapeeCLIEXEPath
            // 
            txtRawTherapeeCLIEXEPath.Location = new Point(12, 247);
            txtRawTherapeeCLIEXEPath.Name = "txtRawTherapeeCLIEXEPath";
            txtRawTherapeeCLIEXEPath.PlaceholderText = "C:\\Program Files\\RawTherapee\\5.8\\rawtherapee-cli.exe";
            txtRawTherapeeCLIEXEPath.Size = new Size(737, 27);
            txtRawTherapeeCLIEXEPath.TabIndex = 12;
            // 
            // btnNunifPromptBATPath
            // 
            btnNunifPromptBATPath.Location = new Point(756, 176);
            btnNunifPromptBATPath.Name = "btnNunifPromptBATPath";
            btnNunifPromptBATPath.Size = new Size(33, 36);
            btnNunifPromptBATPath.TabIndex = 9;
            btnNunifPromptBATPath.Text = "...";
            btnNunifPromptBATPath.UseVisualStyleBackColor = true;
            btnNunifPromptBATPath.Click += btnNunifPromptBATPath_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 158);
            label2.Name = "label2";
            label2.Size = new Size(158, 20);
            label2.TabIndex = 7;
            label2.Text = "&nunif-prompt.bat Path:";
            // 
            // txtNunifPromptBATPath
            // 
            txtNunifPromptBATPath.Location = new Point(13, 181);
            txtNunifPromptBATPath.Name = "txtNunifPromptBATPath";
            txtNunifPromptBATPath.PlaceholderText = "C:\\Programs\\nunif-windows\\nunif-prompt.bat";
            txtNunifPromptBATPath.Size = new Size(737, 27);
            txtNunifPromptBATPath.TabIndex = 8;
            // 
            // lblInstructions
            // 
            lblInstructions.Location = new Point(13, 10);
            lblInstructions.Name = "lblInstructions";
            lblInstructions.Size = new Size(776, 49);
            lblInstructions.TabIndex = 19;
            lblInstructions.Text = "Cha-Cha Combiner relies upon several other free software applications. This screen tells Cha-Cha Combiner where to find that software on your computer.";
            // 
            // pbHelpStereoAutoAlignEXE
            // 
            pbHelpStereoAutoAlignEXE.BackgroundImage = (Image)resources.GetObject("pbHelpStereoAutoAlignEXE.BackgroundImage");
            pbHelpStereoAutoAlignEXE.BackgroundImageLayout = ImageLayout.Stretch;
            pbHelpStereoAutoAlignEXE.Location = new Point(198, 88);
            pbHelpStereoAutoAlignEXE.Name = "pbHelpStereoAutoAlignEXE";
            pbHelpStereoAutoAlignEXE.Size = new Size(20, 20);
            pbHelpStereoAutoAlignEXE.TabIndex = 20;
            pbHelpStereoAutoAlignEXE.TabStop = false;
            toolTip1.SetToolTip(pbHelpStereoAutoAlignEXE, "This file is installed with StereoPhoto Maker. This is a required file for Cha-Cha Combiner.");
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(192, 222);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(20, 20);
            pictureBox1.TabIndex = 21;
            pictureBox1.TabStop = false;
            toolTip1.SetToolTip(pictureBox1, "This file is installed with RawTherapee. It is only required if you wish to open Canon .CR2 RAW files in Cha-Cha Combiner.");
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(176, 158);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(20, 20);
            pictureBox2.TabIndex = 22;
            pictureBox2.TabStop = false;
            toolTip1.SetToolTip(pictureBox2, "This is a file that is installed with NUNIF/IW3. This is only required if you wish to autoconvert 2D images to 3D.");
            // 
            // llStereoPhotoMaker
            // 
            llStereoPhotoMaker.AutoSize = true;
            llStereoPhotoMaker.Location = new Point(540, 88);
            llStereoPhotoMaker.Name = "llStereoPhotoMaker";
            llStereoPhotoMaker.Size = new Size(209, 20);
            llStereoPhotoMaker.TabIndex = 2;
            llStereoPhotoMaker.TabStop = true;
            llStereoPhotoMaker.Text = "Download StereoPhoto Maker";
            llStereoPhotoMaker.TextAlign = ContentAlignment.TopRight;
            llStereoPhotoMaker.LinkClicked += llStereoPhotoMaker_LinkClicked;
            // 
            // llNUNIFIW3
            // 
            llNUNIFIW3.AutoSize = true;
            llNUNIFIW3.Location = new Point(592, 158);
            llNUNIFIW3.Name = "llNUNIFIW3";
            llNUNIFIW3.Size = new Size(157, 20);
            llNUNIFIW3.TabIndex = 6;
            llNUNIFIW3.TabStop = true;
            llNUNIFIW3.Text = "Download NUNIF/IW3";
            llNUNIFIW3.TextAlign = ContentAlignment.TopRight;
            llNUNIFIW3.LinkClicked += llNUNIFIW3_LinkClicked;
            // 
            // llRawTherapee
            // 
            llRawTherapee.AutoSize = true;
            llRawTherapee.Location = new Point(574, 224);
            llRawTherapee.Name = "llRawTherapee";
            llRawTherapee.Size = new Size(172, 20);
            llRawTherapee.TabIndex = 10;
            llRawTherapee.TabStop = true;
            llRawTherapee.Text = "Download RawTherapee";
            llRawTherapee.TextAlign = ContentAlignment.TopRight;
            llRawTherapee.LinkClicked += llRawTherapee_LinkClicked;
            // 
            // frmPrefs
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(800, 354);
            Controls.Add(llRawTherapee);
            Controls.Add(llNUNIFIW3);
            Controls.Add(llStereoPhotoMaker);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(pbHelpStereoAutoAlignEXE);
            Controls.Add(lblInstructions);
            Controls.Add(btnNunifPromptBATPath);
            Controls.Add(label2);
            Controls.Add(txtNunifPromptBATPath);
            Controls.Add(btnRawTherapeeCLIEXEPath);
            Controls.Add(label1);
            Controls.Add(txtRawTherapeeCLIEXEPath);
            Controls.Add(btnStereoAutoAlignEXEPath);
            Controls.Add(lblOutputDirectory);
            Controls.Add(txtStereoAutoAlignEXEPath);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmPrefs";
            Text = "Preferences";
            ((System.ComponentModel.ISupportInitialize)pbHelpStereoAutoAlignEXE).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOK;
        private Button btnCancel;
        private Button btnStereoAutoAlignEXEPath;
        private Label lblOutputDirectory;
        private TextBox txtStereoAutoAlignEXEPath;
        private Button btnRawTherapeeCLIEXEPath;
        private Label label1;
        private TextBox txtRawTherapeeCLIEXEPath;
        private Button btnNunifPromptBATPath;
        private Label label2;
        private TextBox txtNunifPromptBATPath;
        private Label lblInstructions;
        private PictureBox pbHelpStereoAutoAlignEXE;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private ToolTip toolTip1;
        private LinkLabel llStereoPhotoMaker;
        private LinkLabel llNUNIFIW3;
        private LinkLabel llRawTherapee;
    }
}