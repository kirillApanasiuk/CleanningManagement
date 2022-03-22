using CleaningManagement.Application.UseCases.CleanningPlan.DTOs;
using CleaningManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningManagement.Application.UseCases.CleanningPlan.BusinessLogic
{
    public interface ICleanningPlanService
    {
        Task<CleanningPlanDto> CreateAsync(CreateCleanningPlanDto createCleanningPlanDto);
        Task<IEnumerable<CleanningPlanDto>> GetByCustomerIdAsync(int customerId);
        Task<bool> DeleteAsync(Guid cleanningPlanId);
        Task<CleanningPlanDto> Update(UpdateCleanningPlanDto updateCleanningPlanDto);
    }
}
