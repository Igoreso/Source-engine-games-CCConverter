using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CCTools;
using Ionic.Utils;

namespace CCConverterUI
{
    public partial class CcConverterForm : Form
    {
        public CcConverterForm()
        {
            InitializeComponent();
            RestoreSettings();
            
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            Text = Constants.AppName;
        }
        
        private void aboutAppLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(Constants.ContactInfo, Constants.AppName, MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void aboutMarkerLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(string.Format(Constants.NewLineMarkerInfoFormat, newLineMarker.Text), Constants.AppName, MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void linceseLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(Constants.LicenseText, Constants.AppName, MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void oldEnglishFileDialogButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(pathToOldEnglishFile.Text))
            {
                oldEnglishFileDialog.InitialDirectory = Path.GetDirectoryName(pathToOldEnglishFile.Text);
            }

            if (oldEnglishFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathToOldEnglishFile.Text = oldEnglishFileDialog.FileName;
            }
        }

        private void oldLocalizedFileDialogButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(pathToOldLocalizedFile.Text))
            {
                oldLocalizedFileDialog.InitialDirectory = Path.GetDirectoryName(pathToOldLocalizedFile.Text);
            }

            if (oldLocalizedFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathToOldLocalizedFile.Text = oldLocalizedFileDialog.FileName;
            }
        }

        private void newEnglishFileDialogButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(pathToNewEnglishFile.Text))
            {
                newEnglishFileDialog.InitialDirectory = Path.GetDirectoryName(pathToNewEnglishFile.Text);
            }

            if (newEnglishFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathToNewEnglishFile.Text = newEnglishFileDialog.FileName;
            }
        }

        private void outputDirectoryDialogButton_Click(object sender, EventArgs e)
        {
            // 3rd party code, taken from:
            // http://stackoverflow.com/a/580706
            // http://dotnetzip.codeplex.com/SourceControl/changeset/view/29499#432677

            var folderDialog = new FolderBrowserDialogEx
            {
                Description = "Select output directory",
                ShowNewFolderButton = true,
                ShowEditBox = true,
                SelectedPath = outputDirectory.Text,
                ShowFullPathInEditBox = true,
                RootFolder = Environment.SpecialFolder.MyComputer
            };

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                outputDirectory.Text = folderDialog.SelectedPath;
            }
        }
        
        private void generateButton_Click(object sender, EventArgs e)
        {
            var converter = new CcConverter
            {
                PathToOldEnglishFile = pathToOldEnglishFile.Text,
                PathToOldLocalizedFile = pathToOldLocalizedFile.Text,
                PathToNewEnglishFile = pathToNewEnglishFile.Text,
                OutputDirectory = outputDirectory.Text,
                //IgnoreCase = true,
                NewLineMarker = newLineMarker.Text
            };

            if (!converter.Validate())
            {
                MessageBox.Show(Constants.InvalidPaths, Constants.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SaveSettings();
                var result = converter.Generate();
                
                MessageBox.Show(string.Format(Constants.OkMessageFormat, newLineMarker.Text), Constants.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (result.BrokenLines.Any())
                {
                    var message = "The following lines were broken if you used previous version of this tool:\r\n\r\n" +
                                  string.Join("\r\n", result.BrokenLines);
                    MessageBox.Show(message, Constants.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                Process.Start("explorer.exe", "/select, " + result.GeneratedFilePath);
            }
            catch (Exception ex)
            {
                var message = string.Format(Constants.ErrorMessageFormat, ex.Message, ex.StackTrace);
                MessageBox.Show(message, Constants.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void CcConverterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void SaveSettings()
        {
            try
            {
                var settingsFile = GetSettingsFilePath();

                var filesPaths = new[]
                {
                    pathToOldEnglishFile.Text, 
                    pathToOldLocalizedFile.Text,
                    pathToNewEnglishFile.Text,
                    outputDirectory.Text,
                    newLineMarker.Text
                };

                if (File.Exists(settingsFile))
                {
                    File.Delete(settingsFile);
                }

                File.WriteAllLines(settingsFile, filesPaths);
            }
            // we don't care if we couldn't save settings
            // ReSharper disable once EmptyGeneralCatchClause
            catch (Exception)
            {
            }
        }

        private void RestoreSettings()
        {
            try
            {
                var settingsFile = GetSettingsFilePath();

                var lines =
                    File.Exists(settingsFile)
                        ? File.ReadAllLines(settingsFile)
                        : Enumerable.Empty<string>();

                // ReSharper disable PossibleMultipleEnumeration

                pathToOldEnglishFile.Text = lines.ElementAtOrDefault(0) ?? string.Empty;
                pathToOldLocalizedFile.Text = lines.ElementAtOrDefault(1) ?? string.Empty;
                pathToNewEnglishFile.Text = lines.ElementAtOrDefault(2) ?? string.Empty;
                outputDirectory.Text = lines.ElementAtOrDefault(3) ?? string.Empty;
                newLineMarker.Text = lines.ElementAtOrDefault(4) ?? Constants.DefaultNewLineMarker;

                // ReSharper restore PossibleMultipleEnumeration
            }
            // we don't care if we couldn't restore
            // ReSharper disable once EmptyGeneralCatchClause
            catch (Exception)
            {
            }
        }

        private string GetSettingsFilePath()
        {
            // any part here can possibly throw exception,
            // but we only use this method inside try/catch blocks,
            // so this is fine.
            var appPath = Assembly.GetExecutingAssembly().Location;
            var appDir = Path.GetDirectoryName(appPath);

            // ReSharper disable once AssignNullToNotNullAttribute
            var settingsFile = Path.Combine(appDir, Constants.AppSettingsFileName);
            return settingsFile;
        }
    }
}
