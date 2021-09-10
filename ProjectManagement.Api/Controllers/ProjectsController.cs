using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using ProjectManagement.Api.Data.DTOs;
using ProjectManagement.Api.Services;

namespace ProjectManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : ControllerBase
    {
        private IProjectService _projectService; 
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProjectDto>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<ProjectDto>> Get()
            => await _projectService.Get().ConfigureAwait(false);

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProjectDto), StatusCodes.Status200OK)]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ProjectDto> Get(int id)
            => await _projectService.GetOrThrow(id).ConfigureAwait(false);

        [HttpPut("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<IActionResult> Put(int id, ProjectDto projectDto)
        {
            await _projectService.UpdateOrThrow(projectDto).ConfigureAwait(false);

            return NoContent();
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<IActionResult> Post(ProjectDto projectDto)
        {
            var project = await _projectService.Add(projectDto).ConfigureAwait(false);
            
            return CreatedAtAction(nameof(Get), new { id = project.Id });
        }

        [HttpDelete("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task Delete(int id)
            => await _projectService.DeleteOrThrow(id).ConfigureAwait(false);
    }
}
