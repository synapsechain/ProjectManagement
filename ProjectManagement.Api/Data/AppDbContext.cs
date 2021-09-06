using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.Api.Data.Entities;

namespace ProjectManagement.Api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<ProjectTask> Tasks { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            builder.Seed();
        }
    }
}
