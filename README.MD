### Why did I use what?
* **I used .NET Core 5.0.**
* **I used Onion architecture.** Many projects are written with microservice architecture in these days. It is also suitable for this one.
* **I used MediatR.** I think it is a nice and useful framework for the pipeline, which is widely used in REST APIs developed with C# .NET Core.
* **I used EntityFrameworkCore.** I prefer it because it is the most common ORM framework for RDBMS databases. When I thought about domain layer, code first method was a better option. It can be in any database. (RDBMS or NOSQL)
* **I used XUnit.** I used XUnit for unit tests.
* **I used Swagger.** I used REST Api for documentation. Note: It comes by default when creating a new Web Api in .NET Core 5.0.
* I kept the handlers separately as **Commants and Queries**. The reason for this is what I have experienced this until now, and I think it is more reliable and manageable to keep the operations to write directly to the database in CRUD operations. [See](https://henriquesd.medium.com/the-command-and-query-responsibility-segregation-cqrs-pattern-16cb7704c809#:~:text=The%20Command%20and%20Query%20Responsibility%20Segregation%20(CQRS)%20it's%20an%20architectural,are%20responsible%20for%20update%20data)

### Unit Tests
![](docs/tests_result.PNG)

# Packages
`dotnet add package Microsoft.EntityFrameworkCore --version 5.0.0`

`dotnet add package Microsoft.EntityFrameworkCore.Relational --version 5.0.0`

`dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.0`

`dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 5.0.0`

`dotnet add package Swashbuckle.AspNetCore --version 5.6.3`

`dotnet add package FluentValidation --version 10.1.0`

`dotnet add package MediatR --version 9.0.0`

`dotnet add package xunit --version 2.4.1`

### Links and References
[XUnit – Part 5: Share Test Context With IClassFixture and ICollectionFixture](https://hamidmosalla.com/2020/02/02/xunit-part-5-share-test-context-with-iclassfixture-and-icollectionfixture/)
[https://xunit.net/docs/shared-context#collection-fixture](https://xunit.net/docs/shared-context#collection-fixture)
[ASP.NET Core 'de birim test denetleyicisi mantığı](https://docs.microsoft.com/tr-tr/aspnet/core/mvc/controllers/testing?view=aspnetcore-5.0)
