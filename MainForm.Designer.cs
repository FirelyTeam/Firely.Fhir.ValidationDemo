namespace Furore.Fhir.ValidationDemo
{
    partial class MainForm
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
            instanceBox = new GroupBox();
            btnLoad = new Button();
            btnValidate = new Button();
            txtInstance = new RichTextBox();
            groupBox3 = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            cbErrors = new CheckBox();
            cbWarnings = new CheckBox();
            cbInformation = new CheckBox();
            btnCopyClipboard = new Button();
            txtOutcome = new TextBox();
            mainStrip = new StatusStrip();
            mainStatusLabel = new ToolStripStatusLabel();
            groupBox1 = new GroupBox();
            chkDisableFP = new CheckBox();
            chkXsdValidation = new CheckBox();
            btnReload = new Button();
            btnSettings = new Button();
            lblTerminologySvc = new Label();
            label2 = new Label();
            lblDefinitionPath = new Label();
            label1 = new Label();
            openInstance = new OpenFileDialog();
            instanceBox.SuspendLayout();
            groupBox3.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            mainStrip.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // instanceBox
            // 
            instanceBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            instanceBox.Controls.Add(btnLoad);
            instanceBox.Controls.Add(btnValidate);
            instanceBox.Controls.Add(txtInstance);
            instanceBox.Location = new Point(15, 13);
            instanceBox.Margin = new Padding(4, 3, 4, 3);
            instanceBox.Name = "instanceBox";
            instanceBox.Padding = new Padding(4, 3, 4, 3);
            instanceBox.Size = new Size(895, 286);
            instanceBox.TabIndex = 1;
            instanceBox.TabStop = false;
            instanceBox.Text = "Instance";
            // 
            // btnLoad
            // 
            btnLoad.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLoad.Location = new Point(780, 249);
            btnLoad.Margin = new Padding(4, 3, 4, 3);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(103, 27);
            btnLoad.TabIndex = 7;
            btnLoad.Text = "Load...";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += BtnLoad_Click;
            // 
            // btnValidate
            // 
            btnValidate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnValidate.Location = new Point(10, 249);
            btnValidate.Margin = new Padding(4, 3, 4, 3);
            btnValidate.Name = "btnValidate";
            btnValidate.Size = new Size(88, 27);
            btnValidate.TabIndex = 6;
            btnValidate.Text = "&Validate!";
            btnValidate.UseVisualStyleBackColor = true;
            btnValidate.Click += BtnValidate_Click;
            // 
            // txtInstance
            // 
            txtInstance.AcceptsTab = true;
            txtInstance.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtInstance.Location = new Point(10, 27);
            txtInstance.Margin = new Padding(4, 3, 4, 3);
            txtInstance.Name = "txtInstance";
            txtInstance.Size = new Size(872, 215);
            txtInstance.TabIndex = 0;
            txtInstance.Text = "";
            txtInstance.TextChanged += TxtInstanceXml_TextChanged;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(flowLayoutPanel1);
            groupBox3.Controls.Add(btnCopyClipboard);
            groupBox3.Controls.Add(txtOutcome);
            groupBox3.Location = new Point(14, 317);
            groupBox3.Margin = new Padding(4, 3, 4, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4, 3, 4, 3);
            groupBox3.Size = new Size(895, 252);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Last Validation results";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(cbErrors);
            flowLayoutPanel1.Controls.Add(cbWarnings);
            flowLayoutPanel1.Controls.Add(cbInformation);
            flowLayoutPanel1.Location = new Point(8, 209);
            flowLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(382, 36);
            flowLayoutPanel1.TabIndex = 10;
            // 
            // cbErrors
            // 
            cbErrors.Appearance = Appearance.Button;
            cbErrors.AutoSize = true;
            cbErrors.Checked = true;
            cbErrors.CheckState = CheckState.Checked;
            cbErrors.FlatStyle = FlatStyle.Popup;
            cbErrors.Location = new Point(4, 3);
            cbErrors.Margin = new Padding(4, 3, 4, 3);
            cbErrors.Name = "cbErrors";
            cbErrors.Size = new Size(47, 25);
            cbErrors.TabIndex = 8;
            cbErrors.Text = "Errors";
            cbErrors.UseVisualStyleBackColor = true;
            cbErrors.CheckedChanged += CbOutcomeFilter_CheckedChanged;
            // 
            // cbWarnings
            // 
            cbWarnings.Appearance = Appearance.Button;
            cbWarnings.AutoSize = true;
            cbWarnings.Checked = true;
            cbWarnings.CheckState = CheckState.Checked;
            cbWarnings.FlatStyle = FlatStyle.Popup;
            cbWarnings.Location = new Point(59, 3);
            cbWarnings.Margin = new Padding(4, 3, 4, 3);
            cbWarnings.Name = "cbWarnings";
            cbWarnings.Size = new Size(67, 25);
            cbWarnings.TabIndex = 9;
            cbWarnings.Text = "Warnings";
            cbWarnings.UseVisualStyleBackColor = true;
            cbWarnings.CheckedChanged += CbOutcomeFilter_CheckedChanged;
            // 
            // cbInformation
            // 
            cbInformation.Appearance = Appearance.Button;
            cbInformation.AutoSize = true;
            cbInformation.FlatStyle = FlatStyle.Popup;
            cbInformation.Location = new Point(134, 3);
            cbInformation.Margin = new Padding(4, 3, 4, 3);
            cbInformation.Name = "cbInformation";
            cbInformation.Size = new Size(80, 25);
            cbInformation.TabIndex = 10;
            cbInformation.Text = "Information";
            cbInformation.UseVisualStyleBackColor = true;
            cbInformation.CheckedChanged += CbOutcomeFilter_CheckedChanged;
            // 
            // btnCopyClipboard
            // 
            btnCopyClipboard.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCopyClipboard.Location = new Point(747, 213);
            btnCopyClipboard.Margin = new Padding(4, 3, 4, 3);
            btnCopyClipboard.Name = "btnCopyClipboard";
            btnCopyClipboard.Size = new Size(138, 31);
            btnCopyClipboard.TabIndex = 6;
            btnCopyClipboard.Text = "Copy to clipboard";
            btnCopyClipboard.UseVisualStyleBackColor = true;
            btnCopyClipboard.Click += BtnCopyClipboard_Click;
            // 
            // txtOutcome
            // 
            txtOutcome.AcceptsTab = true;
            txtOutcome.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtOutcome.Location = new Point(12, 23);
            txtOutcome.Margin = new Padding(4, 3, 4, 3);
            txtOutcome.Multiline = true;
            txtOutcome.Name = "txtOutcome";
            txtOutcome.ReadOnly = true;
            txtOutcome.ScrollBars = ScrollBars.Both;
            txtOutcome.Size = new Size(872, 183);
            txtOutcome.TabIndex = 0;
            // 
            // mainStrip
            // 
            mainStrip.ImageScalingSize = new Size(32, 32);
            mainStrip.Items.AddRange(new ToolStripItem[] { mainStatusLabel });
            mainStrip.Location = new Point(0, 760);
            mainStrip.Name = "mainStrip";
            mainStrip.Padding = new Padding(1, 0, 16, 0);
            mainStrip.Size = new Size(925, 22);
            mainStrip.TabIndex = 4;
            mainStrip.Text = "statusStrip1";
            // 
            // mainStatusLabel
            // 
            mainStatusLabel.AutoSize = false;
            mainStatusLabel.Name = "mainStatusLabel";
            mainStatusLabel.Size = new Size(908, 17);
            mainStatusLabel.Spring = true;
            mainStatusLabel.Text = "(there should be something here)";
            mainStatusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(chkDisableFP);
            groupBox1.Controls.Add(chkXsdValidation);
            groupBox1.Controls.Add(btnReload);
            groupBox1.Controls.Add(btnSettings);
            groupBox1.Controls.Add(lblTerminologySvc);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(lblDefinitionPath);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(15, 585);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(894, 149);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Settings";
            // 
            // chkDisableFP
            // 
            chkDisableFP.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chkDisableFP.AutoSize = true;
            chkDisableFP.Location = new Point(147, 23);
            chkDisableFP.Margin = new Padding(4, 3, 4, 3);
            chkDisableFP.Name = "chkDisableFP";
            chkDisableFP.Size = new Size(150, 19);
            chkDisableFP.TabIndex = 23;
            chkDisableFP.Text = "Disable Fhir&Path checks";
            chkDisableFP.UseVisualStyleBackColor = true;
            // 
            // chkXsdValidation
            // 
            chkXsdValidation.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chkXsdValidation.AutoSize = true;
            chkXsdValidation.Location = new Point(16, 23);
            chkXsdValidation.Margin = new Padding(4, 3, 4, 3);
            chkXsdValidation.Name = "chkXsdValidation";
            chkXsdValidation.Size = new Size(100, 19);
            chkXsdValidation.TabIndex = 22;
            chkXsdValidation.Text = "&Xsd validation";
            chkXsdValidation.UseVisualStyleBackColor = true;
            // 
            // btnReload
            // 
            btnReload.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnReload.Location = new Point(115, 113);
            btnReload.Margin = new Padding(4, 3, 4, 3);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(135, 27);
            btnReload.TabIndex = 20;
            btnReload.Text = "&Reload Definitions";
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += BtnReload_Click;
            // 
            // btnSettings
            // 
            btnSettings.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSettings.Location = new Point(14, 113);
            btnSettings.Margin = new Padding(4, 3, 4, 3);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(88, 27);
            btnSettings.TabIndex = 19;
            btnSettings.Text = "Change...";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += BtnSettings_Click;
            // 
            // lblTerminologySvc
            // 
            lblTerminologySvc.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTerminologySvc.AutoSize = true;
            lblTerminologySvc.Location = new Point(136, 83);
            lblTerminologySvc.Margin = new Padding(4, 0, 4, 0);
            lblTerminologySvc.Name = "lblTerminologySvc";
            lblTerminologySvc.Size = new Size(68, 15);
            lblTerminologySvc.TabIndex = 18;
            lblTerminologySvc.Text = "(generated)";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(12, 83);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(115, 15);
            label2.TabIndex = 17;
            label2.Text = "Terminology servers:";
            // 
            // lblDefinitionPath
            // 
            lblDefinitionPath.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblDefinitionPath.AutoSize = true;
            lblDefinitionPath.Location = new Point(136, 62);
            lblDefinitionPath.Margin = new Padding(4, 0, 4, 0);
            lblDefinitionPath.Name = "lblDefinitionPath";
            lblDefinitionPath.Size = new Size(68, 15);
            lblDefinitionPath.TabIndex = 16;
            lblDefinitionPath.Text = "(generated)";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(13, 61);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(107, 15);
            label1.TabIndex = 15;
            label1.Text = "Path to definitions:";
            // 
            // openInstance
            // 
            openInstance.AddExtension = false;
            openInstance.Filter = "XML|*.xml|Json|*.json";
            openInstance.Title = "Open an instance";
            // 
            // MainForm
            // 
            AcceptButton = btnValidate;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(925, 782);
            Controls.Add(groupBox1);
            Controls.Add(mainStrip);
            Controls.Add(instanceBox);
            Controls.Add(groupBox3);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "FHIR R4 Profile Validator Demo";
            FormClosed += MainForm_FormClosed;
            Load += MainForm_Load;
            instanceBox.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            mainStrip.ResumeLayout(false);
            mainStrip.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.GroupBox instanceBox;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.RichTextBox txtInstance;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtOutcome;
        private System.Windows.Forms.StatusStrip mainStrip;
        private System.Windows.Forms.ToolStripStatusLabel mainStatusLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label lblTerminologySvc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDefinitionPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkDisableFP;
        private System.Windows.Forms.CheckBox chkXsdValidation;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.OpenFileDialog openInstance;
        private System.Windows.Forms.Button btnCopyClipboard;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox cbErrors;
        private System.Windows.Forms.CheckBox cbWarnings;
        private System.Windows.Forms.CheckBox cbInformation;
    }
}

