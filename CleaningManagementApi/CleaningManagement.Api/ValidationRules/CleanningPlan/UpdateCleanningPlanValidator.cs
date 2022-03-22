using CleaningManagement.Application.UseCases.CleanningPlan.DTOs;
using CleanningManagement.Resources;
using FluentValidation;
using System;

namespace CleaningManagement.Api.ValidationRules.CleanningPlan
{
    public class UpdateCleanningPlanValidator : AbstractValidator<UpdateCleanningPlanDto>
    {
        public UpdateCleanningPlanValidator()
        {
            RuleFor(updateCleanningPlanDto => updateCleanningPlanDto.Id)
                .NotEmpty()
                .WithMessage(string.Format(ValidationErrors.NotDefaultTypeValue, nameof(UpdateCleanningPlanDto.Id), Guid.Empty));

            RuleFor(createCPDto => createCPDto.Title)
                   .Cascade(CascadeMode.StopOnFirstFailure)
                   .NotEmpty()
                   .WithMessage(string.Format(ValidationErrors.FieldRequired, nameof(UpdateCleanningPlanDto.Title)))
                   .MaximumLength(256)
                   .WithMessage(string.Format(ValidationErrors.MaxLength, nameof(UpdateCleanningPlanDto.Title), 256));

            RuleFor(createCPDto => createCPDto.CustomerId)
                .NotEmpty()
               .WithMessage(string.Format(ValidationErrors.NotDefaultTypeValue, nameof(UpdateCleanningPlanDto.CustomerId), int.MinValue));

            When(createCPDto => !string.IsNullOrEmpty(createCPDto.Description), () =>
            {
                RuleFor(createCPDto => createCPDto.Description)
                   .MaximumLength(512)
                   .WithMessage(string.Format(ValidationErrors.MaxLength, nameof(UpdateCleanningPlanDto.Description), 512));
            });
        }
    }
}