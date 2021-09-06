using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.Api.Data.DTOs;
using ProjectManagement.Api.Tools;

namespace ProjectManagement.Api.Data.Entities
{
    public class ProjectTask : ProjectTaskDto
    {
        public virtual Project? Project { get; set; }
        
        public Project? TopLevelProject
        {
            get
            {
                var project = Project;

                while (project?.ParentProject != null)
                    project = project.ParentProject;

                return project;
            }
        }
    }
    
    public class ProjectTaskConfiguration : BaseEntityConfiguration<ProjectTask>
    {
        public override void Configure(EntityTypeBuilder<ProjectTask> builder)
        {
            base.Configure(builder);
            
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.State).HasConversion<string>();
            builder.Ignore(x => x.TopLevelProject);
            
            builder.ToTable(nameof(AppDbContext.Tasks), Constants.DbSchemas.System);
        }
    }
}
