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

            cbxTermServers.DataBindings.Add(new Binding("Text", Settings.Default, "TerminologyService", true, DataSourceUpdateMode.OnPropertyChanged));
            txtProfileDirectory.DataBindings.Add(new Binding("Text", Settings.Default, "ProfileSourceDirectory", true, DataSourceUpdateMode.OnPropertyChanged));
            cbEnableBuiltIn.DataBindings.Add(new Binding("Checked", Settings.Default, "UseBuiltInTX", true, DataSourceUpdateMode.OnPropertyChanged));
            chkGenSnapshot.DataBindings.Add(new Binding("Checked", Settings.Default, "RegenerateSnapshot", true, DataSourceUpdateMode.OnPropertyChanged));
        }

        private void BtnOpenProfileDir_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtProfileDirectory.Text))
                folderBrowserDialog.SelectedPath = txtProfileDirectory.Text;

            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
                txtProfileDirectory.Text = folderBrowserDialog.SelectedPath;
        }

        private void CbxTermServers_Leave(object sender, EventArgs e)
        {
            var newSelection = cbxTermServers.Text;
            if (string.IsNullOrEmpty(newSelection)) return;

            if (!cbxTermServers.Items.OfType<string>().Contains(newSelection))
                cbxTermServers.Items.Add(newSelection);

            Settings.Default.TerminologyServiceList = string.Join("|", cbxTermServers.Items.OfType<string>());
        }
    }
}


