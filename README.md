EveryBodyCodes
Struture 4 layers:

controllers - api entry layer
business - business logic rules
Cross layer - to share between layers common models, entities, extensions, and helpers
External Services - should be used to connecto with services
Comments:

Prime Number Action Filter was implemented within the controller layers as PrimeNumberActionFilter.cs.

Simple custom sort, configurable in appsettings. json, "NumbersOrder" key: "desc"

I've added swagger ui, so literally run the solution and go for it.
