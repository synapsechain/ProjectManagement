using Xunit;
using FluentAssertions;
using ProjectManagement.Api;
using System.Threading.Tasks;
using ProjectManagement.Api.Tools;
using ProjectManagement.Integration.Tests.Utils;

namespace ProjectManagement.Integration.Tests.EndpointsTests
{
    public class FileTests : BaseClassFixture
    {
        public FileTests(ProjectManagementWebApplicationFactory<Startup> factory) : base(factory) { }

        [Fact]
        public async Task Get_FileEndpointReturnsSuccessAndCorrectContentType()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(Endpoints.FILE).ConfigureAwait(false);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            response.Content.Headers.ContentType.Should().NotBeNull();
            response.Content.Headers.ContentType!.ToString().Should().Be(Constants.ExcelContentType);
        }
    }
}
