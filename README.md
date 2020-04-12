# ProjectManagement
## How to run project management test solution
- specify proper connection string in appsettings.json
- to create a db and populate it with test data specify connection string in DesignTimeProjectManagementContext.cs
and in Package Manager Console run: `Update-Database -Context DesignTimeProjectManagementContext`
## Areas of improvement
- add mediatr + cqrs
- add logging
