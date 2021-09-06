using Xunit;
using System.Net;
using System.Net.Http;
using FluentAssertions;
using ProjectManagement.Api;
using System.Threading.Tasks;
using ProjectManagement.Api.Data;
using ProjectManagement.Integration.Tests.Utils;

namespace ProjectManagement.Integration.Tests.EndpointsTests
{
    public class TasksTests : BaseClassFixture
    {
        public TasksTests(ProjectManagementWebApplicationFactory<Startup> factory) : base(factory) { }

        [Fact]
        public async Task Post_TaskWithNoProject_ShouldResultInBadRequest()
        {
            using var client = _factory.CreateClient();
            var response = await client.PostAsJsonAsync(Endpoints.TASKS, DataSeeder.NewTask(3, 6)).ConfigureAwait(false);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Post_TaskWithParentProjectTaskId_ThatPointToAnotherProject_ShouldResultInBadRequest()
        {
            using var client = _factory.CreateClient();
            await client.PostAsJsonAsync(Endpoints.PROJECTS, DataSeeder.NewProject(3)).ConfigureAwait(false);
            await client.PostAsJsonAsync(Endpoints.PROJECTS, DataSeeder.NewProject(9)).ConfigureAwait(false);

            await client.PostAsJsonAsync(Endpoints.TASKS, DataSeeder.NewTask(3, 3)).ConfigureAwait(false);
            await client.PostAsJsonAsync(Endpoints.TASKS, DataSeeder.NewTask(9, 9)).ConfigureAwait(false);

            var response = await client.PostAsJsonAsync(Endpoints.TASKS, DataSeeder.NewTask(6, 3, 9)).ConfigureAwait(false);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Put_TaskWithParentProjectTaskId_ThatPointToAnotherProject_ShouldResultInBadRequest()
        {
            using var client = _factory.CreateClient();
            await client.PostAsJsonAsync(Endpoints.PROJECTS, DataSeeder.NewProject(3)).ConfigureAwait(false);
            await client.PostAsJsonAsync(Endpoints.PROJECTS, DataSeeder.NewProject(9)).ConfigureAwait(false);

            await client.PostAsJsonAsync(Endpoints.TASKS, DataSeeder.NewTask(3, 3)).ConfigureAwait(false);
            await client.PostAsJsonAsync(Endpoints.TASKS, DataSeeder.NewTask(9, 9)).ConfigureAwait(false);
            await client.PostAsJsonAsync(Endpoints.TASKS, DataSeeder.NewTask(6, 3, 3)).ConfigureAwait(false);

            var response = await client.PutAsJsonAsync($"{Endpoints.TASKS}/6", DataSeeder.NewTask(6, 3, 9)).ConfigureAwait(false);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
