### Neyi neden kullandım?
* **.NET Core 5.0 kullandım.**
* **Onion mimarisi kullandım.** Günümüzde bir çok proje microservice mimarisiyle yazılmakta. Uygulamanın da bu mimariye uygun bir uygulama olduğunu düşündüm.
* **MediatR kullandım.** Yaygın olarak yine C# .NET Core ile geliştirilen REST Api'lerde kullanılan pipeline için güzel ve kullanışlı bir framework olduğunu düşünüyorum.
* **EntityFrameworkCore kullandım.** RDBMS veri tabanları için en yaygın ORM framework olduğundan tercih ediyorum. Domain'i düşünürken database bağımlı düşünmedim. Her hangi bir NoSQL databasede olabilir.
* **XUnit kullandım.** Unit testler için XUnit kullandım.
* **Swagger kullandım.** REST Api dökümantasyon için kullandım. Not: .NET Core 5.0'da yeni bir Web Api oluşturulurken default olarak geliyor.
* **Commants ve Queries** olarak handlerları ayrı tuttum. Bunun sebebi hem bu zamana kadar böyle gördüm hemde CRUD işlemlerde database doğrudan yazan işlemlerin ayrı tutulması daha güvenilir ve yönetilebilir olduğunu düşünüyorum. [Bkz](https://henriquesd.medium.com/the-command-and-query-responsibility-segregation-cqrs-pattern-16cb7704c809#:~:text=The%20Command%20and%20Query%20Responsibility%20Segregation%20(CQRS)%20it's%20an%20architectural,are%20responsible%20for%20update%20data)

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
