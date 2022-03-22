using CleaningManagement.Application.UseCases.CleanningPlan.DTOs;
using FluentValidation;

namespace CleaningManagement.Application.UseCases.CleanningPlan.ValidationRules.CleanningPlan
{
    public class UpdateCleanningPlanValidator: AbstractValidator<UpdateCleanningPlanDto>

    {
        public UpdateCleanningPlanValidator()
        {
            RuleFor(updateCleanningPlanDto=>updateCleanningPlanDto.Id).NotEmpty();
            RuleFor(updateCPDto => updateCPDto.Title).MaximumLength(256);
            RuleFor(updateCPDto => updateCPDto.CustomerId).NotEmpty();
            RuleFor(updateCPDto => updateCPDto.Description).NotNull().MaximumLength(512);
        }
    }
}
