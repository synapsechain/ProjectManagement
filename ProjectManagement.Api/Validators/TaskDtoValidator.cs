using FluentValidation;
using ProjectManagement.Data.Contexts;
using ProjectManagement.Data.Entities;

namespace ProjectManagement.Api.Validation
{
    public class TaskDtoValidator : AbstractValidator<ProjectTaskDto>
    {
        private readonly ProjectManagementContext _context;

        public TaskDtoValidator(ProjectManagementContext context)
        {
            _context = context;

            RuleFor(x => x.Name).NotEmpty();

            RuleFor(x => x.ProjectId).Must(ProjectExist).WithMessage("Specified project id must exist in db");

            RuleFor(x => x.ParentProjectTaskId)
                .Must(BeValidParentTask)
                .When(x => x.ParentProjectTaskId.HasValue)
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
