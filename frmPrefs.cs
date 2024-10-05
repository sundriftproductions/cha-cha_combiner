using System.Diagnostics;

namespace ChaChaCombiner
{
    public partial class frmPrefs : Form
    {
        public string StereoAutoAlignEXEPath { get; set; }
        public string RawTherapeeCLIEXEPath { get; set; }
        public string NunifPromptBATPath { get; set; }


        public frmPrefs()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            txtStereoAutoAlignEXEPath.Text = StereoAutoAlignEXEPath;
            txtRawTherapeeCLIEXEPath.Text = RawTherapeeCLIEXEPath;
            txtNunifPromptBATPath.Text = NunifPromptBATPath;
        }


        private void GoToURL(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not open the website: " + ex.Message);
            }
        }

        private void llStereoPhotoMaker_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GoToURL("https://stereo.jpn.org/eng/stphmkr/");
        }

        private void llNUNIFIW3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GoToURL("https://github.com/nagadomi/nunif/blob/master/iw3/README.md");
        }

        private void llRawTherapee_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GoToURL("http://rawtherapee.com/");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Get the values from the text boxes and assign them to the properties.
            StereoAutoAlignEXEPath = txtStereoAutoAlignEXEPath.Text;
            RawTherapeeCLIEXEPath = txtRawTherapeeCLIEXEPath.Text;
            NunifPromptBATPath = txtNunifPromptBATPath.Text;

            // Close the form and indicate that the user clicked OK.
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnStereoAutoAlignEXEPath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Set the filter to only show .exe files
                openFileDialog.Filter = "Executable Files (*.exe)|*.exe";

                if (File.Exists(txtStereoAutoAlignEXEPath.Text))
                {
                    openFileDialog.InitialDirectory = Path.GetDirectoryName(txtStereoAutoAlignEXEPath.Text);
                }    

                // Show the dialog and check if a file is selected
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the full path of the selected file
                    txtStereoAutoAlignEXEPath.Text = openFileDialog.FileName;
                }
            }
        }

        private void btnNunifPromptBATPath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Set the filter to only show .exe files
                openFileDialog.Filter = "Batch Files (*.bat)|*.bat";

                if (File.Exists(txtNunifPromptBATPath.Text))
                {
                    openFileDialog.InitialDirectory = Path.GetDirectoryName(txtNunifPromptBATPath.Text);
                }

                // Show the dialog and check if a file is selected
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the full path of the selected file
                    txtNunifPromptBATPath.Text = openFileDialog.FileName;
                }
            }
        }

        private void btnRawTherapeeCLIEXEPath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Set the filter to only show .exe files
                openFileDialog.Filter = "Executable Files (*.exe)|*.exe";

                if (File.Exists(txtRawTherapeeCLIEXEPath.Text))
                {
                    openFileDialog.InitialDirectory = Path.GetDirectoryName(txtRawTherapeeCLIEXEPath.Text);
                }

                // Show the dialog and check if a file is selected
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the full path of the selected file
                    txtRawTherapeeCLIEXEPath.Text = openFileDialog.FileName;
                }
            }
        }
    }
}
