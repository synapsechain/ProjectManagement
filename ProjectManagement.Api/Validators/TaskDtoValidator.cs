using FluentValidation;
using ProjectManagement.Api.Data;
using ProjectManagement.Api.Data.DTOs;

namespace ProjectManagement.Api.Validators
{
    public class TaskDtoValidator : AbstractValidator<ProjectTaskDto>
    {
        private readonly AppDbContext _context;

        public TaskDtoValidator(AppDbContext context)
        {
            _context = context;

            RuleFor(x => x.Name).NotEmpty();

            RuleFor(x => x.ProjectId).Must(ProjectExist).WithMessage(x => $"Project with id '{x.ProjectId}' should exist in db");

            RuleFor(x => x.ParentTaskId)
                .Must(BeValidParentTask)
                .When(x => x.ParentTaskId.HasValue)
                .WithMessage(x => $"Task cannot have parent task from different project. Parent task id '{x.ParentTaskId}'");
        }

        private bool BeValidParentTask(ProjectTaskDto task, long? parentTaskId)
        {
            var parentTask = _context.Tasks.Find(parentTaskId);
            
            return parentTask?.ProjectId == task.ProjectId;
        }

        private bool ProjectExist(long projectId) => _context.Projects.Find(projectId) != null;
    }
}
