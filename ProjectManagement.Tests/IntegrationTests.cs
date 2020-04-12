using Xunit;
using FluentAssertions;
using ProjectManagement.Data.Tools;
using ProjectManagement.Data.Contexts;
using ProjectManagement.Data.Entities;
using ProjectManagement.Api.Controllers;

namespace ProjectManagement.Tests
{
    public class IntegrationTests
    {
        [Fact]
        public async void SettingTaskStateToInProgress_AlsoSetsAllParentProjectsStatesToInProgress()
        {
            var options = TestHelper.ContextOptions; //ensure that we have same db in the scope of test

            using (var context = new ProjectManagementContext(options))
            {
                //setup
                var projectsController = new ProjectsController(context, TestHelper.Mapper);
                await projectsController.PostProject(DataSeeder.NewProject(3));
                await projectsController.PostProject(DataSeeder.NewProject(6, 3));
                await projectsController.PostProject(DataSeeder.NewProject(9, 6));

                var tasksController = new TasksController(context, TestHelper.Mapper);
                await tasksController.PostProjectTask(DataSeeder.NewTask(12, 9));

                //act
                var task = DataSeeder.NewTask(12, 9);
                task.State = ItemState.InProgress;
                await tasksController.PutProjectTask(task.ProjectTaskId, task);
            }

            //check
            using (var context = new ProjectManagementContext(options))
            {
                var projectsController = new ProjectsController(context, TestHelper.Mapper);

                var project = await projectsController.GetProject(9);
                project.Value.State.Should().Be(ItemState.InProgress);

                project = await projectsController.GetProject(6);
                project.Value.State.Should().Be(ItemState.InProgress);

                project = await projectsController.GetProject(3);
                project.Value.State.Should().Be(ItemState.InProgress);
            }
        }

        [Fact]
        public async void SettingTaskStateToComplete_AlsoSetsAllParentProjectsStatesToComplete_WhenAllProjectTasksComplete()
        {
            var options = TestHelper.ContextOptions; //ensure that we have same db in the scope of test

            using (var context = new ProjectManagementContext(options))
            {
                //setup
                var projectsController = new ProjectsController(context, TestHelper.Mapper);
                await projectsController.PostProject(DataSeeder.NewProject(3));
                await projectsController.PostProject(DataSeeder.NewProject(6, 3));
                await projectsController.PostProject(DataSeeder.NewProject(9, 6));

                var tasksController = new TasksController(context, TestHelper.Mapper);
                await tasksController.PostProjectTask(DataSeeder.NewTask(9, 9));
                await tasksController.PostProjectTask(DataSeeder.NewTask(3, 3));

                //act
                var task = DataSeeder.NewTask(9, 9);
                task.State = ItemState.Completed;
                await tasksController.PutProjectTask(task.ProjectTaskId, task);
            }

            //check
            using (var context = new ProjectManagementContext(options))
            {
                var projectsController = new ProjectsController(context, TestHelper.Mapper);

                var project = await projectsController.GetProject(9);
                project.Value.State.Should().Be(ItemState.Completed);

                project = await projectsController.GetProject(6);
                project.Value.State.Should().Be(ItemState.Completed);

                project = await projectsController.GetProject(3);
                project.Value.State.Should().Be(ItemState.Planned);
            }
        }

        [Fact]
        public async void DeletingTask_SetsSubtasksParentProjectTaskIdToNull()
        {
            var options = TestHelper.ContextOptions; //ensure that we have same db in the scope of test

            using (var context = new ProjectManagementContext(options))
            {
                //setup
                var projectsController = new ProjectsController(context, TestHelper.Mapper);
                await projectsController.PostProject(DataSeeder.NewProject(3));

                var tasksController = new TasksController(context, TestHelper.Mapper);
                await tasksController.PostProjectTask(DataSeeder.NewTask(3, 3));
                await tasksController.PostProjectTask(DataSeeder.NewTask(33, 3, 3));
                await tasksController.PostProjectTask(DataSeeder.NewTask(333, 3, 3));

                //act
                var task = DataSeeder.NewTask(3, 3);
                await tasksController.DeleteProjectTask(task.ProjectTaskId);
            }

            //check
            using (var context = new ProjectManagementContext(options))
            {
                var tasksController = new TasksController(context, TestHelper.Mapper);

                var task = await tasksController.GetProjectTask(33);
                task.Value.ParentProjectTaskId.Should().BeNull();

                task = await tasksController.GetProjectTask(333);
                task.Value.ParentProjectTaskId.Should().BeNull();
            }
        }
    }
}
