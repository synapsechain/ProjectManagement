using System;
using System.Text.Json.Serialization;
using ProjectManagement.Api.Data.Entities;

namespace ProjectManagement.Api.Data.DTOs
{
    public class ProjectTaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ItemState State { get; set; }
        public int ProjectId { get; set; }
        public int? ParentTaskId { get; set; }
    }
}
