using Xunit;
using FluentAssertions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data.Tools;
using ProjectManagement.Data.Contexts;
using ProjectManagement.Api.Controllers;

namespace ProjectManagement.Tests
{
    public class ProjectsControllerTests
    {
        [Fact]
        public async Task AddingNewProject_WithNotExistedParentProject_ShouldResultInBadRequest()
        {
            var options = TestHelper.ContextOptions; //ensure that we have same db in the scope of test

            using (var context = new ProjectManagementContext(options))
            {
                var projectsController = new ProjectsController(context, TestHelper.Mapper);
                var result = await projectsController.PostProjectAsync(DataSeeder.NewProject(3, 9));
                
                //check
                result.Result.Should().BeOfType(typeof(BadRequestObjectResult));
            }
        }

        [Fact]
        public async Task UpdatingProject_SettingParentToNotExistedProject_ShouldResultInBadRequest()
        {
            var options = TestHelper.ContextOptions; //ensure that we have same db in the scope of test

            using (var context = new ProjectManagementContext(options))
            {
                var projectsController = new ProjectsController(context, TestHelper.Mapper);
                await projectsController.PostProjectAsync(DataSeeder.NewProject(3));

                var result = await projectsController.PutProjectAsync(3, DataSeeder.NewProject(3, 9));

                //check
                result.Should().BeOfType(typeof(BadRequestObjectResult));
            }
        }
    }
}
