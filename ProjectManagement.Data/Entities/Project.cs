using System;
using System.Collections.Generic;

namespace ProjectManagement.Data.Entities
{
    public enum ItemState
    {
        Planned,
        InProgress,
        Completed
    }

    public class Project
    {
        public int ProjectId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public ItemState State { get; set; }
        public int? ParentProjectId { get; set; }

        public virtual Project ParentProject { get; set; }
        public virtual List<Project> Projects { get; set; }
        public virtual List<ProjectTask> Tasks { get; set; }
    }
}
