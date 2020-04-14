using Xunit;
using FluentAssertions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data.Tools;
using ProjectManagement.Data.Contexts;
using ProjectManagement.Api.Controllers;

namespace ProjectManagement.Tests
{
    public class TasksControllerTests
    {
        [Fact]
        public async Task SettingParentProjectTaskId_ToTuskFromDifferentProject_ShouldResultInBadRequest()
        {
            var options = TestHelper.ContextOptions; //ensure that we have same db in the scope of test

            using (var context = new ProjectManagementContext(options))
            {
                //setup
                var projectsController = new ProjectsController(context, TestHelper.Mapper);
                await projectsController.PostProjectAsync(DataSeeder.NewProject(3));
                await projectsController.PostProjectAsync(DataSeeder.NewProject(9));

                var tasksController = new TasksController(context, TestHelper.Mapper);
                await tasksController.PostProjectTaskAsync(DataSeeder.NewTask(3, 3));
                await tasksController.PostProjectTaskAsync(DataSeeder.NewTask(9, 9));
                await tasksController.PostProjectTaskAsync(DataSeeder.NewTask(6, 3, 3));

                //act
                var task = DataSeeder.NewTask(6, 3, 9);
                var result = await tasksController.PutProjectTaskAsync(task.ProjectTaskId, task);
                
                //check
                result.Should().BeOfType(typeof(BadRequestObjectResult));
            }
        }

        [Fact]
        public async Task AddingTaskWithParentProjectTaskId_ThatPointToAnotherProject_ShouldResultInBadRequest()
        {
            var options = TestHelper.ContextOptions; //ensure that we have same db in the scope of test

            using (var context = new ProjectManagementContext(options))
            {
                //setup
                var projectsController = new ProjectsController(context, TestHelper.Mapper);
                await projectsController.PostProjectAsync(DataSeeder.NewProject(3));
                await projectsController.PostProjectAsync(DataSeeder.NewProject(9));

                var tasksController = new TasksController(context, TestHelper.Mapper);
                await tasksController.PostProjectTaskAsync(DataSeeder.NewTask(3, 3));
                await tasksController.PostProjectTaskAsync(DataSeeder.NewTask(9, 9));

                //act
                var task = DataSeeder.NewTask(6, 3, 9);
                var result = await tasksController.PostProjectTaskAsync(task);

                //check
                result.Result.Should().BeOfType(typeof(BadRequestObjectResult));
            }
        }
    }
}
