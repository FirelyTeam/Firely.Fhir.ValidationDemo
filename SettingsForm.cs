using Firely.Fhir.ValidationDemo.Properties;
using System.Data;

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

        private void BtnOpenProfileDir_Click(object sender, EventArgs e)
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

        public bool RegenerateSnapshots => chkGenSnapshot.Checked;

        private void CbxTermServers_Leave(object sender, EventArgs e)
        {
            var newSelection = cbxTermServers.Text;
            if (String.IsNullOrEmpty(newSelection)) return;

            if (!cbxTermServers.Items.OfType<string>().Contains(newSelection))
                cbxTermServers.Items.Add(newSelection);

            Settings.Default.TerminologyServiceList = String.Join("|", cbxTermServers.Items.OfType<string>());
        }
    }
}
