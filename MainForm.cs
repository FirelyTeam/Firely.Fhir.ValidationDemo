using Firely.Fhir.Validation;
using Firely.Fhir.ValidationDemo.Properties;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Serialization;
using Hl7.Fhir.Specification.Source;
using Hl7.Fhir.Specification.Terminology;
using Hl7.Fhir.Support;
using Hl7.Fhir.Utility;
using Hl7.Fhir.Validation;
using System.Diagnostics;
using System.Reflection;

namespace Furore.Fhir.ValidationDemo
{

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Create a resource resolver that searches for the core resources in 'specification.zip', which comes with the .NET FHIR Specification NuGet package
            // We create a source that takes its contents from a ZIP file (in this case the default 'specification.zip'). We decorate that source by encapsulating
            // it in a CachedResolver, which speeds up access by caching conformance resources once we got them from the large files in the ZIP.
            _coreSource = new CachedResolver(ZipSource.CreateValidationSource());

            _settingsForm = new SettingsForm();

            Version version = Assembly.GetExecutingAssembly().GetName().Version ?? new Version("0.0.0");
            Text = Text + " " + version.Major + "." + version.Minor + " (build " + version.Build + ")"; //change form titl

            // Other initializations are done on the form_load
        }

        private readonly IAsyncResourceResolver _coreSource;
        private Validator? _validator;
        private readonly SettingsForm _settingsForm;

        private void BtnReload_Click(object sender, EventArgs e) => _validator = RebuildValidator();

        private void MainForm_Load(object sender, EventArgs e)
        {
            _validator = RebuildValidator();
            ShowStatusMessage();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
        }

        private static void SaveSettings()
        {
            Settings.Default.Save();
        }

        private Validator RebuildValidator()
        {
            var profileSource = RefreshProfileSource(_settingsForm.ProfileDirectory is { } pd ?
                new DirectoryInfo(pd) : null, _settingsForm.RegenerateSnapshots);
            var terminologySource = RefreshTerminologySource(profileSource);
            return new Validator(terminologySource, profileSource, null);
        }


        private OperationOutcome? _lastOutcome;

        private void SetOutcome(OperationOutcome? outcome)
        {
            _lastOutcome = outcome;
            RefreshOutcome();
        }

        private void RefreshOutcome()
        {
            var outcome = _lastOutcome;

            if (outcome == null)
            {
                txtOutcome.Text = null;
                setButtons(null, null, null);
                return;
            }

            var filtered = new OperationOutcome();

            foreach (var issue in outcome.Issue)
            {
                if (issue.Severity == OperationOutcome.IssueSeverity.Error && cbErrors.Checked == false)
                    continue;
                if (issue.Severity == OperationOutcome.IssueSeverity.Warning && cbWarnings.Checked == false)
                    continue;
                if (issue.Severity == OperationOutcome.IssueSeverity.Information && cbInformation.Checked == false)
                    continue;

                filtered.AddIssue(issue);
            }

            setButtons(outcome.Errors, outcome.Warnings, outcome.Issue.Count - outcome.Errors - outcome.Warnings);
            var outcomeText = filtered.ToString();
            outcomeText = outcomeText[outcomeText.IndexOf(Environment.NewLine)..];

            if (outcome.Success)
                outcomeText = "Overall result: SUCCESS" + outcomeText;
            else
                outcomeText = "Overall result: FAILURE" + outcomeText;

            txtOutcome.Text = outcomeText;

            void setButtons(int? errors, int? warnings, int? info)
            {
                cbErrors.Text = $"Errors{(errors != null ? $" ({errors})" : "")}";
                cbWarnings.Text = $"Warnings{(warnings != null ? $" ({warnings})" : "")}";
                cbInformation.Text = $"Information{(info != null ? $" ({info})" : "")}";
            }
        }

        private void BtnValidate_Click(object sender, EventArgs e)
        {
            SetOutcome(null);

            if (string.IsNullOrEmpty(txtInstance.Text))
            {
                MessageBox.Show($"Please provide a FHIR instance in the {instanceBox.Text} textbox above");
                return;
            }

            if (InstanceFormat == ResourceFormat.Unknown)
            {
                MessageBox.Show($"The {instanceBox.Text} textbox above does not contain xml or json");
                return;
            }

            ShowStatusMessage("Starting validation...");
            Cursor = Cursors.WaitCursor;
            Refresh();

            try
            {
                SaveSettings();

                // Configure the validator based on the user's settings
                // This includes a reference to the resolver that we have constructed in previous methods
                // and which helps the validator to look for profiles
                _validator!.SkipConstraintValidation = chkDisableFP.Checked;
                _validator.

                // settings.EnableXsdValidation = chkXsdValidation.Checked;
                settings.ResolveExteralReferences = true;

                var poco = InstanceFormat switch
                {
                    ResourceFormat.Xml => (new FhirXmlParser()).Parse<Resource>(txtInstance.Text),
                    ResourceFormat.Json => (new FhirJsonParser()).Parse<Resource>(txtInstance.Text),
                    _ => throw new InvalidOperationException("Unknown format")
                };

                var sw = Stopwatch.StartNew();
                var result = _validator.Validate(poco);
                sw.Stop();

                // The validator generates an OperationOutcome as output;                
                SetOutcome(result.ToOperationOutcome());
                ShowStatusMessage($"Validation finished in {sw.ElapsedMilliseconds} milliseconds");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.GetType().Name}: {ex.Message}");
                ShowStatusMessage("Validation failed with an exception.");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private IAsyncResourceResolver RefreshProfileSource(DirectoryInfo? profileDirectory, bool regenerateSnapshots)
        {
            var result = _coreSource;

            try
            {
                setSource("Just the core specification");

                if (profileDirectory is not null)
                {
                    if (profileDirectory.Exists)
                    {
                        // We not only have a source for core data, we also read data from a user-specified directory. We also cache the contents of this source, like
                        // we did with the CoreSource above.
                        var directorySource = new CachedResolver(new DirectorySource(profileDirectory.FullName, new DirectorySourceSettings { IncludeSubDirectories = true }));

                        // Finally, we combine both sources, so we will find profiles both from the core zip as well as from the directory.
                        // By mentioning the directory source first, anything in the user directory will override what is in the core zip.
                        result = new MultiResolver(directorySource, _coreSource);

                        setSource($"{profileDirectory.Name} + core specification");
                    }
                    else
                    {
                        setSource($"Just the core specification, since {profileDirectory.Name} does not exist", true);
                    }
                }

                if (regenerateSnapshots)
                    result = new SnapshotSource(result);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Composing the profile source failed: {e.Message}", "Profile source");
            }

            ShowStatusMessage("Profile source was refreshed.");

            return result;

            void setSource(string source, bool error = false)
            {
                lblDefinitionPath.Text = source;
                if (error)
                    lblDefinitionPath.ForeColor = Color.Red;
                else
                    lblDefinitionPath.ForeColor = DefaultForeColor;
            }
        }

        private ITerminologyService RefreshTerminologySource(IAsyncResourceResolver resolver)
        {
            ITerminologyService terminologySource = new LocalTerminologyService(resolver);
            setTX("Built-in terminology service");
            var extTS = _settingsForm.TerminologyServer;

            if (!string.IsNullOrEmpty(extTS))
            {
                terminologySource = new ExternalTerminologyService(new FhirClient(extTS));
                setTX($"Terminology service at {extTS}");

                if (_settingsForm.UseBuiltinTx)
                {
                    var local = new LocalTerminologyService(resolver);
                    terminologySource = new FallbackTerminologyService(local, terminologySource);
                    setTX($"Built-in terminology service, then service at {extTS}");
                }
            }

            return terminologySource;

            void setTX(string label) => lblTerminologySvc.Text = label;
        }


        public void ShowStatusMessage(string? message = null)
        {
            mainStatusLabel.Text = message is not null ? $"[{DateTime.Now:t}] {message}" : "Ready";

            Refresh();
        }

        private void TxtInstanceXml_TextChanged(object sender, EventArgs e)
        {
            var text = txtInstance.Text;
            if (!string.IsNullOrEmpty(text))
            {
                if (SerializationUtil.ProbeIsXml(text))
                    InstanceFormat = ResourceFormat.Xml;
                else if (SerializationUtil.ProbeIsJson(text))
                    InstanceFormat = ResourceFormat.Json;
                else
                    InstanceFormat = ResourceFormat.Unknown;
            }
            else
                InstanceFormat = ResourceFormat.Unknown;
        }

        private ResourceFormat _instanceFormat;
        public ResourceFormat InstanceFormat
        {
            get => _instanceFormat;
            set
            {
                _instanceFormat = value;
                switch (_instanceFormat)
                {
                    case ResourceFormat.Xml:
                        instanceBox.Text = "Instance (Xml)";
                        break;
                    case ResourceFormat.Json:
                        instanceBox.Text = "Instance (Json)";
                        break;
                    case ResourceFormat.Unknown:
                        instanceBox.Text = "Instance";
                        break;
                }
            }
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            _settingsForm.ShowDialog();

            _validator = RebuildValidator();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            if (openInstance.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var txt = File.ReadAllText(openInstance.FileName);
                    txtInstance.Text = txt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Open file failed: " + ex.Message);
                }
            }
        }

        private void BtnCopyClipboard_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtOutcome.Text))
                Clipboard.SetText(txtOutcome.Text);
        }

        private void CbOutcomeFilter_CheckedChanged(object sender, EventArgs e)
        {
            RefreshOutcome();
        }
    }
}
