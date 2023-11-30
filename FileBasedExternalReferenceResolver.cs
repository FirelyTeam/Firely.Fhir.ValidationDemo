using Firely.Fhir.Validation;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Serialization;
using M = Hl7.Fhir.Model;

namespace Furore.Fhir.ValidationDemo
{
    public class FileBasedExternalReferenceResolver(DirectoryInfo baseDirectory) : IExternalReferenceResolver
    {
        public DirectoryInfo BaseDirectory { get; private set; } = baseDirectory;

        public Task<object?> ResolveAsync(string reference)
        {
            // Now, for our examples we've used the convention that the file can be found in the
            // example directory, with the name <id>.<type>.xml, so let's try to get that file.
            var identity = new ResourceIdentity(reference);
            var filename = $"{identity.Id}.{identity.ResourceType}.xml";
            var path = Path.Combine(BaseDirectory.FullName, filename);

            if (File.Exists(path))
            {
                var xml = File.ReadAllText(path);

                // Note, this will throw if the file is not really FHIR xml
                var poco = (new FhirXmlParser()).Parse<M.Resource>(xml);

                return Task.FromResult<object?>(poco);
            }
            else
            {
                // Unsuccessful
                return Task.FromResult<object?>(null);
            }

        }
    }
}
