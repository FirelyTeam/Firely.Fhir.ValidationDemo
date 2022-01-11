# FHIR Resource Validation

[FHIR format](http://hl7.org/fhir) has a feature called `Profiles` where you can define your rules for your any resource type. [Profilelist - FHIR v4.0.1 (hl7.org)](http://hl7.org/implement/standards/fhir/profilelist.html) documentation provides more information about how to define these profiles. `Profiles` in FHIR are defined in `StructureDefinition` resource and different profiles can be created to have different required fields in FHIR documents.

We use profiles to validate FHIR data structure. In order to enable validation for pushing data to FHIR Server, `x-ms-profile-validation: true` header should be added into REST call. This will work on your local FHIR Server as well as hosted FHIR Server.

In order to validate `Patient` Profile in a `Bundle` Profile, we need to provide profile information in `Bundle` StructureDefinition. After that we can validate a Patient resource in a Bundle.

1. `Patient` Profile is defined in `StructureDefinition` resource.

    ```json
    {
    "resourceType": "StructureDefinition",
    "url": "https://fhir-data-converter.azurehealthcareapis.com/StructureDefinition/FHIRPatientProfile",
    "name": "FHIRPatientProfile",
    "status": "draft",
    "fhirVersion": "4.0.1",
    "mapping": [
        {
        "identity": "rim",
        "uri": "http://hl7.org/v3",
        "name": "RIM Mapping"
        },
        {
        "identity": "cda",
        "uri": "http://hl7.org/v3/cda",
        "name": "CDA (R2)"
        },
        {
        "identity": "w5",
        "uri": "http://hl7.org/fhir/fivews",
        "name": "FiveWs Pattern Mapping"
        },
        {
        "identity": "v2",
        "uri": "http://hl7.org/v2",
        "name": "HL7 v2 Mapping"
        },
        {
        "identity": "loinc",
        "uri": "http://loinc.org",
        "name": "LOINC code for the element"
        }
    ],
    "kind": "resource",
    "abstract": false,
    "type": "Patient",
    "baseDefinition": "http://hl7.org/fhir/StructureDefinition/Patient",
    "derivation": "constraint",
    "differential": {
        "element": [
        {
            "id": "Patient.identifier",
            "path": "Patient.identifier",
            "min": 1
        },
        {
            "id": "Patient.name",
            "path": "Patient.name",
            "min": 1,
            "max": "1"
        },
        {
            "id": "Patient.gender",
            "path": "Patient.gender",
            "min": 1
        }
        ]
    }
    }
    ```

2. `Bundle` Profile is defined in `StructureDefinition` resource.

    ```json
    {
    "resourceType": "StructureDefinition",
    "url": "https://fhir-data-converter.azurehealthcareapis.com/StructureDefinition/FHIRBundle",
    "name": "FHIRBundle",
    "status": "draft",
    "fhirVersion": "4.0.1",
    "mapping": [
        {
        "identity": "rim",
        "uri": "http://hl7.org/v3",
        "name": "RIM Mapping"
        },
        {
        "identity": "cda",
        "uri": "http://hl7.org/v3/cda",
        "name": "CDA (R2)"
        },
        {
        "identity": "w5",
        "uri": "http://hl7.org/fhir/fivews",
        "name": "FiveWs Pattern Mapping"
        },
        {
        "identity": "v2",
        "uri": "http://hl7.org/v2",
        "name": "HL7 v2 Mapping"
        },
        {
        "identity": "loinc",
        "uri": "http://loinc.org",
        "name": "LOINC code for the element"
        }
    ],
    "kind": "resource",
    "abstract": false,
    "type": "Bundle",
    "baseDefinition": "http://hl7.org/fhir/StructureDefinition/Bundle",
    "derivation": "constraint",
    "differential": {
        "element": [
        {
            "id": "Bundle.entry:patient",
            "path": "Bundle.entry.patient",
            "sliceName": "patient",
            "min": 0,
            "max": "1"
        },
        {
            "id": "Bundle.entry:patient.resource",
            "path": "Bundle.entry.patient.resource",
            "min": 0,
            "max": "1",
            "type": [
            {
                "code": "Patient",
                "profile": [
                "https://fhir-data-converter.azurehealthcareapis.com/StructureDefinition/FHIRPatientProfile"
                ]
            }
            ]
        }
        ]
    }
    }
    ```

In this sample we will show how to use profiles to validate FHIR data structure on client side.

To validate FHIR data structure on client side, using Firely .NET SDK is a good option. It has already built-in features to validate FHIR data structure and profiles. We'll use two different profiles one for `Patient` another one for `Bundle` resource includes a patient entry in it.

We have two sample profile files under [Profiles](/Profiles) folder.

in [Program.cs](Program.cs) file we will use these profiles to validate FHIR data structure.

```csharp
...

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

...
```
