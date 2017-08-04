using Furore.Fhir.ValidationDemo.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Furore.Fhir.ValidationDemo
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            var txServers = Settings.Default.TerminologyServiceList.Split('|').Select(s => s.Trim());
            cbxTermServers.Items.AddRange(txServers.ToArray());
        }

        private void btnOpenProfileDir_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtProfileDirectory.Text))
                folderBrowserDialog.SelectedPath = txtProfileDirectory.Text;

            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
                txtProfileDirectory.Text = folderBrowserDialog.SelectedPath;
        }

        public string ProfileDirectory => txtProfileDirectory.Text;

        public string TerminologyServer => cbxTermServers.Text;

        public bool UseBuiltinTx => cbEnableBuiltIn.Checked;

        private void cbxTermServers_Leave(object sender, EventArgs e)
        {
            var newSelection = cbxTermServers.Text;
            if (String.IsNullOrEmpty(newSelection)) return;

            if (!cbxTermServers.Items.OfType<string>().Contains(newSelection))
                cbxTermServers.Items.Add(newSelection);

            Settings.Default.TerminologyServiceList = String.Join("|", cbxTermServers.Items.OfType<string>());
        }
    }
}
