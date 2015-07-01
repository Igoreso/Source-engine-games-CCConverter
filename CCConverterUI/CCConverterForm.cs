namespace CCConverterUI
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using CCTools;   

    public partial class CCConverterForm : Form
    {
        private readonly string AppName;

        private const string AppSettingsFileName = "ccconverter.cfg";

        private readonly Color DimmedTextColor = Color.LightGray;

        public CCConverterForm()
        {
            InitializeComponent();
            RegisterPrettifyingEvents();
            RestorePaths();
            this.AppName = this.Text; // save form name to use in message boxes            
        }
        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(Constants.ContactInfo, this.AppName, MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void oldEnglishFileDialogButton_Click(object sender, EventArgs e)
        {
            if (this.oldEnglishFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.pathToOldEnglishFile.Text = this.oldEnglishFileDialog.FileName;
            }
        }

        private void oldLocalizedFileDialogButton_Click(object sender, EventArgs e)
        {
            if (this.oldLocalizedFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.pathToOldLocalizedFile.Text = this.oldLocalizedFileDialog.FileName;
            }
        }

        private void newEnglishFileDialogButton_Click(object sender, EventArgs e)
        {
            if (this.newEnglishFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.pathToNewEnglishFile.Text = this.newEnglishFileDialog.FileName;
            }
        }

        private void outputDirectoryDialogButton_Click(object sender, EventArgs e)
        {
            // 3rd party code, taken from:
            // http://stackoverflow.com/a/580706
            // http://dotnetzip.codeplex.com/SourceControl/changeset/view/29499#432677

            var folderDialog = new Ionic.Utils.FolderBrowserDialogEx();
            folderDialog.Description = "Select output directory";
            folderDialog.ShowNewFolderButton = true;
            folderDialog.ShowEditBox = true;
            folderDialog.SelectedPath = this.outputDirectory.Text;
            folderDialog.ShowFullPathInEditBox = true;
            folderDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                this.outputDirectory.Text = folderDialog.SelectedPath;
            }
        }

        private void autofillOutputDirectoryButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.pathToNewEnglishFile.Text))
            {
                this.outputDirectory.Text = string.Empty;
            }
            else
            {
                this.outputDirectory.Text = Path.GetDirectoryName(this.pathToNewEnglishFile.Text);
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            var converter = new CCConverter()
            {
                PathToOldEnglishFile = this.pathToOldEnglishFile.Text,
                PathToOldLocalizedFile = this.pathToOldLocalizedFile.Text,
                PathToNewEnglishFile = this.pathToNewEnglishFile.Text,
                OutputDirectory = this.outputDirectory.Text
            };

            if (!converter.Validate())
            {
                MessageBox.Show("Not all paths are valid.", this.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SavePaths();
                var result = converter.Generate();
                MessageBox.Show(Constants.OkMessage, this.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start("explorer.exe", "/select, " + result.GeneratedFilePath);
            }
            catch (Exception ex)
            {
                var message = string.Format(Constants.ErrorMessageFormat, ex.Message, ex.StackTrace);
                MessageBox.Show(message, this.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void SavePaths()
        {
            try
            {
                var settingsFile = this.GetSettingsFilePath();

                var filesPaths = new[]
                {
                    this.pathToOldEnglishFile.Text, 
                    this.pathToOldLocalizedFile.Text,
                    this.pathToNewEnglishFile.Text,
                    this.outputDirectory.Text
                };

                if (File.Exists(settingsFile))
                {
                    File.Delete(settingsFile);
                }

                File.WriteAllLines(settingsFile, filesPaths);
            }
            catch (Exception)
            {
            }
        }

        private void RestorePaths()
        {
            this.pathToOldEnglishFile.Text = string.Empty;
            this.pathToOldLocalizedFile.Text = string.Empty;
            this.pathToNewEnglishFile.Text = string.Empty;
            this.outputDirectory.Text = string.Empty;

            try
            {
                var settingsFile = this.GetSettingsFilePath();
                if (!File.Exists(settingsFile))
                {
                    return;
                }

                var lines = File.ReadAllLines(settingsFile);
                if (lines.Length < 4)
                {
                    return;
                }

                this.pathToOldEnglishFile.Text = lines[0];
                this.pathToOldLocalizedFile.Text = lines[1];
                this.pathToNewEnglishFile.Text = lines[2];
                this.outputDirectory.Text = lines[3];
            }
            catch (Exception)
            {
            }
        }

        private string GetSettingsFilePath()
        {
            // any part here can possibly throw exception,
            // but we only use this method inside try/catch blocks,
            // so this is fine.
            var appPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var appDir = Path.GetDirectoryName(appPath);
            var settingsFile = Path.Combine(appDir, AppSettingsFileName);
            return settingsFile;
        }

        private void RegisterPrettifyingEvents()
        {
            RegisterPrettifyingEvents(pathToOldEnglishFile);
            RegisterPrettifyingEvents(pathToOldLocalizedFile);
            RegisterPrettifyingEvents(pathToNewEnglishFile);
            RegisterPrettifyingEvents(outputDirectory);
        }

        private void RegisterPrettifyingEvents(TextBoxBase box)
        {
            box.ForeColor = DimmedTextColor;

            box.Enter += (s, e) => { box.ForeColor = Color.Black; };

            box.Leave += (s, e) => { box.ForeColor = DimmedTextColor; };

            box.MouseEnter += (s, e) => { box.ForeColor = Color.Black; };

            box.MouseLeave += (s, e) =>
            {
                if (!box.Focused)
                {
                    box.ForeColor = DimmedTextColor;
                }
            };
        }
    }
}
