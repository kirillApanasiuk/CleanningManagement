using CleaningManagement.Application.UseCases.CleanningPlan.BusinessLogic;
using CleaningManagement.Application.UseCases.CleanningPlan.DTOs;
using CleaningManagement.Domain.Entities;
using CleanningManagement.Infrastructure.Data.DbContexts;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CleaningManagement.Application
{
    public class CleanningPlanService : ICleanningPlanService
    {
        private readonly CleanningManagementDbContext _cleanningManagementDbContext;
        private readonly IValidator<CreateCleanningPlanDto> _createCleanningPlanValidator;
        private readonly IValidator<UpdateCleanningPlanDto> _updateCleanningPlanValidator;

        public CleanningPlanService(
            CleanningManagementDbContext cleanningManagementDbContext,
            IValidator<CreateCleanningPlanDto> createCleanningPlanValidator,
            IValidator<UpdateCleanningPlanDto> updateCleanningPlanValidator
            )
        {
            _cleanningManagementDbContext = cleanningManagementDbContext;
            _createCleanningPlanValidator = createCleanningPlanValidator;
            _updateCleanningPlanValidator = updateCleanningPlanValidator;
        }

        public async Task<CleanningPlanDto> CreateCleanningPlanAsync(CreateCleanningPlanDto createCleanningPlanDto)
        {
            var validationResult = _createCleanningPlanValidator.Validate(createCleanningPlanDto);

            if (!validationResult.IsValid)
            {
                //TODO
                return null;
            }

            var newCleanningPlan = new CleanningPlan
            {
                CustomerId = createCleanningPlanDto.CustomerId,
                Description = createCleanningPlanDto.Description,
                Title = createCleanningPlanDto.Title
            };

            _cleanningManagementDbContext.Add(newCleanningPlan);
            await _cleanningManagementDbContext.SaveChangesAsync();

            var cleanningPlanDto = new CleanningPlanDto 
            { 
                Id = newCleanningPlan.Id,
                CreatedAt = newCleanningPlan.CreatedAt,
                CustomerId = createCleanningPlanDto.CustomerId,
                Description = newCleanningPlan.Description,
                Title = newCleanningPlan.Title
            };

            return cleanningPlanDto;
        }

        public async Task<bool> DeleteCleanningPlanAsync(Guid cleanningPlanId)
        {
            var cleanningPlan = await _cleanningManagementDbContext.CleanningPlans.AsTracking().FirstOrDefaultAsync(x => x.Id == cleanningPlanId);
            if (cleanningPlan == null)
                return false;

            _cleanningManagementDbContext.Remove(cleanningPlan);

            await _cleanningManagementDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<CleanningPlanDto>> GetCleanningPlansAsync(int customerId)
        {
            //TODO validation

            var plansDtos = await _cleanningManagementDbContext.CleanningPlans.Where(x => x.CustomerId == customerId)
                .Select(x => new CleanningPlanDto
                {
                    Id = x.Id,
                    CreatedAt = x.CreatedAt,
                    CustomerId = x.CustomerId,
                    Description = x.Description,
                    Title = x.Title

                }).ToListAsync();

            return plansDtos;
        }

        public async Task<CleanningPlanDto> UpdateCleanningPlan(UpdateCleanningPlanDto updateCleanningPlanDto)
        {

            var validationResult = _updateCleanningPlanValidator.Validate(updateCleanningPlanDto);
            if (!validationResult.IsValid)
            {
                return null;
            }
            
            var cleanningPlan = await _cleanningManagementDbContext
                .CleanningPlans
                .AsTracking()
                .FirstOrDefaultAsync(x => x.Id == updateCleanningPlanDto.Id);

            if (cleanningPlan == null)
                new CleanningPlanDto();

            cleanningPlan.Title = updateCleanningPlanDto.Title;
            cleanningPlan.Description = updateCleanningPlanDto.Description;
            cleanningPlan.CustomerId = updateCleanningPlanDto.CustomerId;

            await _cleanningManagementDbContext.SaveChangesAsync();

            var cleanningPlanDto = new CleanningPlanDto { 
                Id = cleanningPlan.Id, 
                CreatedAt = cleanningPlan.CreatedAt,
                CustomerId= cleanningPlan.CustomerId,
                Description= cleanningPlan.Description,
                Title   = cleanningPlan.Title
            };

            return cleanningPlanDto;
        }
    }
}
