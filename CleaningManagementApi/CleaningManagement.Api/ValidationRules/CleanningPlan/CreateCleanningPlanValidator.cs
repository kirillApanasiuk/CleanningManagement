using CleaningManagement.Application.UseCases.CleanningPlan.DTOs;
using CleanningManagement.Resources;
using FluentValidation;

namespace CleaningManagement.Api.ValidationRules.CleanningPlan
{
    public class CreateCleanningPlanValidator : AbstractValidator<CreateCleanningPlanDto>
    {
        public CreateCleanningPlanValidator()
        {
            RuleFor(createCPDto => createCPDto.Title)
                  .Cascade(CascadeMode.StopOnFirstFailure)
                  .NotEmpty()
                  .WithMessage(string.Format(ValidationErrors.FieldRequired, nameof(CreateCleanningPlanDto.Title)))
                  .MaximumLength(256)
                  .WithMessage(string.Format(ValidationErrors.MaxLength, nameof(CreateCleanningPlanDto.Title), 256));

            RuleFor(createCPDto => createCPDto.CustomerId)
                .NotEmpty()
               .WithMessage(string.Format(ValidationErrors.NotDefaultTypeValue, nameof(CreateCleanningPlanDto.CustomerId), 0));

            When(createCPDto => !string.IsNullOrEmpty(createCPDto.Description), () =>
            {
                RuleFor(createCPDto => createCPDto.Description)
                   .MaximumLength(512)
                   .WithMessage(string.Format(ValidationErrors.MaxLength, nameof(CreateCleanningPlanDto.Description), 512));
            });
        }
    }
}
