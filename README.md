# ProjectManagement
It's a test task implementation example using .net core 3.1  
You can find task description in `software-challenge.pdf` document
## Dependencies
- Microsoft.EntityFrameworkCore (SqlServer/InMemory with Code-First approach)
- Microsoft.EntityFrameworkCore.Proxies (lazy loading for entities)
- FluentValidation.AspNetCore (validate dto's)
- AutoMapper (mapping entities to dto's and vice versa)
- EPPlus (for composing .xlsx files)
- Microsoft.AspNetCore.Mvc.Testing (integration tests)
- xUnit (unit tests)
- Moq (mocking dependencies in unit tests)
## How to run project management test solution
- `docker-compose up`
- `dotnet ef database update`
- http://localhost/swagger
## Areas of improvement
- in general it's not a very good idea to use lazy loading for entities in production. It is used here for demo purposes only
- add more integration & unit tests to cover more scenarios
- add logging
- consider using EFCore.BulkExtensions package to optimize performance for bulk operations
