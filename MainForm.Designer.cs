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
            this.instanceBox = new System.Windows.Forms.GroupBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnValidate = new System.Windows.Forms.Button();
            this.txtInstanceXml = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbErrors = new System.Windows.Forms.CheckBox();
            this.cbWarnings = new System.Windows.Forms.CheckBox();
            this.cbInformation = new System.Windows.Forms.CheckBox();
            this.btnCopyClipboard = new System.Windows.Forms.Button();
            this.txtOutcome = new System.Windows.Forms.TextBox();
            this.mainStrip = new System.Windows.Forms.StatusStrip();
            this.mainStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkGenSnapshot = new System.Windows.Forms.CheckBox();
            this.chkDisableFP = new System.Windows.Forms.CheckBox();
            this.chkShowTraceInfo = new System.Windows.Forms.CheckBox();
            this.chkXsdValidation = new System.Windows.Forms.CheckBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.lblTerminologySvc = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDefinitionPath = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openInstance = new System.Windows.Forms.OpenFileDialog();
            this.instanceBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.mainStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // instanceBox
            // 
            this.instanceBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.instanceBox.Controls.Add(this.btnLoad);
            this.instanceBox.Controls.Add(this.btnValidate);
            this.instanceBox.Controls.Add(this.txtInstanceXml);
            this.instanceBox.Location = new System.Drawing.Point(13, 11);
            this.instanceBox.Name = "instanceBox";
            this.instanceBox.Size = new System.Drawing.Size(767, 248);
            this.instanceBox.TabIndex = 1;
            this.instanceBox.TabStop = false;
            this.instanceBox.Text = "Instance";
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(669, 216);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(88, 23);
            this.btnLoad.TabIndex = 7;
            this.btnLoad.Text = "Load...";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnValidate
            // 
            this.btnValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnValidate.Location = new System.Drawing.Point(9, 216);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(75, 23);
            this.btnValidate.TabIndex = 6;
            this.btnValidate.Text = "&Validate!";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // txtInstanceXml
            // 
            this.txtInstanceXml.AcceptsTab = true;
            this.txtInstanceXml.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInstanceXml.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Furore.Fhir.ValidationDemo.Properties.Settings.Default, "InstanceXml", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtInstanceXml.Location = new System.Drawing.Point(9, 23);
            this.txtInstanceXml.Name = "txtInstanceXml";
            this.txtInstanceXml.Size = new System.Drawing.Size(748, 187);
            this.txtInstanceXml.TabIndex = 0;
            this.txtInstanceXml.Text = global::Furore.Fhir.ValidationDemo.Properties.Settings.Default.InstanceXml;
            this.txtInstanceXml.TextChanged += new System.EventHandler(this.txtInstanceXml_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.flowLayoutPanel1);
            this.groupBox3.Controls.Add(this.btnCopyClipboard);
            this.groupBox3.Controls.Add(this.txtOutcome);
            this.groupBox3.Location = new System.Drawing.Point(12, 275);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(767, 218);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Last Validation results";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cbErrors);
            this.flowLayoutPanel1.Controls.Add(this.cbWarnings);
            this.flowLayoutPanel1.Controls.Add(this.cbInformation);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(7, 181);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(327, 31);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // cbErrors
            // 
            this.cbErrors.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbErrors.AutoSize = true;
            this.cbErrors.Checked = true;
            this.cbErrors.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbErrors.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbErrors.Location = new System.Drawing.Point(3, 3);
            this.cbErrors.Name = "cbErrors";
            this.cbErrors.Size = new System.Drawing.Size(44, 23);
            this.cbErrors.TabIndex = 8;
            this.cbErrors.Text = "Errors";
            this.cbErrors.UseVisualStyleBackColor = true;
            this.cbErrors.CheckedChanged += new System.EventHandler(this.cbOutcomeFilter_CheckedChanged);
            // 
            // cbWarnings
            // 
            this.cbWarnings.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbWarnings.AutoSize = true;
            this.cbWarnings.Checked = true;
            this.cbWarnings.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbWarnings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbWarnings.Location = new System.Drawing.Point(53, 3);
            this.cbWarnings.Name = "cbWarnings";
            this.cbWarnings.Size = new System.Drawing.Size(62, 23);
            this.cbWarnings.TabIndex = 9;
            this.cbWarnings.Text = "Warnings";
            this.cbWarnings.UseVisualStyleBackColor = true;
            this.cbWarnings.CheckedChanged += new System.EventHandler(this.cbOutcomeFilter_CheckedChanged);
            // 
            // cbInformation
            // 
            this.cbInformation.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbInformation.AutoSize = true;
            this.cbInformation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbInformation.Location = new System.Drawing.Point(121, 3);
            this.cbInformation.Name = "cbInformation";
            this.cbInformation.Size = new System.Drawing.Size(69, 23);
            this.cbInformation.TabIndex = 10;
            this.cbInformation.Text = "Information";
            this.cbInformation.UseVisualStyleBackColor = true;
            this.cbInformation.CheckedChanged += new System.EventHandler(this.cbOutcomeFilter_CheckedChanged);
            // 
            // btnCopyClipboard
            // 
            this.btnCopyClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyClipboard.Location = new System.Drawing.Point(640, 185);
            this.btnCopyClipboard.Name = "btnCopyClipboard";
            this.btnCopyClipboard.Size = new System.Drawing.Size(118, 27);
            this.btnCopyClipboard.TabIndex = 6;
            this.btnCopyClipboard.Text = "Copy to clipboard";
            this.btnCopyClipboard.UseVisualStyleBackColor = true;
            this.btnCopyClipboard.Click += new System.EventHandler(this.btnCopyClipboard_Click);
            // 
            // txtOutcome
            // 
            this.txtOutcome.AcceptsTab = true;
            this.txtOutcome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutcome.Location = new System.Drawing.Point(10, 20);
            this.txtOutcome.Multiline = true;
            this.txtOutcome.Name = "txtOutcome";
            this.txtOutcome.ReadOnly = true;
            this.txtOutcome.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutcome.Size = new System.Drawing.Size(748, 159);
            this.txtOutcome.TabIndex = 0;
            // 
            // mainStrip
            // 
            this.mainStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainStatusLabel});
            this.mainStrip.Location = new System.Drawing.Point(0, 656);
            this.mainStrip.Name = "mainStrip";
            this.mainStrip.Size = new System.Drawing.Size(793, 22);
            this.mainStrip.TabIndex = 4;
            this.mainStrip.Text = "statusStrip1";
            // 
            // mainStatusLabel
            // 
            this.mainStatusLabel.AutoSize = false;
            this.mainStatusLabel.Name = "mainStatusLabel";
            this.mainStatusLabel.Size = new System.Drawing.Size(778, 17);
            this.mainStatusLabel.Spring = true;
            this.mainStatusLabel.Text = "(there should be something here)";
            this.mainStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkGenSnapshot);
            this.groupBox1.Controls.Add(this.chkDisableFP);
            this.groupBox1.Controls.Add(this.chkShowTraceInfo);
            this.groupBox1.Controls.Add(this.chkXsdValidation);
            this.groupBox1.Controls.Add(this.btnReload);
            this.groupBox1.Controls.Add(this.btnSettings);
            this.groupBox1.Controls.Add(this.lblTerminologySvc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblDefinitionPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 507);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(766, 129);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // chkGenSnapshot
            // 
            this.chkGenSnapshot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkGenSnapshot.AutoSize = true;
            this.chkGenSnapshot.Checked = global::Furore.Fhir.ValidationDemo.Properties.Settings.Default.RegenerateSnapshot;
            this.chkGenSnapshot.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Furore.Fhir.ValidationDemo.Properties.Settings.Default, "RegenerateSnapshot", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkGenSnapshot.Location = new System.Drawing.Point(418, 19);
            this.chkGenSnapshot.Name = "chkGenSnapshot";
            this.chkGenSnapshot.Size = new System.Drawing.Size(133, 17);
            this.chkGenSnapshot.TabIndex = 24;
            this.chkGenSnapshot.Text = "Regenerate snapshots";
            this.chkGenSnapshot.UseVisualStyleBackColor = true;
            // 
            // chkDisableFP
            // 
            this.chkDisableFP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDisableFP.AutoSize = true;
            this.chkDisableFP.Checked = global::Furore.Fhir.ValidationDemo.Properties.Settings.Default.DisableFP;
            this.chkDisableFP.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Furore.Fhir.ValidationDemo.Properties.Settings.Default, "DisableFP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkDisableFP.Location = new System.Drawing.Point(248, 19);
            this.chkDisableFP.Name = "chkDisableFP";
            this.chkDisableFP.Size = new System.Drawing.Size(141, 17);
            this.chkDisableFP.TabIndex = 23;
            this.chkDisableFP.Text = "Disable Fhir&Path checks";
            this.chkDisableFP.UseVisualStyleBackColor = true;
            // 
            // chkShowTraceInfo
            // 
            this.chkShowTraceInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkShowTraceInfo.AutoSize = true;
            this.chkShowTraceInfo.Checked = global::Furore.Fhir.ValidationDemo.Properties.Settings.Default.EnableTrace;
            this.chkShowTraceInfo.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Furore.Fhir.ValidationDemo.Properties.Settings.Default, "EnableTrace", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkShowTraceInfo.Location = new System.Drawing.Point(13, 19);
            this.chkShowTraceInfo.Name = "chkShowTraceInfo";
            this.chkShowTraceInfo.Size = new System.Drawing.Size(108, 17);
            this.chkShowTraceInfo.TabIndex = 21;
            this.chkShowTraceInfo.Text = "&Trace information";
            this.chkShowTraceInfo.UseVisualStyleBackColor = true;
            // 
            // chkXsdValidation
            // 
            this.chkXsdValidation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkXsdValidation.AutoSize = true;
            this.chkXsdValidation.Checked = global::Furore.Fhir.ValidationDemo.Properties.Settings.Default.DoXsdValidation;
            this.chkXsdValidation.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Furore.Fhir.ValidationDemo.Properties.Settings.Default, "DoXsdValidation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkXsdValidation.Location = new System.Drawing.Point(135, 19);
            this.chkXsdValidation.Name = "chkXsdValidation";
            this.chkXsdValidation.Size = new System.Drawing.Size(92, 17);
            this.chkXsdValidation.TabIndex = 22;
            this.chkXsdValidation.Text = "&Xsd validation";
            this.chkXsdValidation.UseVisualStyleBackColor = true;
            // 
            // btnReload
            // 
            this.btnReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReload.Location = new System.Drawing.Point(99, 98);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(116, 23);
            this.btnReload.TabIndex = 20;
            this.btnReload.Text = "&Reload Definitions";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSettings.Location = new System.Drawing.Point(12, 98);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSettings.TabIndex = 19;
            this.btnSettings.Text = "Change...";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // lblTerminologySvc
            // 
            this.lblTerminologySvc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTerminologySvc.AutoSize = true;
            this.lblTerminologySvc.Location = new System.Drawing.Point(117, 72);
            this.lblTerminologySvc.Name = "lblTerminologySvc";
            this.lblTerminologySvc.Size = new System.Drawing.Size(61, 13);
            this.lblTerminologySvc.TabIndex = 18;
            this.lblTerminologySvc.Text = "(generated)";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Terminology servers:";
            // 
            // lblDefinitionPath
            // 
            this.lblDefinitionPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDefinitionPath.AutoSize = true;
            this.lblDefinitionPath.Location = new System.Drawing.Point(117, 54);
            this.lblDefinitionPath.Name = "lblDefinitionPath";
            this.lblDefinitionPath.Size = new System.Drawing.Size(61, 13);
            this.lblDefinitionPath.TabIndex = 16;
            this.lblDefinitionPath.Text = "(generated)";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Path to definitions:";
            // 
            // openInstance
            // 
            this.openInstance.AddExtension = false;
            this.openInstance.Filter = "XML|*.xml|Json|*.json";
            this.openInstance.Title = "Open an instance";
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnValidate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 678);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.mainStrip);
            this.Controls.Add(this.instanceBox);
            this.Controls.Add(this.groupBox3);
            this.Name = "MainForm";
            this.Text = ".NET Profile Validation Tool 1.5 (STU3)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.instanceBox.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.mainStrip.ResumeLayout(false);
            this.mainStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox instanceBox;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.RichTextBox txtInstanceXml;
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
        private System.Windows.Forms.CheckBox chkGenSnapshot;
        private System.Windows.Forms.CheckBox chkDisableFP;
        private System.Windows.Forms.CheckBox chkShowTraceInfo;
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

