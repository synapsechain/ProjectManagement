# ProjectManagement
It's a test task implementation example using .net core 3.1  
You can find task description in `software-challenge.pdf` document  
Excel file generation (/file endpoint) currently works on Windows only due to EPPlus package limitations
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
- `docker-compose up` to run image of sql server locally
- `dotnet ef database update` to setup database
- http://localhost:3333/swagger
## Areas of improvement
- in general it's not a very good idea to use lazy loading for entities in production. It is used here for demo purposes only
- Change EPPlus package for excel file generation to something cross-platform to support linux
- add more integration & unit tests to cover more scenarios
- add logging
- consider using EFCore.BulkExtensions package to optimize performance for bulk operations
