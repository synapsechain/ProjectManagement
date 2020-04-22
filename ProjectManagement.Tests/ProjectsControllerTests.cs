using Xunit;
using FluentAssertions;
using ProjectManagement.Data.Tools;
using ProjectManagement.Tests.Utils;
using ProjectManagement.Api.Controllers;
using ProjectManagement.Data.Contexts;

namespace ProjectManagement.Tests
{
    public class ProjectsControllerTests
    {
        [Fact]
        public async void PostingProject_ShouldAddProjectToDb()
        {
            var options = UnitTestHelper.InMemoryContextOptions;

            using (var context = new ProjectManagementContext(options))
            {
                context.Projects.Should().BeEmpty();

                var projectsController = new ProjectsController(context, UnitTestHelper.Mapper);
                var result = await projectsController.PostProject(DataSeeder.NewProject(3));
            }

            using (var context = new ProjectManagementContext(options))
            {
                context.Projects.Should().HaveCount(1);
            }
        }


        [Fact]
        public async void DeletingProject_ShouldDeleteProjectFromDb()
        {
            var options = UnitTestHelper.InMemoryContextOptions;

            using (var context = new ProjectManagementContext(options))
            {
                context.Projects.Add(DataSeeder.NewProject(3));
                context.SaveChanges();
                context.Projects.Should().HaveCount(1);

                var projectsController = new ProjectsController(context, UnitTestHelper.Mapper);
                var result = await projectsController.DeleteProject(3);
            }

            using (var context = new ProjectManagementContext(options))
            {
                context.Projects.Should().BeEmpty();
            }
        }

        [Fact]
        public async void UpdatingProject_ShouldUpdateProjectInDb()
        {
            var options = UnitTestHelper.InMemoryContextOptions;

            using (var context = new ProjectManagementContext(options))
            {
                context.Projects.Add(DataSeeder.NewProject(3));
                context.SaveChanges();
                context.Projects.Should().HaveCount(1);

                var projectsController = new ProjectsController(context, UnitTestHelper.Mapper);
                var project = DataSeeder.NewProject(3);
                project.Name = "updated project name";
                project.Code = "updated project code";
                var result = await projectsController.PutProject(3, project);
            }

            using (var context = new ProjectManagementContext(options))
            {
                context.Projects.Should().HaveCount(1);
                context.Projects.Should().Contain(x =>
                    x.Name == "updated project name" &&
                    x.Code == "updated project code");
            }
        }
    }
}
