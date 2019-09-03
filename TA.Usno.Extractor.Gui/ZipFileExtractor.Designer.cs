namespace TA.Usno.Extractor.Gui
{
    partial class ZipFileExtractor
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
            this.components = new System.ComponentModel.Container();
            this.sourceLabel = new System.Windows.Forms.Label();
            this.destinationLabel = new System.Windows.Forms.Label();
            this.sourceDirectory = new System.Windows.Forms.TextBox();
            this.destinationDirectory = new System.Windows.Forms.TextBox();
            this.browseDestination = new System.Windows.Forms.Button();
            this.ExtractButton = new System.Windows.Forms.Button();
            this.deleteArchive = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.browseSource = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.console = new ConsoleControl.ConsoleControl();
            this.browseFolders = new System.Windows.Forms.FolderBrowserDialog();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // sourceLabel
            // 
            this.sourceLabel.AutoSize = true;
            this.sourceLabel.Location = new System.Drawing.Point(6, 16);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(44, 13);
            this.sourceLabel.TabIndex = 0;
            this.sourceLabel.Text = "Source:";
            // 
            // destinationLabel
            // 
            this.destinationLabel.AutoSize = true;
            this.destinationLabel.Location = new System.Drawing.Point(6, 51);
            this.destinationLabel.Name = "destinationLabel";
            this.destinationLabel.Size = new System.Drawing.Size(63, 13);
            this.destinationLabel.TabIndex = 1;
            this.destinationLabel.Text = "Destination:";
            // 
            // sourceDirectory
            // 
            this.sourceDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceDirectory.Location = new System.Drawing.Point(78, 13);
            this.sourceDirectory.Name = "sourceDirectory";
            this.sourceDirectory.Size = new System.Drawing.Size(627, 20);
            this.sourceDirectory.TabIndex = 2;
            this.sourceDirectory.TextChanged += new System.EventHandler(this.DirectoryTextChanged);
            // 
            // destinationDirectory
            // 
            this.destinationDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.destinationDirectory.Location = new System.Drawing.Point(78, 48);
            this.destinationDirectory.Name = "destinationDirectory";
            this.destinationDirectory.Size = new System.Drawing.Size(627, 20);
            this.destinationDirectory.TabIndex = 3;
            this.destinationDirectory.TextChanged += new System.EventHandler(this.DirectoryTextChanged);
            // 
            // browseDestination
            // 
            this.browseDestination.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseDestination.Location = new System.Drawing.Point(711, 47);
            this.browseDestination.Name = "browseDestination";
            this.browseDestination.Size = new System.Drawing.Size(29, 20);
            this.browseDestination.TabIndex = 6;
            this.browseDestination.Text = "...";
            this.browseDestination.UseVisualStyleBackColor = true;
            // 
            // ExtractButton
            // 
            this.ExtractButton.Location = new System.Drawing.Point(78, 101);
            this.ExtractButton.Name = "ExtractButton";
            this.ExtractButton.Size = new System.Drawing.Size(166, 23);
            this.ExtractButton.TabIndex = 8;
            this.ExtractButton.Text = "Extract";
            this.ExtractButton.UseVisualStyleBackColor = true;
            // 
            // deleteArchive
            // 
            this.deleteArchive.AutoSize = true;
            this.deleteArchive.Location = new System.Drawing.Point(78, 78);
            this.deleteArchive.Name = "deleteArchive";
            this.deleteArchive.Size = new System.Drawing.Size(221, 17);
            this.deleteArchive.TabIndex = 10;
            this.deleteArchive.Text = "Delete archive after successful extraction";
            this.deleteArchive.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.browseSource);
            this.groupBox1.Controls.Add(this.sourceLabel);
            this.groupBox1.Controls.Add(this.deleteArchive);
            this.groupBox1.Controls.Add(this.destinationLabel);
            this.groupBox1.Controls.Add(this.cancelButton);
            this.groupBox1.Controls.Add(this.sourceDirectory);
            this.groupBox1.Controls.Add(this.ExtractButton);
            this.groupBox1.Controls.Add(this.destinationDirectory);
            this.groupBox1.Controls.Add(this.browseDestination);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(746, 164);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // browseSource
            // 
            this.browseSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseSource.Location = new System.Drawing.Point(711, 12);
            this.browseSource.Name = "browseSource";
            this.browseSource.Size = new System.Drawing.Size(29, 20);
            this.browseSource.TabIndex = 11;
            this.browseSource.Text = "...";
            this.browseSource.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(78, 130);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(166, 23);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // console
            // 
            this.console.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.console.IsInputEnabled = true;
            this.console.Location = new System.Drawing.Point(12, 182);
            this.console.Name = "console";
            this.console.SendKeyboardCommandsToProcess = false;
            this.console.ShowDiagnostics = false;
            this.console.Size = new System.Drawing.Size(746, 259);
            this.console.TabIndex = 12;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ZipFileExtractor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 453);
            this.Controls.Add(this.console);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(786, 492);
            this.Name = "ZipFileExtractor";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Zip file extractor";
            this.Load += new System.EventHandler(this.ZipFileExtractor_Load);
            this.Validated += new System.EventHandler(this.ZipFileExtractor_Validated);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label sourceLabel;
        private System.Windows.Forms.Label destinationLabel;
        private System.Windows.Forms.TextBox sourceDirectory;
        private System.Windows.Forms.TextBox destinationDirectory;
        private System.Windows.Forms.Button browseDestination;
        private System.Windows.Forms.Button ExtractButton;
        private System.Windows.Forms.CheckBox deleteArchive;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button browseSource;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.FolderBrowserDialog browseFolders;
        private ConsoleControl.ConsoleControl console;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}

