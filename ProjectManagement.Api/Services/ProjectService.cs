using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Api.Data;
using ProjectManagement.Api.Data.DTOs;
using ProjectManagement.Api.Data.Entities;
using ProjectManagement.Api.Exceptions;

namespace ProjectManagement.Api.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDto>> Get();
        Task<ProjectDto> GetOrThrow(int id);
        Task<Project> Add(ProjectDto projectDto);
        Task UpdateOrThrow(ProjectDto projectDto);
        Task DeleteOrThrow(int id);
    }

    public class ProjectService : IProjectService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        
        public ProjectService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<ProjectDto>> Get()
            => await _context.Projects
                .Select(x => _mapper.Map<ProjectDto>(x))
                .ToListAsync()
                .ConfigureAwait(false);
        
        public async Task<ProjectDto> GetOrThrow(int id)
        {
            var project = await _context.Projects.FindAsync(id)
                          ?? throw new NotFoundException(nameof(Project), id);

            return _mapper.Map<ProjectDto>(project);
        }
        
        public async Task<Project> Add(ProjectDto projectDto)
        {
            var projectEntity = _context.Projects.Add(_mapper.Map<Project>(projectDto));
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return projectEntity.Entity;
        }

        public async Task UpdateOrThrow(ProjectDto projectDto)
        {
            var project = await _context.Projects.FindAsync(projectDto.Id).ConfigureAwait(false)
                          ?? throw new NotFoundException(nameof(Project), projectDto.Id);
            
            _mapper.Map(projectDto, project);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrThrow(int id)
        {
            var project = await _context.Projects.FindAsync(id)
                ?? throw new NotFoundException(nameof(Project), id);

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }
    }
}
