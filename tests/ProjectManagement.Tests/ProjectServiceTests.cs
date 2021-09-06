using Xunit;
using FluentAssertions;
using ProjectManagement.Tests.Utils;
using ProjectManagement.Api.Data;
using ProjectManagement.Api.Services;

namespace ProjectManagement.Tests
{
    public class ProjectServiceTests
    {
        [Fact]
        public async void PostingProject_ShouldAddProjectToDb()
        {
            var db = UnitTestHelper.CreateInMemoryDb();

            await using (var context = db.CreateContext())
            {
                context.Projects.Should().BeEmpty();

                var projectService = new ProjectService(context, UnitTestHelper.Mapper);
                await projectService.Add(DataSeeder.NewProject(3));
            }

            await using (var context = db.CreateContext())
            {
                context.Projects.Should().HaveCount(1);
            }
        }


        [Fact]
        public async void DeletingProject_ShouldDeleteProjectFromDb()
        {
            var db = UnitTestHelper.CreateInMemoryDb();

            await using (var context = db.CreateContext())
            {
                context.Projects.Add(DataSeeder.NewProject(3));
                await context.SaveChangesAsync();
                context.Projects.Should().HaveCount(1);

                var projectService = new ProjectService(context, UnitTestHelper.Mapper);
                await projectService.DeleteOrThrow(3);
            }

            await using (var context = db.CreateContext())
            {
                context.Projects.Should().BeEmpty();
            }
        }

        [Fact]
        public async void UpdatingProject_ShouldUpdateProjectInDb()
        {
            var db = UnitTestHelper.CreateInMemoryDb();

            await using (var context = db.CreateContext())
            {
                context.Projects.Add(DataSeeder.NewProject(3));
                await context.SaveChangesAsync();
                context.Projects.Should().HaveCount(1);

                var projectService = new ProjectService(context, UnitTestHelper.Mapper);
                var project = DataSeeder.NewProject(3);
                project.Name = "updated project name";
                project.Code = "updated project code";
                await projectService.UpdateOrThrow(project);
            }

            await using (var context = db.CreateContext())
            {
                context.Projects.Should().HaveCount(1);
                context.Projects.Should().Contain(x =>
                    x.Name == "updated project name" &&
                    x.Code == "updated project code");
            }
        }
    }
}
