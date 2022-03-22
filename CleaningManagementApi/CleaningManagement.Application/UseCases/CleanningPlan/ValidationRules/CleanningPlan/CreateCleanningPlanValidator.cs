using CleaningManagement.Application.UseCases.CleanningPlan.DTOs;
using FluentValidation;

namespace CleaningManagement.Application.UseCases.CleanningPlan.ValidationRules.CleanningPlan
{
    public class CreateCleanningPlanValidator:AbstractValidator<CreateCleanningPlanDto>
    {
        public CreateCleanningPlanValidator()
        {
            RuleFor(createCPDto => createCPDto.Title).MaximumLength(256);
            RuleFor(createCPDto=>createCPDto.CustomerId).NotEmpty();
            RuleFor(createCPDto=>createCPDto.Description).NotNull().MaximumLength(512);
        }
    }
}
