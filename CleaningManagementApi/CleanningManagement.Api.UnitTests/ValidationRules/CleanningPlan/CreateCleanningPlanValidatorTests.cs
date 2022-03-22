using CleaningManagement.Api.ValidationRules.CleanningPlan;
using CleaningManagement.Application.UseCases.CleanningPlan.DTOs;
using System;
using System.Linq;
using Xunit;

namespace CleanningManagement.Api.UnitTests.ValidationRules.CleanningPlan
{
    public class CreateCleanningPlanValidatorTests
    {
        private readonly CreateCleanningPlanValidator _validator = new CreateCleanningPlanValidator();
        [Fact]
        public void TitleNotEmpty_WithEmptyTitle_ValidationFails()
        {
            //arrange 
            var cleanningPlanDtoWithEmptyTitle = new CreateCleanningPlanDto { Title = string.Empty };
            //act
            var validationResult = _validator.Validate(cleanningPlanDtoWithEmptyTitle);
            //assert
            Assert.Contains(validationResult.Errors.Select(x => x.ErrorMessage), x => x == "Title field is required");
        }

        [Fact]
        public void Title_GreaterMaxLength_ValidationFails()
        {
            //arrange
            var stringGreaterMaxLength = new String('*', 257);
            var cleanningPlanDtoWithGreaterTitleStringLength = new CreateCleanningPlanDto { Title = stringGreaterMaxLength };
            //act
            var validationResult = _validator.Validate(cleanningPlanDtoWithGreaterTitleStringLength);
            //assert
            Assert.Contains(validationResult.Errors.Select(x => x.ErrorMessage), x => x == "Title field length should be no more than 256");
        }
        
        [Fact]
        public void CustomerId_IsEmptyOrDefault_ValidationFails()
        {
            //arrange 
            var cleanningPlanDtoWithEmptyCustomerId = new CreateCleanningPlanDto { CustomerId = int.MinValue };
            //act
            var validationResult = _validator.Validate(cleanningPlanDtoWithEmptyCustomerId);
            //assert
            Assert.Contains(validationResult.Errors.Select(x => x.ErrorMessage), x => x == "Customer Identification number should be not empty");
        }

        [Fact]
        public void Description_IsOptional_ValidationPass()
        {
            //arrange 
            var cleanningPlanDtoWithEmptyCustomerId = new CreateCleanningPlanDto { Title="Test title",CustomerId = 1 };
            //act
            var validationResult = _validator.Validate(cleanningPlanDtoWithEmptyCustomerId);
            //assert
            Assert.True(!validationResult.Errors.Any());
        }

        [Fact]
        public void Description_MaxLength_ValidationFails()
        {
            //arrange
            var stringGreaterMaxLength = new String('*', 513);
            var cleanningPlanDtoWithGreaterTitleStringLength = new CreateCleanningPlanDto { Description = stringGreaterMaxLength };
            //act
            var validationResult = _validator.Validate(cleanningPlanDtoWithGreaterTitleStringLength);
            //assert
            Assert.Contains(validationResult.Errors.Select(x => x.ErrorMessage), x => x == "Title field length should be no more than 512");
        }
    }
}
