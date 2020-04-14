using Xunit;
using FluentAssertions;
using ProjectManagement.Data.Tools;
using ProjectManagement.Data.Contexts;
using ProjectManagement.Data.Entities;
using ProjectManagement.Api.Controllers;
using System.Threading.Tasks;

namespace ProjectManagement.Tests
{
    public class IntegrationTests
    {
        [Fact]
        public async Task SettingTaskStateToInProgress_AlsoSetsAllParentProjectsStatesToInProgress()
        {
            var options = TestHelper.ContextOptions; //ensure that we have same db in the scope of test

            using (var context = new ProjectManagementContext(options))
            {
                //setup
                var projectsController = new ProjectsController(context, TestHelper.Mapper);
                await projectsController.PostProjectAsync(DataSeeder.NewProject(3));
                await projectsController.PostProjectAsync(DataSeeder.NewProject(6, 3));
                await projectsController.PostProjectAsync(DataSeeder.NewProject(9, 6));

                var tasksController = new TasksController(context, TestHelper.Mapper);
                await tasksController.PostProjectTaskAsync(DataSeeder.NewTask(12, 9));

                //act
                var task = DataSeeder.NewTask(12, 9);
                task.State = ItemState.InProgress;
                await tasksController.PutProjectTaskAsync(task.ProjectTaskId, task);
            }

            //check
            using (var context = new ProjectManagementContext(options))
            {
                var projectsController = new ProjectsController(context, TestHelper.Mapper);

                var project = await projectsController.GetProjectAsync(9);
                project.Value.State.Should().Be(ItemState.InProgress);

                project = await projectsController.GetProjectAsync(6);
                project.Value.State.Should().Be(ItemState.InProgress);

                project = await projectsController.GetProjectAsync(3);
                project.Value.State.Should().Be(ItemState.InProgress);
            }
        }

        [Fact]
        public async Task SettingTaskStateToComplete_AlsoSetsAllParentProjectsStatesToComplete_WhenAllProjectTasksComplete()
        {
            var options = TestHelper.ContextOptions; //ensure that we have same db in the scope of test

            using (var context = new ProjectManagementContext(options))
            {
                //setup
                var projectsController = new ProjectsController(context, TestHelper.Mapper);
                await projectsController.PostProjectAsync(DataSeeder.NewProject(3));
                await projectsController.PostProjectAsync(DataSeeder.NewProject(6, 3));
                await projectsController.PostProjectAsync(DataSeeder.NewProject(9, 6));

                var tasksController = new TasksController(context, TestHelper.Mapper);
                await tasksController.PostProjectTaskAsync(DataSeeder.NewTask(9, 9));
                await tasksController.PostProjectTaskAsync(DataSeeder.NewTask(3, 3));

                //act
                var task = DataSeeder.NewTask(9, 9);
                task.State = ItemState.Completed;
                await tasksController.PutProjectTaskAsync(task.ProjectTaskId, task);
            }

            //check
            using (var context = new ProjectManagementContext(options))
            {
                var projectsController = new ProjectsController(context, TestHelper.Mapper);

                var project = await projectsController.GetProjectAsync(9);
                project.Value.State.Should().Be(ItemState.Completed);

                project = await projectsController.GetProjectAsync(6);
                project.Value.State.Should().Be(ItemState.Completed);

                project = await projectsController.GetProjectAsync(3);
                project.Value.State.Should().Be(ItemState.Planned);
            }
        }

        [Fact]
        public async Task DeletingTask_SetsSubtasksParentProjectTaskId_ToNull()
        {
            var options = TestHelper.ContextOptions; //ensure that we have same db in the scope of test

            using (var context = new ProjectManagementContext(options))
            {
                //setup
                var projectsController = new ProjectsController(context, TestHelper.Mapper);
                await projectsController.PostProjectAsync(DataSeeder.NewProject(3));

                var tasksController = new TasksController(context, TestHelper.Mapper);
                await tasksController.PostProjectTaskAsync(DataSeeder.NewTask(3, 3));
                await tasksController.PostProjectTaskAsync(DataSeeder.NewTask(33, 3, 3));
                await tasksController.PostProjectTaskAsync(DataSeeder.NewTask(333, 3, 3));

                //act
                var task = DataSeeder.NewTask(3, 3);
                await tasksController.DeleteProjectTaskAsync(task.ProjectTaskId);
            }

            //check
            using (var context = new ProjectManagementContext(options))
            {
                var tasksController = new TasksController(context, TestHelper.Mapper);

                var task = await tasksController.GetProjectTaskAsync(33);
                task.Value.ParentProjectTaskId.Should().BeNull();

                task = await tasksController.GetProjectTaskAsync(333);
                task.Value.ParentProjectTaskId.Should().BeNull();
            }
        }
    }
}
