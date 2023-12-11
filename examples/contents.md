This examples directory contains several (xml) data files that make up a fictituous Bundle with patient data. Also included are several profiles that showcases the profiling capabilities of FHIR and which can be used to try the validator.

### Example instance data
* `MainBundle.bundle.xml` - a FHIR `Bundle` that represents a document, with two sections (Vital signs and Additional notes), plus a Practitioner instance ("Hippocrates"). 
* `MainBundle-errors.bundle.xml` - a FHIR `Bundle` that represents the same document, but then with a lot of errors in the instance. 
* `Hippocrates.practitioner.xml` - The same data as the Hippocrates included in the Bundle, but then as a separate resource.
* `Levin.patient.xml` - A FHIR `Patient` (Henri Levin), that is referenced from the Bundle.
* `Weight.observation.xml` - A body weight FHIR `Observation`, that is referenced from the Bundle.

Each of these resources declare their conformance to one of the profiles defined below using the `Meta.profile` construct.

### Example conformance files

* `HeightQuantity.structuredefinition.xml` - a profile on `Quantity` that defines a height: 
    * There must be a system, which must be UCUM
    * There must be a code, which must be "cm"
    * There may not be a comparator
    * The value must be present and between 0 and 350.
* `WeightQuantity.structuredefinition.xml` - a profile on `Quantity` that defines a weight: 
    * There must be a system, which must be UCUM
    * There must be a code, which must be "kg"
    * There may not be a comparator
    * The value must be present and between 0 and 200.
* `WeightHeightObservation.structuredefinition.xml` - a profile on `Observation` that limits its value to contain a string, a weight or a height (using the profiles defined above).
* `SectionTitles.valueset.xml` - a valueset that is used to codify the sections in the document. Possible values are Advanced directives (`42348-3`), Vital signs (`8716-3`) and Chief complaint (`10154-3`) from `LOINC` and "Practitioner notes" (notes) from a custom `demo-section-titles` codesystem.
* `DocumentComposition.structuredefinition.xml` - defines the constraints on a `Composition` that is used in the main Bundle:
    * Its type must be Discharge Summary (`18842-5`) from LOINC, but other additional codes are also allowed.
    * The subject must be a patient, and must be referenced (so, from outside the bundle)
    * The author must be present and must be a practitioner that is included in the Bundle.
    * Each section must have a title, which is at most 20 characters long.
    * Each section must have at least 1 code which need to be picked from the `SectionTitles` valueset.
    * Each section must have an entry that points to an Observation that is either referenced or bundled.
    * The section may not have an emptyReason or a nested section.
    * There must be exactly 1 section with code `8716-3` (additional codes and display allowed).
    * There may be at most 1 section with code `10154-3`.
    * There may be other sections.
* `DocumentBundle.structuredefinition.xml`  - defines the constraints on the main `Bundle`:
    * It must be of type "document"
    * It cannot have a total or link.
    * There must be at least one entry.



