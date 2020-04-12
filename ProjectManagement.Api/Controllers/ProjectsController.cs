using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data.Contexts;
using ProjectManagement.Data.Entities;
using System;

namespace ProjectManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectManagementContext _context;
        private readonly IMapper _mapper;

        public ProjectsController(ProjectManagementContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetProjects()
        {
            return await _context.Projects.Select(x => _mapper.Map<ProjectDto>(x)).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDto>> GetProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return _mapper.Map<ProjectDto>(project);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, ProjectDto projectDto)
        {
            if (id != projectDto.ProjectId)
            {
                return BadRequest();
            }

            var project = _context.Projects.Find(id);
            if (project == null)
                return NotFound();

            ValidateProject(projectDto);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await UpdateProject(project, projectDto);

            return NoContent();
        }

        private async Task UpdateProject(Project project, ProjectDto projectDto)
        {
            _mapper.Map(projectDto, project);
            await _context.SaveChangesAsync();
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDto>> PostProject(ProjectDto projectDto)
        {
            ValidateProject(projectDto);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var projectEntity = _context.Projects.Add(_mapper.Map<Project>(projectDto));
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProject), new { id = projectEntity.Entity.ProjectId }, _mapper.Map<ProjectDto>(projectEntity.Entity));
        }

        private void ValidateProject(ProjectDto projectDto)
        {
            if (projectDto.ParentProjectId.HasValue &&
                _context.Projects.Find(projectDto.ParentProjectId) == null)
                ModelState.AddModelError(nameof(projectDto.ParentProjectId), "Parent project does not exist");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectDto>> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProjectDto>(project);
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.ProjectId == id);
        }
    }
}
