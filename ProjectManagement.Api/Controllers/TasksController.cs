using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Api.Data.DTOs;
using ProjectManagement.Api.Services;

namespace ProjectManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProjectTaskDto>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<ProjectTaskDto>> Get()
            => await _taskService.Get();

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProjectTaskDto), StatusCodes.Status200OK)]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ProjectTaskDto> Get(int id)
            => await _taskService.Get(id).ConfigureAwait(false);

        [HttpPut("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<IActionResult> PutProjectTask(int id, ProjectTaskDto taskDto)
        {
            if (id != taskDto.Id)
                return BadRequest($"Task id '{id}' != '{taskDto.ProjectId}'");

            await _taskService.UpdateOrThrow(taskDto).ConfigureAwait(false);
            
            return NoContent();
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<IActionResult> PostProjectTask(ProjectTaskDto taskDto)
        {
            var task = await _taskService.Add(taskDto);

            return CreatedAtAction(nameof(Get), new { id = task.Id });
        }

        [HttpDelete("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task Delete(int id)
            => await _taskService.DeleteOrThrow(id).ConfigureAwait(false);
    }
}
