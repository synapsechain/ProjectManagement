using System;
using System.Linq;
using System.Collections.Generic;
using ProjectManagement.Data.Tools;
using System.Text.Json.Serialization;

namespace ProjectManagement.Data.Entities
{
    public enum ItemState
    {
        Planned,
        InProgress,
        Completed
    }

    public class ProjectDto
    {
        public int ProjectId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ItemState State { get; set; }
        public int? ParentProjectId { get; set; }
    }

    public class Project : ProjectDto
    {
        public virtual Project ParentProject { get; set; }
        public virtual List<Project> Projects { get; set; }
        public virtual List<ProjectTask> Tasks { get; set; }

        public IEnumerable<ProjectTask> AllTasks
        {
            get => Tasks.NeverNull().Concat(Projects.NeverNull().SelectMany(x => x.AllTasks));
        }
    }
}
