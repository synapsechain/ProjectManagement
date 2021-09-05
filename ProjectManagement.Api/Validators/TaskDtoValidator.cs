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

            RuleFor(x => x.ProjectId).Must(ProjectExist).WithMessage("Specified project id must exist in db");

            RuleFor(x => x.ParentTaskId)
                .Must(BeValidParentTask)
                .When(x => x.ParentTaskId.HasValue)
                .WithMessage("Task cannot have parent task from different project");
        }

        private bool BeValidParentTask(ProjectTaskDto task, int? parentTaskId)
        {
            var parentTask = _context.ProjectTasks.Find(parentTaskId);
            
            if(parentTask?.ProjectId == task.ProjectId)
                return true;

            return false;
        }

        private bool ProjectExist(int projectId) => _context.Projects.Find(projectId) != null;
    }
}
