using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.Api.Data.Entities;

namespace ProjectManagement.Api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<ProjectTask> ProjectTasks { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            builder.Entity<Project>(ConfigureProject);
            builder.Entity<ProjectTask>(ConfigureProjectTask);
            
            builder.Seed();
        }

        public static void ConfigureProject(EntityTypeBuilder<Project> builder)
        {
            builder.Property(x => x.Code).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.State).HasConversion<string>();
            builder.Ignore(x => x.AllTasks);
            builder.Ignore(x => x.CalculatedState);
        }

        public static void ConfigureProjectTask(EntityTypeBuilder<ProjectTask> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.State).HasConversion<string>();
            builder.Ignore(x => x.TopLevelProject);
        }
    }
}
