This is a basic WinForms application to experiment with the profile validation capacities of the FHIR .NET API (https://github.com/FirelyTeam/fhir-net-api, also available on NuGet).

To get started, there's a comprehensive set of examples in the examples directory.  Start the application from the Release directory, and press the 'Change...' button. Point the application to the examples directory so the validator knows where to find the profiles used in the validation process.

Also, click 'Regenerate snapshots' as the example profiles don't come with a snapshot to keep the size of the zip manageable.

Now either paste an example or press 'Load...' and load an example (e.g. Mainbundle.bundle.xml or Weight.observation.xml), then press "Validate".  




Happy experimenting, The Firely team