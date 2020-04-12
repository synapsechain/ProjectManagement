using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data.Contexts;
using ProjectManagement.Data.Entities;
using AutoMapper;

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

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectTaskDto>>> GetProjectTasks()
        {
            return await _context.ProjectTasks.Select(x => _mapper.Map<ProjectTaskDto>(x)).ToListAsync();
        }

        // GET: api/Tasks/5
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

        // PUT: api/Tasks/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectTask(int id, ProjectTask projectTask)
        {
            if (id != projectTask.ProjectTaskId)
            {
                return BadRequest();
            }

            _context.Entry(projectTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectTaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tasks
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ProjectTaskDto>> PostProjectTask(ProjectTask projectTask)
        {
            _context.ProjectTasks.Add(projectTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectTask", new { id = projectTask.ProjectTaskId }, _mapper.Map<ProjectTaskDto>(projectTask));
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectTaskDto>> DeleteProjectTask(int id)
        {
            var projectTask = await _context.ProjectTasks.FindAsync(id);
            if (projectTask == null)
            {
                return NotFound();
            }

            _context.ProjectTasks.Remove(projectTask);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProjectTaskDto>(projectTask);
        }

        private bool ProjectTaskExists(int id)
        {
            return _context.ProjectTasks.Any(e => e.ProjectTaskId == id);
        }
    }
}
