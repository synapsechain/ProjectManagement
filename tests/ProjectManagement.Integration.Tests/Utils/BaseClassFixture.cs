using Xunit;
using ProjectManagement.Api;

namespace ProjectManagement.Integration.Tests.Utils
{
    public class BaseClassFixture : IClassFixture<ProjectManagementWebApplicationFactory<Startup>>
    {
        protected readonly ProjectManagementWebApplicationFactory<Startup> _factory;

        public BaseClassFixture(ProjectManagementWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
    }
}
