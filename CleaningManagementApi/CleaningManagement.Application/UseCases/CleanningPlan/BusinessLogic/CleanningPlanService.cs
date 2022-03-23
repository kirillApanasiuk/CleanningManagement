using CleaningManagement.Application.UseCases.CleanningPlan.BusinessLogic;
using CleaningManagement.Application.UseCases.CleanningPlan.DTOs;
using CleaningManagement.Domain.Entities;
using CleanningManagement.Infrastructure.Data.DbContexts;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CleaningManagement.Application
{
    /// <summary>
    /// Business logic for working with cleanning plans
    /// </summary>
    public class CleanningPlanService : ICleanningPlanService
    {
        private readonly CleanningManagementDbContext _cleanningManagementDbContext;

        public CleanningPlanService(
            CleanningManagementDbContext cleanningManagementDbContext

            )
        {
            _cleanningManagementDbContext = cleanningManagementDbContext;
        }
        /// <summary>
        /// Create cleanning plan
        /// </summary>
        /// <param name="createCleanningPlanDto"></param>
        /// <returns></returns>
        public async Task<CleanningPlanDto> CreateAsync(CreateCleanningPlanDto createCleanningPlanDto)
        {
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

        /// <summary>
        /// Delete Cleanning plan
        /// </summary>
        /// <param name="cleanningPlanId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(Guid cleanningPlanId)
        {
            var cleanningPlan = await _cleanningManagementDbContext.CleanningPlans
                .AsTracking()
                .FirstOrDefaultAsync(x => x.Id == cleanningPlanId);

            if (cleanningPlan == null)
                return false;

            _cleanningManagementDbContext.Remove(cleanningPlan);

            await _cleanningManagementDbContext.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Get cleanning plans by customer id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CleanningPlanDto>> GetByCustomerIdAsync(int customerId)
        {
            var plansDtos = await _cleanningManagementDbContext.CleanningPlans
                .Where(x => x.CustomerId == customerId)
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

        /// <summary>
        /// Update cleanning plan
        /// </summary>
        /// <param name="updateCleanningPlanDto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>

        public async Task<CleanningPlanDto> Update(UpdateCleanningPlanDto updateCleanningPlanDto)
        {
            var cleanningPlan = await _cleanningManagementDbContext
                .CleanningPlans
                .AsTracking()
                .FirstOrDefaultAsync(x => x.Id == updateCleanningPlanDto.Id);

            if (cleanningPlan == null)
                throw new Exception($"Cleannig plan with given {updateCleanningPlanDto.Id} does not exist");

            cleanningPlan.Title = updateCleanningPlanDto.Title;
            cleanningPlan.Description = updateCleanningPlanDto.Description;
            cleanningPlan.CustomerId = updateCleanningPlanDto.CustomerId;

            await _cleanningManagementDbContext.SaveChangesAsync();

            var cleanningPlanDto = new CleanningPlanDto
            {
                Id = cleanningPlan.Id,
                CreatedAt = cleanningPlan.CreatedAt,
                CustomerId = cleanningPlan.CustomerId,
                Description = cleanningPlan.Description,
                Title = cleanningPlan.Title
            };

            return cleanningPlanDto;
        }
    }
}
