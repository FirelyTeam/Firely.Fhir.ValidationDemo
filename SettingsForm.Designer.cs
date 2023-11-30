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
            groupBox1 = new GroupBox();
            label2 = new Label();
            btnOpenProfileDir = new Button();
            txtProfileDirectory = new TextBox();
            label1 = new Label();
            folderBrowserDialog = new FolderBrowserDialog();
            btnOK = new Button();
            groupBox2 = new GroupBox();
            cbEnableBuiltIn = new CheckBox();
            cbxTermServers = new ComboBox();
            chkGenSnapshot = new CheckBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(chkGenSnapshot);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btnOpenProfileDir);
            groupBox1.Controls.Add(txtProfileDirectory);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(15, 14);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(744, 170);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Profile source directory";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.Location = new Point(7, 90);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(730, 38);
            label2.TabIndex = 3;
            label2.Text = "For performance reasons, profiles in this directory will not be re-scanned at each validation run. Press 'Reload' on the main screen to refresh the cached information the validator may have.";
            // 
            // btnOpenProfileDir
            // 
            btnOpenProfileDir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpenProfileDir.Location = new Point(650, 45);
            btnOpenProfileDir.Margin = new Padding(4, 3, 4, 3);
            btnOpenProfileDir.Name = "btnOpenProfileDir";
            btnOpenProfileDir.Size = new Size(88, 27);
            btnOpenProfileDir.TabIndex = 2;
            btnOpenProfileDir.Text = "&Browse...";
            btnOpenProfileDir.UseVisualStyleBackColor = true;
            btnOpenProfileDir.Click += BtnOpenProfileDir_Click;
            // 
            // txtProfileDirectory
            // 
            txtProfileDirectory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtProfileDirectory.Location = new Point(7, 48);
            txtProfileDirectory.Margin = new Padding(4, 3, 4, 3);
            txtProfileDirectory.Name = "txtProfileDirectory";
            txtProfileDirectory.Size = new Size(635, 23);
            txtProfileDirectory.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 30);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(478, 15);
            label1.TabIndex = 0;
            label1.Text = "The validator will look for your profiles and other conformance resources in this directory:";
            // 
            // folderBrowserDialog
            // 
            folderBrowserDialog.Description = "Select a folder where this application can find your profiles to validate against.";
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(643, 330);
            btnOK.Margin = new Padding(4, 3, 4, 3);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(117, 35);
            btnOK.TabIndex = 2;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(cbEnableBuiltIn);
            groupBox2.Controls.Add(cbxTermServers);
            groupBox2.Location = new Point(15, 207);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(744, 102);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Terminology servers";
            // 
            // cbEnableBuiltIn
            // 
            cbEnableBuiltIn.AutoSize = true;
            cbEnableBuiltIn.Checked = true;
            cbEnableBuiltIn.CheckState = CheckState.Checked;
            cbEnableBuiltIn.Location = new Point(10, 62);
            cbEnableBuiltIn.Margin = new Padding(4, 3, 4, 3);
            cbEnableBuiltIn.Name = "cbEnableBuiltIn";
            cbEnableBuiltIn.Size = new Size(213, 19);
            cbEnableBuiltIn.TabIndex = 1;
            cbEnableBuiltIn.Text = "Try built-in terminology service first";
            cbEnableBuiltIn.UseVisualStyleBackColor = true;
            // 
            // cbxTermServers
            // 
            cbxTermServers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbxTermServers.FormattingEnabled = true;
            cbxTermServers.Location = new Point(10, 22);
            cbxTermServers.Margin = new Padding(4, 3, 4, 3);
            cbxTermServers.Name = "cbxTermServers";
            cbxTermServers.Size = new Size(716, 23);
            cbxTermServers.TabIndex = 0;
            cbxTermServers.Leave += CbxTermServers_Leave;
            // 
            // chkGenSnapshot
            // 
            chkGenSnapshot.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chkGenSnapshot.AutoSize = true;
            chkGenSnapshot.Location = new Point(10, 145);
            chkGenSnapshot.Margin = new Padding(4, 3, 4, 3);
            chkGenSnapshot.Name = "chkGenSnapshot";
            chkGenSnapshot.Size = new Size(141, 19);
            chkGenSnapshot.TabIndex = 25;
            chkGenSnapshot.Text = "Regenerate snapshots";
            chkGenSnapshot.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(774, 375);
            Controls.Add(groupBox2);
            Controls.Add(btnOK);
            Controls.Add(groupBox1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "SettingsForm";
            Text = "Change settings";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
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
        private CheckBox chkGenSnapshot;
    }
}