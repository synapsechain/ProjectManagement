using AutoMapper;
using ProjectManagement.Api.Data.DTOs;
using ProjectManagement.Api.Data.Entities;

namespace ProjectManagement.Api.Tools
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Project, ProjectDto>()
                .ReverseMap();

            CreateMap<ProjectTask, ProjectTaskDto>()
                .ReverseMap();
        }
    }
}
