using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.Data.Entities;

namespace ProjectManagement.Data.Contexts
{
    public class ProjectManagementContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }

        public ProjectManagementContext(DbContextOptions<ProjectManagementContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(ConfigureProject);
            modelBuilder.Entity<ProjectTask>(ConfigureProjectTask);
        }

        public static void ConfigureProject(EntityTypeBuilder<Project> builder)
        {
            builder.Property(x => x.Code).IsRequired();
            builder.Property(x => x.Name).IsRequired();
        }

        public static void ConfigureProjectTask(EntityTypeBuilder<ProjectTask> builder)
        {
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
