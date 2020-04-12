using Xunit;
using ProjectManagement.Data.Tools;
using ProjectManagement.Data.Contexts;
using ProjectManagement.Api.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagement.Tests
{
    public class ProjectsControllerTests
    {
        [Fact]
        public async void AddingNewProject_WithNotExistedParentProject_ShouldResultInBadRequest()
        {
            var options = TestHelper.ContextOptions; //ensure that we have same db in the scope of test

            using (var context = new ProjectManagementContext(options))
            {
                var projectsController = new ProjectsController(context, TestHelper.Mapper);
                var result = await projectsController.PostProject(DataSeeder.NewProject(3, 9));
                
                //check
                result.Result.Should().BeOfType(typeof(BadRequestObjectResult));
            }
        }

        [Fact]
        public async void UpdatingProject_SettingParentToNotExistedProject_ShouldResultInBadRequest()
        {
            var options = TestHelper.ContextOptions; //ensure that we have same db in the scope of test

            using (var context = new ProjectManagementContext(options))
            {
                var projectsController = new ProjectsController(context, TestHelper.Mapper);
                await projectsController.PostProject(DataSeeder.NewProject(3));

                var result = await projectsController.PutProject(3, DataSeeder.NewProject(3, 9));

                //check
                result.Should().BeOfType(typeof(BadRequestObjectResult));
            }
        }
    }
}
