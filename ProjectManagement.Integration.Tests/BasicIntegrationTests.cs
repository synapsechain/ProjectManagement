using System.Net.Mime;
using Xunit;
using FluentAssertions;
using ProjectManagement.Api;
using System.Threading.Tasks;
using ProjectManagement.Integration.Tests.Utils;

namespace ProjectManagement.Integration.Tests
{
    public class BasicIntegrationTests : IClassFixture<ProjectManagementWebApplicationFactory<Startup>>
    {
        private readonly ProjectManagementWebApplicationFactory<Startup> _factory;

        public BasicIntegrationTests(ProjectManagementWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData(Endpoints.TASKS)]
        [InlineData(Endpoints.PROJECTS)]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            using var client = _factory.CreateClient();
            var response = await client.GetAsync(url).ConfigureAwait(false);

            response.EnsureSuccessStatusCode(); // Status Code 200-299
            response.Content.Headers.ContentType.Should().NotBeNull();
            response.Content.Headers.ContentType!.ToString().Should().Contain(MediaTypeNames.Application.Json);
        }
    }
}
