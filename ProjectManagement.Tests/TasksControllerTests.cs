using Xunit;
using FluentAssertions;
using ProjectManagement.Data.Tools;
using ProjectManagement.Tests.Utils;
using ProjectManagement.Data.Contexts;
using ProjectManagement.Data.Entities;
using ProjectManagement.Api.Controllers;

namespace ProjectManagement.Tests
{
    public class TasksControllerTests
    {
        [Fact]
        public async void PostingTask_ShouldAddTaskToDb()
        {
            var options = UnitTestHelper.InMemoryContextOptions;

            using (var context = new ProjectManagementContext(options))
            {
                context.ProjectTasks.Should().BeEmpty();

                var tasksController = new TasksController(context, UnitTestHelper.Mapper);
                var result = await tasksController.PostProjectTask(DataSeeder.NewTask(3, 3));
            }

            using (var context = new ProjectManagementContext(options))
            {
                context.ProjectTasks.Should().HaveCount(1);
            }
        }

        [Fact]
        public async void DeletingTask_ShouldDeleteTaskFromDb()
        {
            var options = UnitTestHelper.InMemoryContextOptions;
            using (var context = new ProjectManagementContext(options))
            {
                context.ProjectTasks.Should().BeEmpty();

                var tasksController = new TasksController(context, UnitTestHelper.Mapper);

                await tasksController.PostProjectTask(DataSeeder.NewTask(3, 3));
                context.ProjectTasks.Should().HaveCount(1);

                await tasksController.DeleteProjectTask(3);
            }

            using (var context = new ProjectManagementContext(options))
            {
                context.ProjectTasks.Should().BeEmpty();
            }
        }

        [Fact]
        public async void UpdatingTask_ShouldUpdateTaskInDb()
        {
            var options = UnitTestHelper.InMemoryContextOptions;
            using (var context = new ProjectManagementContext(options))
            {
                context.ProjectTasks.Should().BeEmpty();

                context.Projects.Add(DataSeeder.NewProject(3));
                context.ProjectTasks.Add(DataSeeder.NewTask(3, 3));

                var tasksController = new TasksController(context, UnitTestHelper.Mapper);

                var task = DataSeeder.NewTask(3, 3);
                task.State = ItemState.Completed;
                task.Name = "updated name";
                task.Description = "updated description";

                await tasksController.PutProjectTask(3, task);
            }

            using (var context = new ProjectManagementContext(options))
            {
                context.ProjectTasks.Should().Contain(x =>
                    x.ProjectTaskId == 3 &&
                    x.State == ItemState.Completed &&
                    x.Name == "updated name" &&
                    x.Description == "updated description");
            }
        }

        [Fact]
        public async void SettingTaskStateToInProgress_AlsoSetsAllParentProjectsStatesToInProgress()
        {
            var options = UnitTestHelper.InMemoryContextOptions; //ensure that we have same db in the scope of test

            using (var context = new ProjectManagementContext(options))
            {
                //setup
                var projectsController = new ProjectsController(context, UnitTestHelper.Mapper);
                await projectsController.PostProject(DataSeeder.NewProject(3));
                await projectsController.PostProject(DataSeeder.NewProject(6, 3));
                await projectsController.PostProject(DataSeeder.NewProject(9, 6));

                var tasksController = new TasksController(context, UnitTestHelper.Mapper);
                await tasksController.PostProjectTask(DataSeeder.NewTask(12, 9));

                //act
                var task = DataSeeder.NewTask(12, 9);
                task.State = ItemState.InProgress;
                await tasksController.PutProjectTask(task.ProjectTaskId, task);
            }

            //check
            using (var context = new ProjectManagementContext(options))
            {
                var projectsController = new ProjectsController(context, UnitTestHelper.Mapper);

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
            var options = UnitTestHelper.InMemoryContextOptions; //ensure that we have same db in the scope of test

            using (var context = new ProjectManagementContext(options))
            {
                //setup
                var projectsController = new ProjectsController(context, UnitTestHelper.Mapper);
                await projectsController.PostProject(DataSeeder.NewProject(3));
                await projectsController.PostProject(DataSeeder.NewProject(6, 3));
                await projectsController.PostProject(DataSeeder.NewProject(9, 6));

                var tasksController = new TasksController(context, UnitTestHelper.Mapper);
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
                var projectsController = new ProjectsController(context, UnitTestHelper.Mapper);

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
            var options = UnitTestHelper.InMemoryContextOptions; //ensure that we have same db in the scope of test

            using (var context = new ProjectManagementContext(options))
            {
                //setup
                var projectsController = new ProjectsController(context, UnitTestHelper.Mapper);
                await projectsController.PostProject(DataSeeder.NewProject(3));

                var tasksController = new TasksController(context, UnitTestHelper.Mapper);
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
                var tasksController = new TasksController(context, UnitTestHelper.Mapper);

                var task = await tasksController.GetProjectTask(33);
                task.Value.ParentProjectTaskId.Should().BeNull();

                task = await tasksController.GetProjectTask(333);
                task.Value.ParentProjectTaskId.Should().BeNull();
            }
        }
    }
}
