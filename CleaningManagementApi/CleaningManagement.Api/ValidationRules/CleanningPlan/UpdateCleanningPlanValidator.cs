using CleaningManagement.Application.UseCases.CleanningPlan.DTOs;
using FluentValidation;

namespace CleaningManagement.Api.ValidationRules.CleanningPlan
{
    public class UpdateCleanningPlanValidator : AbstractValidator<UpdateCleanningPlanDto>
    {
        public UpdateCleanningPlanValidator()
        {
            RuleFor(updateCleanningPlanDto => updateCleanningPlanDto.Id)
                .NotEmpty()
                .WithMessage("Provide valid Id");

            RuleFor(createCPDto => createCPDto.Title)
                 .Cascade(CascadeMode.StopOnFirstFailure)
                 .NotEmpty()
                 .WithMessage("Title field is required")
                 .MaximumLength(256).WithMessage("Title field length should be less than 256");

            RuleFor(createCPDto => createCPDto.CustomerId)
                .NotEmpty()
                .WithMessage("Customer Identification number should be not empty");

            When(createCPDto => !string.IsNullOrEmpty(createCPDto.Description), () =>
            {
                RuleFor(createCPDto => createCPDto.Description)
                   .MaximumLength(512);
            });
        }
    }
}
