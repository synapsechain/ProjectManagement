using Xunit;
using FluentAssertions;
using ProjectManagement.Tests.Utils;
using ProjectManagement.Api.Data;
using ProjectManagement.Api.Data.Entities;
using ProjectManagement.Api.Services;

namespace ProjectManagement.Tests
{
    public class TaskServiceTests
    {
        [Fact]
        public async void PostingTask_ShouldAddTaskToDb()
        {
            var db = UnitTestHelper.CreateInMemoryDb();

            await using (var context = db.CreateContext())
            {
                context.ProjectTasks.Should().BeEmpty();

                var taskService = new TaskService(context, UnitTestHelper.Mapper);
                await taskService.Add(DataSeeder.NewTask(3, 3));
            }

            await using (var context = db.CreateContext())
            {
                context.ProjectTasks.Should().HaveCount(1);
            }
        }

        [Fact]
        public async void DeletingTask_ShouldDeleteTaskFromDb()
        {
            var db = UnitTestHelper.CreateInMemoryDb();
            await using (var context = db.CreateContext())
            {
                context.ProjectTasks.Should().BeEmpty();

                var taskService = new TaskService(context, UnitTestHelper.Mapper);

                await taskService.Add(DataSeeder.NewTask(3, 3));
                context.ProjectTasks.Should().HaveCount(1);

                await taskService.DeleteOrThrow(3);
            }

            await using (var context = db.CreateContext())
            {
                context.ProjectTasks.Should().BeEmpty();
            }
        }

        [Fact]
        public async void UpdatingTask_ShouldUpdateTaskInDb()
        {
            var db = UnitTestHelper.CreateInMemoryDb();
            await using (var context = db.CreateContext())
            {
                context.ProjectTasks.Should().BeEmpty();

                context.Projects.Add(DataSeeder.NewProject(3));
                context.ProjectTasks.Add(DataSeeder.NewTask(3, 3));

                var taskService = new TaskService(context, UnitTestHelper.Mapper);

                var task = DataSeeder.NewTask(3, 3);
                task.State = ItemState.Completed;
                task.Name = "updated name";
                task.Description = "updated description";

                await taskService.UpdateOrThrow(task);
            }

            await using (var context = db.CreateContext())
            {
                context.ProjectTasks.Should().Contain(x =>
                    x.Id == 3 &&
                    x.State == ItemState.Completed &&
                    x.Name == "updated name" &&
                    x.Description == "updated description");
            }
        }

        [Fact]
        public async void SettingTaskStateToInProgress_AlsoSetsAllParentProjectsStatesToInProgress()
        {
            //arrange
            var db = UnitTestHelper.CreateInMemoryDb(); //ensure that we have same db in the scope of test

            await using (var context = db.CreateContext())
            {
                var projectService = new ProjectService(context, UnitTestHelper.Mapper);
                await projectService.Add(DataSeeder.NewProject(3));
                await projectService.Add(DataSeeder.NewProject(6, 3));
                await projectService.Add(DataSeeder.NewProject(9, 6));

                var taskService = new TaskService(context, UnitTestHelper.Mapper);
                await taskService.Add(DataSeeder.NewTask(12, 9));

                //act
                var task = DataSeeder.NewTask(12, 9);
                task.State = ItemState.InProgress;
                await taskService.UpdateOrThrow(task);
            }

            //assert
            await using (var context = db.CreateContext())
            {
                var projectService = new ProjectService(context, UnitTestHelper.Mapper);

                var project = await projectService.GetOrThrow(9).ConfigureAwait(false);
                project.State.Should().Be(ItemState.InProgress);

                project = await projectService.GetOrThrow(6).ConfigureAwait(false);
                project.State.Should().Be(ItemState.InProgress);

                project = await projectService.GetOrThrow(3).ConfigureAwait(false);
                project.State.Should().Be(ItemState.InProgress);
            }
        }

        [Fact]
        public async void SettingTaskStateToComplete_AlsoSetsAllParentProjectsStatesToComplete_WhenAllProjectTasksComplete()
        {
            var db = UnitTestHelper.CreateInMemoryDb(); //ensure that we have same db in the scope of the test

            await using (var context = db.CreateContext())
            {
                //arrange
                var projectService = new ProjectService(context, UnitTestHelper.Mapper);
                await projectService.Add(DataSeeder.NewProject(3));
                await projectService.Add(DataSeeder.NewProject(6, 3));
                await projectService.Add(DataSeeder.NewProject(9, 6));

                var taskService = new TaskService(context, UnitTestHelper.Mapper);
                await taskService.Add(DataSeeder.NewTask(9, 9));
                await taskService.Add(DataSeeder.NewTask(3, 3));

                //act
                var task = DataSeeder.NewTask(9, 9);
                task.State = ItemState.Completed;
                await taskService.UpdateOrThrow(task);
            }

            //assert
            await using (var context = db.CreateContext())
            {
                var projectService = new ProjectService(context, UnitTestHelper.Mapper);

                var project = await projectService.GetOrThrow(9);
                project.State.Should().Be(ItemState.Completed);

                project = await projectService.GetOrThrow(6);
                project.State.Should().Be(ItemState.Completed);

                project = await projectService.GetOrThrow(3);
                project.State.Should().Be(ItemState.Planned);
            }
        }

        [Fact]
        public async void DeletingTask_SetsSubtasksParentProjectTaskIdToNull()
        {
            var db = UnitTestHelper.CreateInMemoryDb(); //ensure that we have same db in the scope of the test

            await using (var context = db.CreateContext())
            {
                //arrange
                var projectService = new ProjectService(context, UnitTestHelper.Mapper);
                await projectService.Add(DataSeeder.NewProject(3));

                var taskService = new TaskService(context, UnitTestHelper.Mapper);
                await taskService.Add(DataSeeder.NewTask(3, 3));
                await taskService.Add(DataSeeder.NewTask(33, 3, 3));
                await taskService.Add(DataSeeder.NewTask(333, 3, 3));

                //act
                var task = DataSeeder.NewTask(3, 3);
                await taskService.DeleteOrThrow(task.Id);
            }

            //assert
            await using (var context = db.CreateContext())
            {
                var tasksService = new TaskService(context, UnitTestHelper.Mapper);

                var task = await tasksService.Get(33);
                task.ParentTaskId.Should().BeNull();

                task = await tasksService.Get(333);
                task.ParentTaskId.Should().BeNull();
            }
        }
    }
}
