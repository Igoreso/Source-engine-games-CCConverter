namespace CCConverterUI
{
    partial class CcConverterForm
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
        /// Required method for Designer support - do not oldify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CcConverterForm));
            this.pathToOldEnglishFile = new System.Windows.Forms.TextBox();
            this.pathToOldLocalizedFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pathToNewEnglishFile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.oldEnglishFileDialogButton = new System.Windows.Forms.Button();
            this.oldLocalizedFileDialogButton = new System.Windows.Forms.Button();
            this.newEnglishFileDialogButton = new System.Windows.Forms.Button();
            this.generateButton = new System.Windows.Forms.Button();
            this.oldEnglishFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.oldLocalizedFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.newEnglishFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.aboutAppLink = new System.Windows.Forms.LinkLabel();
            this.outputDirectory = new System.Windows.Forms.TextBox();
            this.outputDirectoryDialogButton = new System.Windows.Forms.Button();
            this.newLineMarker = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.aboutMarkerLink = new System.Windows.Forms.LinkLabel();
            this.linceseLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // pathToOldEnglishFile
            // 
            this.pathToOldEnglishFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathToOldEnglishFile.Location = new System.Drawing.Point(18, 38);
            this.pathToOldEnglishFile.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.pathToOldEnglishFile.Name = "pathToOldEnglishFile";
            this.pathToOldEnglishFile.Size = new System.Drawing.Size(447, 20);
            this.pathToOldEnglishFile.TabIndex = 2;
            // 
            // pathToOldLocalizedFile
            // 
            this.pathToOldLocalizedFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathToOldLocalizedFile.Location = new System.Drawing.Point(18, 101);
            this.pathToOldLocalizedFile.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.pathToOldLocalizedFile.Name = "pathToOldLocalizedFile";
            this.pathToOldLocalizedFile.Size = new System.Drawing.Size(447, 20);
            this.pathToOldLocalizedFile.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 20);
            this.label1.TabIndex = 999;
            this.label1.Text = "Step 1. Choose path to OLD English text file";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(18, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(329, 20);
            this.label2.TabIndex = 999;
            this.label2.Text = "Step 2. Choose path to OLD localized text file";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(18, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(324, 20);
            this.label3.TabIndex = 999;
            this.label3.Text = "Step 3. Choose path to NEW English text file";
            // 
            // pathToNewEnglishFile
            // 
            this.pathToNewEnglishFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathToNewEnglishFile.Location = new System.Drawing.Point(18, 164);
            this.pathToNewEnglishFile.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.pathToNewEnglishFile.Name = "pathToNewEnglishFile";
            this.pathToNewEnglishFile.Size = new System.Drawing.Size(447, 20);
            this.pathToNewEnglishFile.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(18, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(233, 20);
            this.label4.TabIndex = 999;
            this.label4.Text = "Step 4. Choose output directory";
            // 
            // oldEnglishFileDialogButton
            // 
            this.oldEnglishFileDialogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.oldEnglishFileDialogButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.oldEnglishFileDialogButton.Location = new System.Drawing.Point(486, 31);
            this.oldEnglishFileDialogButton.Name = "oldEnglishFileDialogButton";
            this.oldEnglishFileDialogButton.Size = new System.Drawing.Size(75, 30);
            this.oldEnglishFileDialogButton.TabIndex = 3;
            this.oldEnglishFileDialogButton.Text = "Choose";
            this.oldEnglishFileDialogButton.UseVisualStyleBackColor = true;
            this.oldEnglishFileDialogButton.Click += new System.EventHandler(this.oldEnglishFileDialogButton_Click);
            // 
            // oldLocalizedFileDialogButton
            // 
            this.oldLocalizedFileDialogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.oldLocalizedFileDialogButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.oldLocalizedFileDialogButton.Location = new System.Drawing.Point(486, 94);
            this.oldLocalizedFileDialogButton.Name = "oldLocalizedFileDialogButton";
            this.oldLocalizedFileDialogButton.Size = new System.Drawing.Size(75, 30);
            this.oldLocalizedFileDialogButton.TabIndex = 5;
            this.oldLocalizedFileDialogButton.Text = "Choose";
            this.oldLocalizedFileDialogButton.UseVisualStyleBackColor = true;
            this.oldLocalizedFileDialogButton.Click += new System.EventHandler(this.oldLocalizedFileDialogButton_Click);
            // 
            // newEnglishFileDialogButton
            // 
            this.newEnglishFileDialogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newEnglishFileDialogButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newEnglishFileDialogButton.Location = new System.Drawing.Point(486, 157);
            this.newEnglishFileDialogButton.Name = "newEnglishFileDialogButton";
            this.newEnglishFileDialogButton.Size = new System.Drawing.Size(75, 30);
            this.newEnglishFileDialogButton.TabIndex = 7;
            this.newEnglishFileDialogButton.Text = "Choose";
            this.newEnglishFileDialogButton.UseVisualStyleBackColor = true;
            this.newEnglishFileDialogButton.Click += new System.EventHandler(this.newEnglishFileDialogButton_Click);
            // 
            // generateButton
            // 
            this.generateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.generateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.generateButton.Location = new System.Drawing.Point(18, 340);
            this.generateButton.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(543, 44);
            this.generateButton.TabIndex = 0;
            this.generateButton.Text = "Generate localized text file";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // oldEnglishFileDialog
            // 
            this.oldEnglishFileDialog.Title = "Path to OLD English text file";
            // 
            // oldLocalizedFileDialog
            // 
            this.oldLocalizedFileDialog.Title = "Path to OLD localized text file";
            // 
            // newEnglishFileDialog
            // 
            this.newEnglishFileDialog.Title = "Path to NEW English text file";
            // 
            // aboutAppLink
            // 
            this.aboutAppLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutAppLink.AutoSize = true;
            this.aboutAppLink.DisabledLinkColor = System.Drawing.Color.Blue;
            this.aboutAppLink.LinkColor = System.Drawing.Color.Blue;
            this.aboutAppLink.Location = new System.Drawing.Point(467, 393);
            this.aboutAppLink.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.aboutAppLink.Name = "aboutAppLink";
            this.aboutAppLink.Size = new System.Drawing.Size(35, 13);
            this.aboutAppLink.TabIndex = 1;
            this.aboutAppLink.TabStop = true;
            this.aboutAppLink.Text = "About";
            this.aboutAppLink.VisitedLinkColor = System.Drawing.Color.Blue;
            this.aboutAppLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.aboutAppLink_LinkClicked);
            // 
            // outputDirectory
            // 
            this.outputDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputDirectory.Location = new System.Drawing.Point(18, 227);
            this.outputDirectory.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.outputDirectory.Name = "outputDirectory";
            this.outputDirectory.Size = new System.Drawing.Size(447, 20);
            this.outputDirectory.TabIndex = 1000;
            // 
            // outputDirectoryDialogButton
            // 
            this.outputDirectoryDialogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.outputDirectoryDialogButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.outputDirectoryDialogButton.Location = new System.Drawing.Point(486, 220);
            this.outputDirectoryDialogButton.Name = "outputDirectoryDialogButton";
            this.outputDirectoryDialogButton.Size = new System.Drawing.Size(75, 30);
            this.outputDirectoryDialogButton.TabIndex = 1001;
            this.outputDirectoryDialogButton.Text = "Choose";
            this.outputDirectoryDialogButton.UseVisualStyleBackColor = true;
            this.outputDirectoryDialogButton.Click += new System.EventHandler(this.outputDirectoryDialogButton_Click);
            // 
            // newLineMarker
            // 
            this.newLineMarker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newLineMarker.Location = new System.Drawing.Point(18, 290);
            this.newLineMarker.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.newLineMarker.Name = "newLineMarker";
            this.newLineMarker.Size = new System.Drawing.Size(447, 20);
            this.newLineMarker.TabIndex = 1003;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(18, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(243, 20);
            this.label5.TabIndex = 1002;
            this.label5.Text = "(Optional) Define new line marker";
            // 
            // aboutMarkerLink
            // 
            this.aboutMarkerLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutMarkerLink.AutoSize = true;
            this.aboutMarkerLink.DisabledLinkColor = System.Drawing.Color.Blue;
            this.aboutMarkerLink.LinkColor = System.Drawing.Color.Blue;
            this.aboutMarkerLink.Location = new System.Drawing.Point(491, 293);
            this.aboutMarkerLink.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.aboutMarkerLink.Name = "aboutMarkerLink";
            this.aboutMarkerLink.Size = new System.Drawing.Size(67, 13);
            this.aboutMarkerLink.TabIndex = 1004;
            this.aboutMarkerLink.TabStop = true;
            this.aboutMarkerLink.Text = "What\'s that?";
            this.aboutMarkerLink.VisitedLinkColor = System.Drawing.Color.Blue;
            this.aboutMarkerLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.aboutMarkerLink_LinkClicked);
            // 
            // linceseLink
            // 
            this.linceseLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linceseLink.AutoSize = true;
            this.linceseLink.DisabledLinkColor = System.Drawing.Color.Blue;
            this.linceseLink.LinkColor = System.Drawing.Color.Blue;
            this.linceseLink.Location = new System.Drawing.Point(514, 393);
            this.linceseLink.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.linceseLink.Name = "linceseLink";
            this.linceseLink.Size = new System.Drawing.Size(44, 13);
            this.linceseLink.TabIndex = 1005;
            this.linceseLink.TabStop = true;
            this.linceseLink.Text = "License";
            this.linceseLink.VisitedLinkColor = System.Drawing.Color.Blue;
            this.linceseLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linceseLink_LinkClicked);
            // 
            // CcConverterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 421);
            this.Controls.Add(this.linceseLink);
            this.Controls.Add(this.aboutMarkerLink);
            this.Controls.Add(this.newLineMarker);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.outputDirectoryDialogButton);
            this.Controls.Add(this.outputDirectory);
            this.Controls.Add(this.aboutAppLink);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.newEnglishFileDialogButton);
            this.Controls.Add(this.oldLocalizedFileDialogButton);
            this.Controls.Add(this.oldEnglishFileDialogButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pathToNewEnglishFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pathToOldLocalizedFile);
            this.Controls.Add(this.pathToOldEnglishFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CcConverterForm";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CCConverter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CcConverterForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pathToOldEnglishFile;
        private System.Windows.Forms.TextBox pathToOldLocalizedFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pathToNewEnglishFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button oldEnglishFileDialogButton;
        private System.Windows.Forms.Button oldLocalizedFileDialogButton;
        private System.Windows.Forms.Button newEnglishFileDialogButton;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.OpenFileDialog oldEnglishFileDialog;
        private System.Windows.Forms.OpenFileDialog oldLocalizedFileDialog;
        private System.Windows.Forms.OpenFileDialog newEnglishFileDialog;
        private System.Windows.Forms.LinkLabel aboutAppLink;
        private System.Windows.Forms.TextBox outputDirectory;
        private System.Windows.Forms.Button outputDirectoryDialogButton;
        private System.Windows.Forms.TextBox newLineMarker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel aboutMarkerLink;
        private System.Windows.Forms.LinkLabel linceseLink;
    }
}

