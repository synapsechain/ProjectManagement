using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.Api.Data.DTOs;
using ProjectManagement.Api.Tools;

namespace ProjectManagement.Api.Data.Entities
{
    public enum ItemState
    {
        Planned,
        InProgress,
        Completed
    }

    public class Project : ProjectDto
    {
        public virtual Project? ParentProject { get; set; }
        public virtual List<Project> Projects { get; set; } = new();
        public virtual List<ProjectTask> Tasks { get; set; } = new();

        public IEnumerable<ProjectTask> AllTasks
        {
            get => Tasks.Concat(Projects.SelectMany(x => x.AllTasks));
        }

        public ItemState CalculatedState
        {
            get
            {
                var allTasks = AllTasks.ToList();
                if (allTasks.All(x => x.State == ItemState.Completed)) return ItemState.Completed;
                if (allTasks.Any(x => x.State == ItemState.InProgress)) return ItemState.InProgress;

                return ItemState.Planned;
            }
        }
    }
    
    public class ProjectConfiguration : BaseEntityConfiguration<Project>
    {
        public override void Configure(EntityTypeBuilder<Project> builder)
        {
            base.Configure(builder);
            
            builder.Property(x => x.Code).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.State).HasConversion<string>();
            builder.Ignore(x => x.AllTasks);
            builder.Ignore(x => x.CalculatedState);
            
            builder.ToTable(nameof(AppDbContext.Projects), Constants.DbSchemas.System);
        }
    }
}
