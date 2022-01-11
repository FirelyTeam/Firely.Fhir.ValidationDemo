# FHIR Resource Validation

[FHIR format](http://hl7.org/fhir) has a feature called `Profiles` where you can define your rules for your any resource type. [Profilelist - FHIR v4.0.1 (hl7.org)](http://hl7.org/implement/standards/fhir/profilelist.html) documentation provides more information about how to define these profiles.

`Profiles` in FHIR are defined in `StructureDefinition` resource and different profiles can be created to have different required fields in FHIR documents.

We use profiles to validate FHIR data structure, also files can be used to validate FHIR file format using Profiles.

In order to enable validation for pushing data to FHIR Server, `x-ms-profile-validation: true` header should be added into REST call. This will work on your local FHIR Server as well as hosted FHIR Server. 

In order to validate Patient Profile in a Bundle Profile, we need to provide these in Bundle StructureDefinition. After that we can validate a Patient resource in a Bundle.

In this document we will show how to use profiles to validate FHIR data structure on Client Side.

To validate FHIR data structure on Client Side, using Firely .NET SDK is a good option. It has already built-in features to validate FHIR data structure and profiles. We'll use two different profiles one for `Patient` another one for `Bundle` resource includes a patient entry in it.

We have two sample profile files under [Profiles](/Profiles) folder.

in [Program.cs](Program.cs) file we will use these profiles to validate FHIR data structure.

```csharp
// create profile source using `Profiles` folder
 var profileSource = new CachedResolver(new MultiResolver(
     new DirectorySource(@"Profiles",
         new DirectorySourceSettings() { IncludeSubDirectories = true }),
         ZipSource.CreateValidationSource()));

// validation settings
var validationSettings = new ValidationSettings
{
    ResourceResolver = profileSource,
    GenerateSnapshot = true,
    Trace = false,
    ResolveExternalReferences = false
};
var validator = new Hl7.Fhir.Validation.Validato(validationSettings);

// print validation results
Console.WriteLine("\n------------------------------");
Console.WriteLine("Validate a 'Patient':");
var result = validator.Validate(validPatient);
Console.WriteLine(result);
```
