using Xunit;
using ProjectManagement.Data.Tools;
using ProjectManagement.Data.Contexts;
using ProjectManagement.Api.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagement.Tests
{
    public class TasksControllerTests
    {
        [Fact]
        public async void SettingParentProjectTaskId_ToTuskFromDifferentProject_ShouldResultInBadRequest()
        {
            var options = TestHelper.ContextOptions; //ensure that we have same db in the scope of test

            using (var context = new ProjectManagementContext(options))
            {
                //setup
                var projectsController = new ProjectsController(context, TestHelper.Mapper);
                await projectsController.PostProject(DataSeeder.NewProject(3));
                await projectsController.PostProject(DataSeeder.NewProject(9));

                var tasksController = new TasksController(context, TestHelper.Mapper);
                await tasksController.PostProjectTask(DataSeeder.NewTask(3, 3));
                await tasksController.PostProjectTask(DataSeeder.NewTask(9, 9));
                await tasksController.PostProjectTask(DataSeeder.NewTask(6, 3, 3));

                //act
                var task = DataSeeder.NewTask(6, 3, 9);
                var result = await tasksController.PutProjectTask(task.ProjectTaskId, task);
                
                //check
                result.Should().BeOfType(typeof(BadRequestObjectResult));
            }
        }

        [Fact]
        public async void AddingTaskWithParentProjectTaskId_ThatPointToAnotherProject_ShouldResultInBadRequest()
        {
            var options = TestHelper.ContextOptions; //ensure that we have same db in the scope of test

            using (var context = new ProjectManagementContext(options))
            {
                //setup
                var projectsController = new ProjectsController(context, TestHelper.Mapper);
                await projectsController.PostProject(DataSeeder.NewProject(3));
                await projectsController.PostProject(DataSeeder.NewProject(9));

                var tasksController = new TasksController(context, TestHelper.Mapper);
                await tasksController.PostProjectTask(DataSeeder.NewTask(3, 3));
                await tasksController.PostProjectTask(DataSeeder.NewTask(9, 9));

                //act
                var task = DataSeeder.NewTask(6, 3, 9);
                var result = await tasksController.PostProjectTask(task);

                //check
                result.Result.Should().BeOfType(typeof(BadRequestObjectResult));
            }
        }
    }
}
