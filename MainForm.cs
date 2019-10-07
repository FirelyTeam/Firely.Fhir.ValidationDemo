using Furore.Fhir.ValidationDemo.Properties;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Serialization;
using Hl7.Fhir.Specification.Source;
using Hl7.Fhir.Specification.Terminology;
using Hl7.Fhir.Support;
using Hl7.Fhir.Utility;
using Hl7.Fhir.Validation;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

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
            CoreSource = new CachedResolver(ZipSource.CreateValidationSource());

            _settingsForm = new SettingsForm();

            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            Text = Text + " " + version.Major + "." + version.Minor + " (build " + version.Build + ")"; //change form titl

            // Other initializations are done on the form_load
        }

        internal IResourceResolver CoreSource;
        internal IResourceResolver ProfileSource;

        internal ITerminologyService TerminologySource;

        private SettingsForm _settingsForm;

        private void btnReload_Click(object sender, EventArgs e)
        {
            ProfileSource = refreshProfileSource();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ProfileSource = refreshProfileSource();
            refreshTerminologySource(ProfileSource);

            ShowStatusMessage();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
        }


        private void SaveSettings()
        {
            Settings.Default.Save();
        }

        private OperationOutcome _lastOutcome;

        private void setOutcome(OperationOutcome outcome)
        {
            _lastOutcome = outcome;
            refreshOutcome();
        }

        private void refreshOutcome()
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
            outcomeText = outcomeText.Substring(outcomeText.IndexOf(Environment.NewLine));

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

        private void btnValidate_Click(object sender, EventArgs e)
        {
            setOutcome(null);

            if (String.IsNullOrEmpty(txtInstanceXml.Text))
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
                ValidationSettings settings = ValidationSettings.CreateDefault();
                settings.EnableXsdValidation = chkXsdValidation.Checked;
                settings.Trace = chkShowTraceInfo.Checked;
                settings.ResourceResolver = this.ProfileSource;
                settings.SkipConstraintValidation = chkDisableFP.Checked;
                settings.ResolveExteralReferences = true;
                settings.GenerateSnapshot = chkGenSnapshot.Checked;
                settings.TerminologyService = this.TerminologySource;

                // This is a really cheap operation, so we can safely create a new one when we need
                var validator = new Validator(settings);
                validator.OnExternalResolutionNeeded += onGetExampleResource;

                // In this case we use an XmlReader as input, but the validator has
                // overloads for using POCO's too
                Stopwatch sw = new Stopwatch();
                OperationOutcome result = null;

                if (InstanceFormat == ResourceFormat.Xml)
                {
                    var reader = SerializationUtil.XmlReaderFromXmlText(txtInstanceXml.Text);
                    sw.Start();
                    result = validator.Validate(reader);
                    sw.Stop();
                }
                else
                {
                    var poco = (new FhirJsonParser()).Parse<Resource>(txtInstanceXml.Text);
                    sw.Start();
                    result = validator.Validate(poco);
                    sw.Stop();
                }

                // The validator generates an OperationOutcome as output;                
                setOutcome(result);
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

        private IResourceResolver refreshProfileSource()
        {
            var result = CoreSource;

            try
            {
                string profilePath = _settingsForm.ProfileDirectory;
                setSource("Just the core specification");

                if (!String.IsNullOrEmpty(profilePath))
                {
                    if (Directory.Exists(profilePath))
                    {
                        // We not only have a source for core data, we also read data from a user-specified directory. We also cache the contents of this source, like
                        // we did with the CoreSource above.
                        var directorySource = new CachedResolver(new DirectorySource(profilePath, new DirectorySourceSettings { IncludeSubDirectories = true }));

                        // Finally, we combine both sources, so we will find profiles both from the core zip as well as from the directory.
                        // By mentioning the directory source first, anything in the user directory will override what is in the core zip.
                        result = new MultiResolver(directorySource, CoreSource);

                        setSource($"{profilePath} + core specification");
                    }
                    else
                    {
                        setSource($"Just the core specification, since {profilePath} does not exist", true);

                    }
                }
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
                    lblDefinitionPath.ForeColor = System.Drawing.Color.Red;
                else
                    lblDefinitionPath.ForeColor = Control.DefaultForeColor;
            }
        }

        private void refreshTerminologySource(IResourceResolver resolver)
        {
            TerminologySource = new LocalTerminologyService(resolver);
            setTX("Built-in terminology service");
            var extTS = _settingsForm.TerminologyServer;

            if (!String.IsNullOrEmpty(extTS))
            {
                TerminologySource = new ExternalTerminologyService(new FhirClient(extTS));
                setTX($"Terminology service at {extTS}");

                if (_settingsForm.UseBuiltinTx)
                {
                    var local = new LocalTerminologyService(resolver);
                    TerminologySource = new FallbackTerminologyService(local, TerminologySource);
                    setTX($"Built-in terminology service, then service at {extTS}");
                }
            }

            void setTX(string label) => lblTerminologySvc.Text = label;
        }

        private void onGetExampleResource(object sender, OnResolveResourceReferenceEventArgs e)
        {
            var referenceToResolve = e.Reference;

            // Now, for our examples we've used the convention that the file can be found in the
            // example directory, with the name <id>.<type>.xml, so let's try to get that file.
            ResourceIdentity reference = new ResourceIdentity(referenceToResolve);
            var filename = $"{reference.Id}.{reference.ResourceType}.xml";
            var path = Path.Combine(_settingsForm.ProfileDirectory, filename);

            if (File.Exists(path))
            {
                var xml = File.ReadAllText(path);

                // Note, this will throw if the file is not really FHIR xml
                var poco = (new FhirXmlParser()).Parse<Resource>(xml);

                // The validator does not depend on the .NET API POCO's, instead
                // it uses an abstraction called IElementNavigator that can represent
                // the contents of a FHIR resource direcly from a file, from a POCO, 
                // from a database, whatever is necessary. It's also works cross-versions
                // i.e. DSTU2/STU3/release 4 etcetera.
                // For now, we have just implemented this interface for POCO's so, let's
                // create one.
                e.Result = poco.ToTypedElement();
            }
            else
            {
                // Unsuccessful
                e.Result = null;
            }

        }

        public void ShowStatusMessage(string message = null)
        {
            if (message != null)
                mainStatusLabel.Text = $"[{DateTime.Now.ToString("t")}] {message}";
            else
                mainStatusLabel.Text = "Ready";

            Refresh();
        }

        private void txtInstanceXml_TextChanged(object sender, EventArgs e)
        {
            var text = txtInstanceXml.Text;
            if (!String.IsNullOrEmpty(text))
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
        public Hl7.Fhir.Rest.ResourceFormat InstanceFormat
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

        private void btnSettings_Click(object sender, EventArgs e)
        {
            _settingsForm.ShowDialog();
            ProfileSource = refreshProfileSource();
            refreshTerminologySource(ProfileSource);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (openInstance.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var txt = File.ReadAllText(openInstance.FileName);
                    txtInstanceXml.Text = txt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Open file failed: " + ex.Message);
                }
            }
        }

        private void btnCopyClipboard_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtOutcome.Text))
            {
                System.Windows.Forms.Clipboard.SetText(txtOutcome.Text);
            }
        }

        private void cbOutcomeFilter_CheckedChanged(object sender, EventArgs e)
        {
            refreshOutcome();
        }
    }
}
