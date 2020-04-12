# ProjectManagement
## How to run project management test solution
- specify proper connection string in appsettings.json
- to create a db and populate it with test data specify connection string in DesignTimeProjectManagementContext.cs
and in Package Manager Console run: `Update-Database -Context DesignTimeProjectManagementContext`
## Areas of improvement
- implement advanced validation with fluent validation package and cover all validation scenarios
- add more integration & unit tests to cover more scenarios
- split integration & unit tests into different projects
- add mediatr + cqrs
- add logging
- use EFCore.BulkExtensions package to optimize performance
