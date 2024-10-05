using System.Diagnostics;

namespace ChaChaCombiner
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// The sidecar template file that is required for converting Canon CR2 (RAW) files to PNG through RawTherapee.
        /// </summary>
        private const string FILENAME_RAWTHERAPEE_SIDECAR_TEMPLATE_5D = "template_5D.CR2.pp3";

        /// <summary>
        /// The location of the RawTherapee command line interface EXE.
        /// </summary>
        /// <remarks>
        /// This is where this file exists on my computer: C:\Program Files\RawTherapee\5.8\rawtherapee-cli.exe
        /// </remarks>
        private string _exeRawTherapeeCLI;

        /// <summary>
        /// The location of the StereoAutoAlign EXE file, which is bundled with StereoPhoto Maker.
        /// </summary>
        /// <remarks>
        /// This is where this file exists on my computer: C:\Programs\StereoPhoto Maker\StereoAutoAlign.exe
        /// </remarks>
        private string _exeStereoAutoAlign;

        /// <summary>
        /// The location of the nunif-prompt batch file. This is part of IW3 (technically, NUNIF).
        /// </summary>
        /// <remarks>
        /// This is where this file exists on my computer: C:\Programs\nunif-windows\nunif-prompt.bat
        /// </remarks>
        private string _batNunifPrompt;

        /// <summary>
        /// Where we store RawTherapee sidecar templates that Cha-Cha Combiner uses.
        /// </summary>
        private readonly string _directoryRawTherapeeSidecarTemplates;

        /// <summary>
        /// A flag to indicate whether the UI is intended to be enabled.
        /// </summary>
        private bool _uiEnabled;

        /// <summary>
        /// A CancellationTokenSource that helps us halt any command line process that is currently running.
        /// </summary>
        private CancellationTokenSource _cancellationTokenSource;

        /// <summary>
        /// The constructor.
        /// </summary>
        public frmMain()
        {
            _directoryRawTherapeeSidecarTemplates = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                                                 "support",
                                                                 "raw_therapee_sidecar_templates");
            InitializeComponent();
            LoadSettings();
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (File.Exists(_exeRawTherapeeCLI))
                {
                    // We have a path set for RawTherapee, so allow us to add CR2 files.
                    openFileDialog.Filter = "Image Files|*.CR2;*.png;*.tif;*.jpg";
                }
                else
                {
                    // We don't have a path set for RawTherapee, so do not allow us to add CR2 files.
                    openFileDialog.Filter = "Image Files|*.png;*.tif;*.jpg";
                }

                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (var file in openFileDialog.FileNames)
                    {
                        if (!lbImages.Items.Contains(file))
                        {
                            lbImages.Items.Add(file);
                        }
                    }
                    UpdateProcessAllButtonState();
                }
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            lbImages.Items.Clear();
            UpdateProcessAllButtonState();
        }

        private void btnClearSelected_Click(object sender, EventArgs e)
        {
            var selectedItems = lbImages.SelectedItems.Cast<string>().ToList();
            foreach (var item in selectedItems)
            {
                lbImages.Items.Remove(item);
            }
            UpdateProcessAllButtonState(); 
        }

        private void EnableUI(bool enable)
        {
            grpImageInputFormat.Enabled = enable;
            radInputLeftImageInChaCha.Enabled = enable;
            if (enable && !File.Exists(_batNunifPrompt)) 
            {
                radInput2DImage.Enabled = false;
                pbHelp2DImage.Visible = true;
            }
            else
            {
                radInput2DImage.Enabled = enable;
                toolTip.SetToolTip(radInput2DImage, string.Empty);
                pbHelp2DImage.Visible = false;
            }

            btnAddImage.Enabled = enable;
            btnClearSelected.Enabled = enable;
            btnClearAll.Enabled = enable;
            lbImages.Enabled = enable;
            txtOutputDirectory.Enabled = enable;
            btnOutputDirectory.Enabled = enable;
            if (enable && !File.Exists(_exeStereoAutoAlign))
            {
                btnProcessAll.Enabled = false;
                pbHelpProcessAll.Visible = true;
            }
            else
            {
                btnProcessAll.Enabled = enable && lbImages.Items.Count > 0;
                pbHelpProcessAll.Visible = false;
            }

            btnCancel.Enabled = !enable;
            _uiEnabled = enable;
        }

        private void UpdateProcessAllButtonState()
        {
            btnProcessAll.Enabled = lbImages.Items.Count > 0;
        }

        private async void btnProcessAll_Click(object sender, EventArgs e)
        {
            EnableUI(false);

            _cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = _cancellationTokenSource.Token;

            while (lbImages.Items.Count > 0)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        tsslStatus.Text = "Processing canceled.";
                        EnableUI(true);
                    });
                    return;
                }

                string file = null;

                // Invoke on the UI thread to safely access the ListBox and Label.
                this.Invoke((MethodInvoker)delegate
                {
                    file = lbImages.Items[0].ToString();
                    tsslStatus.Text = $"Processing: {file}";
                });

                await Task.Run(() => ProcessImage(file), cancellationToken);

                if (!cancellationToken.IsCancellationRequested)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        lbImages.Items.RemoveAt(0);
                    });
                }
            }

            this.Invoke((MethodInvoker)delegate
            {
                tsslStatus.Text = "All images processed.";
                MessageBox.Show("All images processed.");
                EnableUI(true);
            });
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                btnCancel.Enabled = false;
                tsslStatus.Text = "Please wait...";
            });

            _cancellationTokenSource?.Cancel();
        }

        private void ProcessImage(string selectedFile)
        {
            string directory = Path.GetDirectoryName(selectedFile);
            string extension = Path.GetExtension(selectedFile);
            string baseFileName = Path.GetFileNameWithoutExtension(selectedFile);
            string nextImagePath = string.Empty;

            if (radInputLeftImageInChaCha.Checked)
            {
                var files = Directory.GetFiles(directory, $"*{extension}")
                                     .OrderBy(f => f)
                                     .ToList();

                int index = files.IndexOf(selectedFile);
                if (index < 0 || index + 1 >= files.Count)
                {
                    MessageBox.Show($"Next image in sequence not found for {selectedFile}.");
                    return;
                }

                nextImagePath = files[index + 1];
            }

            string outputFilePath = Path.Combine(txtOutputDirectory.Text, $"{baseFileName}_SBS.png");

            if (radInputLeftImageInChaCha.Checked)
            {
                CreateStereoImageFromChaCha(selectedFile, nextImagePath, outputFilePath);
            }
            else // radInput2DImage.Checked
            {
                CreateStereoImageFromLeft2DImage(selectedFile, outputFilePath);
            }
        }

        private void CreateStereoImageFromChaCha(string leftImagePath, string rightImagePath, string outputImagePath)
        {
            if (Path.GetExtension(leftImagePath).ToUpperInvariant() == ".CR2" ||
                Path.GetExtension(rightImagePath).ToUpperInvariant() == ".CR2")
            {
                // We need to convert CR2 files into PNG files before we can run them through StereoPhotoMaker.
                // We need to use RawTherapee to do this.
                string tempDirectory = Path.Combine(Path.GetDirectoryName(outputImagePath), Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempDirectory);

                string directory = Path.GetDirectoryName(leftImagePath);
                string leftImagePP3 = Path.Combine(directory, $"{Path.GetFileName(leftImagePath)}.pp3");
                string rightImagePP3 = Path.Combine(directory, $"{Path.GetFileName(rightImagePath)}.pp3");
                string leftOutputPath = Path.Combine(tempDirectory, $"{Path.GetFileNameWithoutExtension(leftImagePath)}_processed.png");
                string rightOutputPath = Path.Combine(tempDirectory, $"{Path.GetFileNameWithoutExtension(rightImagePath)}_processed.png");

                // Copy the template and modify it for the left image.
                File.Copy(Path.Combine(_directoryRawTherapeeSidecarTemplates, FILENAME_RAWTHERAPEE_SIDECAR_TEMPLATE_5D), leftImagePP3, true);

                // Copy the template and modify it for the right image.
                File.Copy(Path.Combine(_directoryRawTherapeeSidecarTemplates, FILENAME_RAWTHERAPEE_SIDECAR_TEMPLATE_5D), rightImagePP3, true);

                // As a FYI -- we keep checking IsCancellationRequested below in case if we need to stop processing.
                // (Each processing step may take a noticeable amount of time.)
                if (!_cancellationTokenSource.Token.IsCancellationRequested)
                {
                    // Run RawTherapee to process the left image.
                    RunRawTherapeeCLI(leftImagePath, leftOutputPath, leftImagePP3);

                    if (!_cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        // Run RawTherapee to process the right image.
                        RunRawTherapeeCLI(rightImagePath, rightOutputPath, rightImagePP3);

                        if (!_cancellationTokenSource.Token.IsCancellationRequested)
                        {
                            // Now actually align the images and make them a stereo pair.
                            RunStereoAlign(leftOutputPath, rightOutputPath, outputImagePath);
                        }

                    }
                }

                // Clean up temporary files/directories.
                if (File.Exists(leftImagePP3)) File.Delete(leftImagePP3);
                if (File.Exists(rightImagePP3)) File.Delete(rightImagePP3);
                if (File.Exists(leftOutputPath)) File.Delete(leftOutputPath);
                if (File.Exists(rightOutputPath)) File.Delete(rightOutputPath);
                if (Directory.Exists(tempDirectory)) Directory.Delete(tempDirectory);
            }
            else
            {
                // We don't need to do any preprocessing; it's safe to call RunStereoAlign with the original input images.
                RunStereoAlign(leftImagePath, rightImagePath, outputImagePath);
            }
        }

        private void RunRawTherapeeCLI(string inputFile, string outputFile, string pp3File)
        {
            var startInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = _exeRawTherapeeCLI,
                Arguments = $"-s -n -Y -o \"{outputFile}\" -c \"{inputFile}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = new System.Diagnostics.Process())
            {
                process.StartInfo = startInfo;

                try
                {
                    process.Start();

                    // Check for cancellation periodically while the process is running.
                    while (!process.HasExited)
                    {
                        if (_cancellationTokenSource.Token.IsCancellationRequested)
                        {
                            try
                            {
                                // If cancellation is requested, kill the process
                                if (!process.HasExited)
                                {
                                    process.Kill();
                                }
                            }
                            catch (InvalidOperationException)
                            {
                                // The process may have already exited, so swallow the exception.
                            }
                            return; // Exit the method if cancellation is requested.
                        }

                        // Add a small delay to prevent tight-looping.
                        Thread.Sleep(100);
                    }

                    process.WaitForExit(); // Ensure that the process exits cleanly if there is no cancellation.
                }
                finally
                {
                    if (!process.HasExited)
                    {
                        process.Kill(); // Ensure the process is killed if it's still running.
                    }
                }
            }
        }

        private void CreateStereoImageFromLeft2DImage(string leftImagePath, string outputImagePath)
        {
            if (Path.GetExtension(leftImagePath).ToUpperInvariant() == ".CR2")
            {
                // We need to use RawTherapee to convert this CR2 file into a PNG file before processing them elsewhere.
                string tempDirectory = Path.Combine(Path.GetDirectoryName(outputImagePath), Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempDirectory);

                string directory = Path.GetDirectoryName(leftImagePath);
                string leftImagePP3 = Path.Combine(directory, $"{Path.GetFileName(leftImagePath)}.pp3");
                string leftOutputPath = Path.Combine(tempDirectory, $"{Path.GetFileNameWithoutExtension(leftImagePath)}_processed.png");

                // Copy the template and modify it for the left image.
                File.Copy(Path.Combine(_directoryRawTherapeeSidecarTemplates, FILENAME_RAWTHERAPEE_SIDECAR_TEMPLATE_5D), leftImagePP3, true);

                // As a FYI -- we keep checking IsCancellationRequested below in case if we need to stop processing.
                // (Each processing step may take a noticeable amount of time.)
                if (!_cancellationTokenSource.Token.IsCancellationRequested)
                {
                    // Run RawTherapee to process the left image.
                    RunRawTherapeeCLI(leftImagePath, leftOutputPath, leftImagePP3);

                    if (!_cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        string convertedSBSPath = Path.Combine(Path.GetDirectoryName(outputImagePath), $"{Path.GetFileNameWithoutExtension(leftImagePath)} autoconverted SBS.png");
                        ConvertToSBS(leftImagePath, convertedSBSPath);
                    }
                }

                // Clean up temporary files/directories.
                if (File.Exists(leftImagePP3)) File.Delete(leftImagePP3);
                if (File.Exists(leftOutputPath)) File.Delete(leftOutputPath);
                if (Directory.Exists(tempDirectory)) Directory.Delete(tempDirectory);
            }
            else
            {
                // We're dealing with a friendlier, non-.CR2 file format and can convert away.
                string convertedSBSPath = Path.Combine(Path.GetDirectoryName(outputImagePath), $"{Path.GetFileNameWithoutExtension(leftImagePath)} autoconverted SBS.png");
                ConvertToSBS(leftImagePath, convertedSBSPath);
            }
        }

        private void RunStereoAlign(string leftFile, string rightFile, string outputFile)
        {
            var startInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = _exeStereoAutoAlign,
                Arguments = $"\"{leftFile}\" \"{rightFile}\" 10 \"{outputFile}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = new System.Diagnostics.Process())
            {
                process.StartInfo = startInfo;

                try
                {
                    process.Start();

                    // Check for cancellation periodically while the process is running.
                    while (!process.HasExited)
                    {
                        if (_cancellationTokenSource.Token.IsCancellationRequested)
                        {
                            try
                            {
                                // If cancellation is requested, kill the process.
                                if (!process.HasExited)
                                {
                                    process.Kill();
                                }
                            }
                            catch (InvalidOperationException)
                            {
                                // The process may have already exited, so swallow the exception.
                            }
                            return; // Exit the method if cancellation is requested.
                        }

                        // Add a small delay to prevent tight-looping.
                        Thread.Sleep(100);
                    }

                    process.WaitForExit(); // Ensure the process exits cleanly if no cancellation.
                }
                finally
                {
                    if (!process.HasExited)
                    {
                        process.Kill(); // Ensure the process is killed if it's still running.
                    }
                }
            }
        }

        private void ConvertToSBS(string inputPath, string outputPath)
        {
            // Get the directory path
            string nunifDir = Path.GetDirectoryName(_batNunifPrompt);

            // Ensure the trailing backslash
            if (!nunifDir.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                nunifDir += Path.DirectorySeparatorChar;
            }

            string pythonCommand = $"python -m iw3 --input \"{inputPath}\" --output \"{outputPath}\" --divergence 2.0 --convergence 0.5 " +
                                   $"--method row_flow_v3 --depth-model Any_V2_N_B --foreground-scale 0 --max-fps 30 " +
                                   $"--crf 20 --preset ultrafast --video-format mp4 --pix-fmt yuv420p --zoed-batch-size 2 " +
                                   $"--max-workers 16 --tta --ipd-offset 0 --edge-dilation 0 --gpu 0";

            ExecuteCommands(_batNunifPrompt, nunifDir, pythonCommand);
        }

        private void ExecuteCommands(string batchFilePath, string workingDirectory, string command)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                RedirectStandardInput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            using (Process process = new Process())
            {
                process.StartInfo = processStartInfo;

                try
                {
                    process.Start();

                    using (StreamWriter sw = process.StandardInput)
                    {
                        if (sw.BaseStream.CanWrite)
                        {
                            // Run the batch file.
                            sw.WriteLine($"call \"{batchFilePath}\"");

                            // Change the directory to the required working directory.
                            sw.WriteLine($"cd /d \"{workingDirectory}\"");

                            // Execute the Python command.
                            sw.WriteLine(command);

                            // Exit the cmd process.
                            sw.WriteLine("exit"); 
                        }
                    }

                    // Periodically check for cancellation.
                    while (!process.HasExited)
                    {
                        if (_cancellationTokenSource.Token.IsCancellationRequested)
                        {
                            try
                            {
                                // If cancellation is requested, kill the process.
                                if (!process.HasExited)
                                {
                                    process.Kill();
                                }
                            }
                            catch (InvalidOperationException)
                            {
                                // The process may have already exited
                            }
                            return; // Exit method upon cancellation
                        }

                        // Add a small delay to avoid tight-looping.
                        Thread.Sleep(100);
                    }

                    process.WaitForExit(); // Ensure the process exits normally if not cancelled.
                }
                finally
                {
                    if (!process.HasExited)
                    {
                        process.Kill(); // Ensure the process is terminated if still running.
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void LoadSettings()
        {
            txtOutputDirectory.Text = Properties.Settings.Default.OutputDirectory ?? "";
            _exeRawTherapeeCLI = Properties.Settings.Default.RawTherapeeCLIEXEPath ?? "";
            _exeStereoAutoAlign = Properties.Settings.Default.StereoAutoAlignEXEPath ?? "";
            _batNunifPrompt = Properties.Settings.Default.NunifPromptBATPath ?? "";
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.OutputDirectory = txtOutputDirectory.Text;
            Properties.Settings.Default.RawTherapeeCLIEXEPath = _exeRawTherapeeCLI;
            Properties.Settings.Default.StereoAutoAlignEXEPath = _exeStereoAutoAlign;
            Properties.Settings.Default.NunifPromptBATPath = _batNunifPrompt;
            Properties.Settings.Default.Save();
        }

        private void btnOutputDirectory_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtOutputDirectory.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            EnableUI(true);
        }

        private void pbPrefs_Click(object sender, EventArgs e)
        {
            // Create an instance of frmPrefs
            frmPrefs prefsForm = new frmPrefs();

            // Set the preferences to be displayed in the prefs form.
            prefsForm.StereoAutoAlignEXEPath = _exeStereoAutoAlign;
            prefsForm.RawTherapeeCLIEXEPath = _exeRawTherapeeCLI; 
            prefsForm.NunifPromptBATPath = _batNunifPrompt;

            if (prefsForm.ShowDialog() == DialogResult.OK)
            {
                // Retrieve the updated preferences from the prefs form.
                _exeStereoAutoAlign = prefsForm.StereoAutoAlignEXEPath;
                _exeRawTherapeeCLI = prefsForm.RawTherapeeCLIEXEPath;
                _batNunifPrompt = prefsForm.NunifPromptBATPath;

                // Update the UI based on potentially changed preferences.
                EnableUI(true); 
            }
        }

        private void pbPrefs_MouseLeave(object sender, EventArgs e)
        {
            pbPrefsLight.Visible = true;
            pbPrefs.Visible = false;
        }

        private void pbPrefsLight_MouseEnter(object sender, EventArgs e)
        {
            if (_uiEnabled)
            {
                pbPrefsLight.Visible = false;
                pbPrefs.Visible = true;
            }
            else
            {
                pbPrefsLight.Visible = true;
                pbPrefs.Visible = false;
            }
        }
    }
}
