using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data.Contexts;
using ProjectManagement.Data.Entities;
using AutoMapper;
using System;

namespace ProjectManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ProjectManagementContext _context;
        private readonly IMapper _mapper;

        public TasksController(ProjectManagementContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectTaskDto>>> GetProjectTasks()
        {
            return await _context.ProjectTasks.Select(x => _mapper.Map<ProjectTaskDto>(x)).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectTaskDto>> GetProjectTask(int id)
        {
            var projectTask = await _context.ProjectTasks.FindAsync(id);

            if (projectTask == null)
            {
                return NotFound();
            }

            return _mapper.Map<ProjectTaskDto>(projectTask);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectTask(int id, ProjectTaskDto projectTaskDto)
        {
            if (id != projectTaskDto.ProjectTaskId)
                return BadRequest();

            var task = _context.ProjectTasks.Find(id);
            if (task == null)
                return NotFound();

            ValidateTask(projectTaskDto);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await UpdateTask(task, projectTaskDto);
            return NoContent();
        }

        private void ValidateTask(ProjectTaskDto task)
        {
            if (task.ParentProjectTaskId.HasValue)
            {
                var parentTask = _context.ProjectTasks.Find(task.ParentProjectTaskId.Value);
                if (parentTask?.ProjectId != task.ProjectId)
                    ModelState.AddModelError(nameof(task.ParentProjectTaskId), "Task cannot have parent task from different project");
            }
        }

        private async Task UpdateTask(ProjectTask task, ProjectTaskDto taskDto)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                if (task.State != taskDto.State)
                {
                    task.State = taskDto.State;
                    UpdateParentProjectsStates(task);
                }

                _mapper.Map(taskDto, task);

                await _context.SaveChangesAsync();
                transaction.Commit();
            }
        }

        private void UpdateParentProjectsStates(ProjectTask dbTask)
        {
            var project = dbTask.Project;
            while (project != null)
            {
                project.State = project.CalculatedState;
                project = project.ParentProject;
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProjectTaskDto>> PostProjectTask(ProjectTaskDto projectTaskDto)
        {
            ValidateTask(projectTaskDto);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var task = _context.ProjectTasks.Add(_mapper.Map<ProjectTask>(projectTaskDto));
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProjectTask), new { id = task.Entity.ProjectTaskId }, _mapper.Map<ProjectTaskDto>(task.Entity));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectTaskDto>> DeleteProjectTask(int id)
        {
            var projectTask = await _context.ProjectTasks.FindAsync(id);
            if (projectTask == null)
            {
                return NotFound();
            }

            await DeleteProjectTask(projectTask);

            return _mapper.Map<ProjectTaskDto>(projectTask);
        }
        private async Task DeleteProjectTask(ProjectTask projectTask)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                //TODO: clarify behaviour (currently it updates all nested tasks and sets their ParentProjectTaskId to null)
                var nestedTasks = await _context.ProjectTasks.Where(x => x.ParentProjectTaskId == projectTask.ProjectTaskId).ToListAsync();
                nestedTasks.ForEach(x => x.ParentProjectTaskId = null);

                _context.ProjectTasks.Remove(projectTask);

                await _context.SaveChangesAsync();
                transaction.Commit();
            }
        }

    }
}
