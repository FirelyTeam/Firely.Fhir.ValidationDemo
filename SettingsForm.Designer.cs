namespace Furore.Fhir.ValidationDemo
{
    partial class SettingsForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOpenProfileDir = new System.Windows.Forms.Button();
            this.txtProfileDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbEnableBuiltIn = new System.Windows.Forms.CheckBox();
            this.cbxTermServers = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnOpenProfileDir);
            this.groupBox1.Controls.Add(this.txtProfileDirectory);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(602, 147);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Profile source directory";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(6, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(590, 33);
            this.label2.TabIndex = 3;
            this.label2.Text = "For performance reasons, profiles in this directory will not be re-scanned at eac" +
    "h validation run. Press \'Reload\' on the main screen to refresh the cached inform" +
    "ation the validator may have.";
            // 
            // btnOpenProfileDir
            // 
            this.btnOpenProfileDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenProfileDir.Location = new System.Drawing.Point(521, 39);
            this.btnOpenProfileDir.Name = "btnOpenProfileDir";
            this.btnOpenProfileDir.Size = new System.Drawing.Size(75, 23);
            this.btnOpenProfileDir.TabIndex = 2;
            this.btnOpenProfileDir.Text = "&Browse...";
            this.btnOpenProfileDir.UseVisualStyleBackColor = true;
            this.btnOpenProfileDir.Click += new System.EventHandler(this.btnOpenProfileDir_Click);
            // 
            // txtProfileDirectory
            // 
            this.txtProfileDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProfileDirectory.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Furore.Fhir.ValidationDemo.Properties.Settings.Default, "ProfileSourceDirectory", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtProfileDirectory.Location = new System.Drawing.Point(6, 42);
            this.txtProfileDirectory.Name = "txtProfileDirectory";
            this.txtProfileDirectory.Size = new System.Drawing.Size(509, 20);
            this.txtProfileDirectory.TabIndex = 1;
            this.txtProfileDirectory.Text = global::Furore.Fhir.ValidationDemo.Properties.Settings.Default.ProfileSourceDirectory;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(421, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "The validator will look for your profiles and other conformance resources in this" +
    " directory:";
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Select a folder where this application can find your profiles to validate against" +
    ".";
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(515, 286);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 30);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cbEnableBuiltIn);
            this.groupBox2.Controls.Add(this.cbxTermServers);
            this.groupBox2.Location = new System.Drawing.Point(13, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(602, 88);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Terminology servers";
            // 
            // cbEnableBuiltIn
            // 
            this.cbEnableBuiltIn.AutoSize = true;
            this.cbEnableBuiltIn.Checked = global::Furore.Fhir.ValidationDemo.Properties.Settings.Default.UseBuiltInTX;
            this.cbEnableBuiltIn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEnableBuiltIn.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Furore.Fhir.ValidationDemo.Properties.Settings.Default, "UseBuiltInTX", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbEnableBuiltIn.Location = new System.Drawing.Point(9, 54);
            this.cbEnableBuiltIn.Name = "cbEnableBuiltIn";
            this.cbEnableBuiltIn.Size = new System.Drawing.Size(186, 17);
            this.cbEnableBuiltIn.TabIndex = 1;
            this.cbEnableBuiltIn.Text = "Try built-in terminology service first";
            this.cbEnableBuiltIn.UseVisualStyleBackColor = true;
            // 
            // cbxTermServers
            // 
            this.cbxTermServers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxTermServers.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Furore.Fhir.ValidationDemo.Properties.Settings.Default, "TerminologyService", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbxTermServers.FormattingEnabled = true;
            this.cbxTermServers.Location = new System.Drawing.Point(9, 19);
            this.cbxTermServers.Name = "cbxTermServers";
            this.cbxTermServers.Size = new System.Drawing.Size(578, 21);
            this.cbxTermServers.TabIndex = 0;
            this.cbxTermServers.Text = global::Furore.Fhir.ValidationDemo.Properties.Settings.Default.TerminologyService;
            this.cbxTermServers.Leave += new System.EventHandler(this.cbxTermServers_Leave);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 325);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Name = "SettingsForm";
            this.Text = "Change settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOpenProfileDir;
        private System.Windows.Forms.TextBox txtProfileDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbEnableBuiltIn;
        private System.Windows.Forms.ComboBox cbxTermServers;
    }
}