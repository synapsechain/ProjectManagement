using Microsoft.EntityFrameworkCore;
using ProjectManagement.Api.Data;

namespace ProjectManagement.Tests.Utils
{
    public static class Extensions
    {
        public static AppDbContext CreateContext(this DbContextOptions<AppDbContext> options)
            => new(options);
    }
}
