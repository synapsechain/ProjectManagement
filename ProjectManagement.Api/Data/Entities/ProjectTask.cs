using System.Text.Json.Serialization;
using ProjectManagement.Api.Data.DTOs;

namespace ProjectManagement.Api.Data.Entities
{
    public class ProjectTask : ProjectTaskDto
    {
        [JsonIgnore]
        public Project? Project { get; set; }

        [JsonIgnore]
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
}
