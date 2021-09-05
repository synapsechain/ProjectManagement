using System.Linq;
using FluentValidation;
using ProjectManagement.Api.Data;
using ProjectManagement.Api.Data.DTOs;

namespace ProjectManagement.Api.Validators
{
    public class ProjectDtoValidator : AbstractValidator<ProjectDto>
    {
        private readonly AppDbContext _context;

        public ProjectDtoValidator(AppDbContext context)
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
            return _context.Projects.Any(x => x.Id == parentProjectId);
        }
    }
}
