using System;
using System.Text.Json.Serialization;
using ProjectManagement.Api.Data.Entities;

namespace ProjectManagement.Api.Data.DTOs
{
    public class ProjectDto : BaseIdEntity
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ItemState State { get; set; }
        public long? ParentProjectId { get; set; }
    }
}