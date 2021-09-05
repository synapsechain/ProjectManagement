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
    public class ProjectsTests : BaseClassFixture
    {
        public ProjectsTests(ProjectManagementWebApplicationFactory<Startup> factory) : base(factory) { }

        [Fact]
        public async Task Post_ProjectWithNotExistedParentProject_ShouldResultInBadRequest()
        {
            using (var client = _factory.CreateClient())
            {
                var response = await client.PostAsJsonAsync(Endpoints.PROJECTS, DataSeeder.NewProject(3, 33));

                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        [Fact]
        public async void Put_ProjectWithNotExistedParentProject_ShouldResultInBadRequest()
        {
            using (var client = _factory.CreateClient())
            {
                await client.PostAsJsonAsync(Endpoints.PROJECTS, DataSeeder.NewProject(3));
                var response = await client.PutAsJsonAsync($"{Endpoints.PROJECTS}/3", DataSeeder.NewProject(3, 33));

                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }
    }
}
