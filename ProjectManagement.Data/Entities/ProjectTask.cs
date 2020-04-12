using System;
using System.Collections.Generic;

namespace ProjectManagement.Data.Entities
{
    public class ProjectTask
    {
        public int ProjectTaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public ItemState State { get; set; }
        public int ProjectId { get; set; }
        public int? ParentProjectTaskId { get; set; }

        public virtual Project Project { get; set; }
        public virtual ProjectTask ParentProjectTask { get; set; }
        public virtual List<ProjectTask> Tasks { get; set; }
    }
}
