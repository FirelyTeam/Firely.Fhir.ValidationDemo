using Furore.Fhir.ValidationDemo.Properties;
using Hl7.Fhir.FhirPath;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Serialization;
using Hl7.Fhir.Specification.Source;
using Hl7.Fhir.Specification.Terminology;
using Hl7.Fhir.Utility;
using Hl7.Fhir.Validation;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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

            // [WMR 20170414] NEW
            cboTerminology.SelectedIndex = 1;
        }

        internal IResourceResolver DirectorySource;
        internal IResourceResolver CoreSource;
        internal IResourceResolver CombinedSource;

        private void refreshProfileSource()
        {
            try
            {
                var profilePath = txtProfileDirectory.Text;

                if (!String.IsNullOrEmpty(profilePath) && Directory.Exists(profilePath))
                {
                    // We not only have a source for core data, we also read data from a user-specified directory. We also cache the contents of this source, like
                    // we did with the CoreSource above.
                    DirectorySource = new CachedResolver(new DirectorySource(profilePath, includeSubdirectories: true));

                    // Finally, we combine both sources, so we will find profiles both from the core zip as well as from the directory.
                    // By mentioning the directory source first, anything in the user directory will override what is in the core zip.
                    CombinedSource = new MultiResolver(DirectorySource, CoreSource);

                }
                else
                    CombinedSource = CoreSource;
            }
            catch(Exception e)
            {
                MessageBox.Show($"Composing the profile source failed: {e.Message}", "Profile source");
            }
        }

        private void txtProfileDirectory_TextChanged(object sender, EventArgs e)
        {
            refreshProfileSource();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            refreshProfileSource();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            refreshProfileSource();
        }

        private void btnOpenProfileDir_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtProfileDirectory.Text))
                folderBrowserDialog.SelectedPath = txtProfileDirectory.Text;

            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
                txtProfileDirectory.Text = folderBrowserDialog.SelectedPath;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.Save();
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            // [WMR 20170414] NEW - Clear output
            txtOutcome.Text = null;
            Cursor = Cursors.WaitCursor;
            Refresh();

            string output = null;
            try
            {
                Settings.Default.Save();

                if (String.IsNullOrEmpty(txtInstanceXml.Text))
                {
                    output = "Please provide an Xml FHIR instance in the textbox above";
                }
                else
                {
                    // Configure the validator based on the user's settings
                    // This includes a reference to the resolver that we have constructed in previous methods
                    // and which helps the validator to look for profiles
                    ValidationSettings settings = ValidationSettings.Default;
                    settings.EnableXsdValidation = chkXsdValidation.Checked;
                    settings.Trace = chkShowTraceInfo.Checked;
                    settings.ResourceResolver = this.CombinedSource;
                    settings.SkipConstraintValidation = chkDisableFP.Checked;
                    settings.ResolveExteralReferences = true;
                    settings.GenerateSnapshot = true;

                    // [WMR 20170414] NEW
                    switch (cboTerminology.SelectedIndex)
                    {
                        case 0: // None
                            break;
                        case 1: // Local
                            settings.TerminologyService = new LocalTerminologyServer(CombinedSource);
                            break;
                        case 2: // Grahame
                            var client = new FhirClient("http://fhir3.healthintersections.com.au/open");
                            settings.TerminologyService = new ExternalTerminologyService(client);
                            break;
                    }

                    // This is a really cheap operation, so we can safely create a new one when we need
                    var validator = new Validator(settings);
                    validator.OnExternalResolutionNeeded += onGetExampleResource;

                    // In this case we use an XmlReader as input, but the validator has
                    // overloads for using POCO's too
                    var reader = SerializationUtil.XmlReaderFromXmlText(txtInstanceXml.Text);

                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    // The validator generates an OperationOutcome as output;
                    OperationOutcome result = validator.Validate(reader);
                    sw.Stop();

                    output = result.ToString() + $"\r\n\r\nValidation run took {sw.ElapsedMilliseconds} miliseconds";
                }

            }
            catch (Exception ex)
            {
                output = $"{ex.GetType().Name}: {ex.Message}";
            }
            finally
            {
                Cursor = Cursors.Default;
                txtOutcome.Text = output;
            }
        }

        private void onGetExampleResource(object sender, OnResolveResourceReferenceEventArgs e)
        {
            var referenceToResolve = e.Reference;

            // Now, for our examples we've used the convention that the file can be found in the
            // example directory, with the name <id>.<type>.xml, so let's try to get that file.
            ResourceIdentity reference = new ResourceIdentity(referenceToResolve);
            var filename = $"{reference.Id}.{reference.ResourceType}.xml";
            var path = Path.Combine(txtProfileDirectory.Text, filename);

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
                e.Result = new PocoNavigator(poco);
            }
            else
            {
                // Unsuccessful
                e.Result = null;
            }

        }
    }
}
