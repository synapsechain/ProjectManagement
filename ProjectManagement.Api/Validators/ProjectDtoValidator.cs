using System.Linq;
using FluentValidation;
using ProjectManagement.Data.Contexts;
using ProjectManagement.Data.Entities;

namespace ProjectManagement.Api.Validators
{
    public class ProjectDtoValidator : AbstractValidator<ProjectDto>
    {
        private readonly ProjectManagementContext _context;

        public ProjectDtoValidator(ProjectManagementContext context)
        {
            _context = context;

            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();

            RuleFor(x => x.ParentProjectId)
                .Must(Exist)
                .When(x => x.ParentProjectId.HasValue)
                .WithMessage(x => $"There are no such project with id = {x.ParentProjectId}");
        }

        private bool Exist(int? parentProjectId)
        {
            return _context.Projects.Any(x => x.ProjectId == parentProjectId);
        }
    }
}
