using System.Linq;
using Microsoft.AspNetCore.Hosting;
using ProjectManagement.Tests.Utils;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data.Contexts;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectManagement.Integration.Tests.Utils
{
    public class ProjectManagementWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    { 
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Remove the app's ApplicationDbContext registration.
                var descriptor = services.SingleOrDefault(x => x.ServiceType == typeof(DbContextOptions<ProjectManagementContext>));
                if (descriptor != null) services.Remove(descriptor);

                // Add ApplicationDbContext using an in-memory database for testing.
                services.AddDbContext<ProjectManagementContext>(UnitTestHelper.InMemoryContextOptionsBuilder);
            });
        }
    }

}
