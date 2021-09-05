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
    public interface ITaskService
    {
        Task<IEnumerable<ProjectTaskDto>> Get();
        Task<ProjectTaskDto> Get(int id);
        Task<ProjectTask> Add(ProjectTaskDto taskDto);
        Task UpdateOrThrow(ProjectTaskDto taskDto);
        Task DeleteOrThrow(int id);
    }

    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        
        public TaskService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProjectTaskDto>> Get()
            => await _context.ProjectTasks
                .Select(x => _mapper.Map<ProjectTaskDto>(x))
                .ToListAsync()
                .ConfigureAwait(false);

        public async Task<ProjectTaskDto> Get(int id)
        {
            var projectTask = await _context.ProjectTasks.FindAsync(id).ConfigureAwait(false)
                ?? throw new NotFoundException(nameof(ProjectTask), id);

            return _mapper.Map<ProjectTaskDto>(projectTask);
        }

        public async Task<ProjectTask> Add(ProjectTaskDto taskDto)
        {
            var task = _context.ProjectTasks.Add(_mapper.Map<ProjectTask>(taskDto));
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return task.Entity;
        }
        
        public async Task UpdateOrThrow(ProjectTaskDto taskDto)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync().ConfigureAwait(false);
            
            var task = await _context.ProjectTasks.FindAsync(taskDto.Id).ConfigureAwait(false)
                ?? throw new NotFoundException(nameof(ProjectTask), taskDto.Id);

            if (task.State != taskDto.State)
            {
                task.State = taskDto.State;
                UpdateParentProjectsStates(task);
            }

            _mapper.Map(taskDto, task);

            await _context.SaveChangesAsync().ConfigureAwait(false);
            await transaction.CommitAsync().ConfigureAwait(false);
        }

        private void UpdateParentProjectsStates(ProjectTask task)
        {
            var project = task.Project;
            while (project != null)
            {
                project.State = project.CalculatedState;
                project = project.ParentProject;
            }
        }
        
        public async Task DeleteOrThrow(int id)
        {
            var projectTask = await _context.ProjectTasks.FindAsync(id).ConfigureAwait(false)
                              ?? throw new NotFoundException(nameof(ProjectTask), id);

            await using var transaction = await _context.Database.BeginTransactionAsync().ConfigureAwait(false);
            //TODO: clarify behaviour (currently it updates all nested tasks and sets their ParentProjectTaskId to null)
            var nestedTasks = await _context.ProjectTasks
                .Where(x => x.ParentTaskId == projectTask.Id)
                .ToListAsync().ConfigureAwait(false);
            nestedTasks.ForEach(x => x.ParentTaskId = null);

            _context.ProjectTasks.Remove(projectTask);

            await _context.SaveChangesAsync().ConfigureAwait(false);
            await transaction.CommitAsync().ConfigureAwait(false);
        }
    }
}
