using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProjectManagement.Data.Entities
{
    public class ProjectTaskDto
    {
        public int ProjectTaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ItemState State { get; set; }
        public int ProjectId { get; set; }
        public int? ParentProjectTaskId { get; set; }
    }

    public class ProjectTask : ProjectTaskDto
    {
        public virtual Project Project { get; set; }
        public virtual ProjectTask ParentProjectTask { get; set; }
        public virtual List<ProjectTask> Tasks { get; set; }
    }
}
