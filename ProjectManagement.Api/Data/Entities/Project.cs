using System.Collections.Generic;
using System.Linq;
using ProjectManagement.Api.Data.DTOs;

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
        public Project? ParentProject { get; set; }
        public List<Project> Projects { get; set; } = new();
        public List<ProjectTask> Tasks { get; set; } = new();

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
}
