using AutoMapper;
using ProjectManagement.Data.Entities;

namespace ProjectManagement.Api.Tools
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Project, ProjectDto>();
            CreateMap<ProjectDto, Project>();

            CreateMap<ProjectTask, ProjectTaskDto>();
            CreateMap<ProjectTaskDto, ProjectTask>();
        }
    }
}
