# GodeTech.Microservices.EntityFrameworkCore

[Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/). This ORM is recommended for new projects. It allows microservice to be run without operating system constraints. E.g. Linux and Windows operating systems can be used. 

**NOTE**: Both ORMs provide the same amount of functionality but EF Core doesn't have host OS constraints.

In order to use EF Core ORM the following initializer must be added to `Startup.CreateInitializers()` method:

```csharp
yield return new EntityFrameworkInitializer<PlatformerDbContext>(Configuration);
```

Repository implementations follow best practices recommended for modern data layers. The following articles must be useful to understand main design decisions:

* [Repository implementation](https://www.infoq.com/articles/repository-implementation-strategies)
* [Specification pattern](https://enterprisecraftsmanship.com/2016/02/08/specification-pattern-c-implementation/)
* [Microsoft Example of EF Core repository](https://github.com/dotnet-architecture/eShopOnWeb/blob/b864be9265545fa78ff8fb90a4824dfa7618e676/src/Infrastructure/Data/EfRepository.cs)
