using CleaningManagement.Api.ValidationRules.CleanningPlan;
using CleaningManagement.Application.UseCases.CleanningPlan.DTOs;
using CleanningManagement.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanningManagement.Api.UnitTests.ValidationRules.CleanningPlan
{
    public class UpdateCleaningPlanValidatorTests
    {
        private readonly UpdateCleanningPlanValidator _validator = new UpdateCleanningPlanValidator();

        [Fact]
        public void TitleNotEmpty_WithEmptyTitle_ValidationFails()
        {
            //arrange 
            var cleanningPlanDtoWithEmptyTitle = new UpdateCleanningPlanRequestDto { Title = string.Empty };
            //act
            var validationResult = _validator.Validate(cleanningPlanDtoWithEmptyTitle);
            //assert
            Assert.Contains(validationResult.Errors
                .Select(x => x.ErrorMessage),
                x => x == string.Format(ValidationErrors.FieldRequired, nameof(UpdateCleanningPlanRequestDto.Title)));
        }

        [Fact]
        public void Title_GreaterMaxLength_ValidationFails()
        {
            //arrange
            var stringGreaterMaxLength = new String('*', 257);
            var cleanningPlanUpdateDtoWithGreaterTitleStringLength = new UpdateCleanningPlanRequestDto { Title = stringGreaterMaxLength };
            //act
            var validationResult = _validator.Validate(cleanningPlanUpdateDtoWithGreaterTitleStringLength);
            //assert
            Assert.Contains(validationResult.Errors.Select(x => x.ErrorMessage), x => x == string.Format(ValidationErrors.MaxLength, nameof(UpdateCleanningPlanRequestDto.Title), 256));
        }

        [Fact]
        public void CustomerId_IsEmptyOrDefault_ValidationFails()
        {
            //arrange 
            var cleanningPlanUpdateDtoWithEmptyCustomerId = new UpdateCleanningPlanRequestDto { CustomerId = 0, Title = "Test title" };
            //act
            var validationResult = _validator.Validate(cleanningPlanUpdateDtoWithEmptyCustomerId);
            //assert
            Assert.Contains(validationResult.Errors
                .Select(x => x.ErrorMessage),
                x => x == string.Format(ValidationErrors.NotDefaultTypeValue, nameof(UpdateCleanningPlanRequestDto.CustomerId), 0));
        }

        [Fact]
        public void Description_IsOptional_ValidationPass()
        {
            //arrange 
            var cleanningPlanDtoWithEmptyCustomerId = new UpdateCleanningPlanRequestDto { Title = "Test title", CustomerId = 1 };
            //act
            var validationResult = _validator.Validate(cleanningPlanDtoWithEmptyCustomerId);
            //assert
            Assert.True(!validationResult.Errors.Any());
        }





    }
}
