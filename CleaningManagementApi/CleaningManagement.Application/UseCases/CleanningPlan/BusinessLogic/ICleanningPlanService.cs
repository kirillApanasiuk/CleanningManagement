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
        Task<CleanningPlanDto> CreateCleanningPlanAsync(CreateCleanningPlanDto createCleanningPlanDto);
        Task<IEnumerable<CleanningPlanDto>> GetCleanningPlansAsync(int customerId);
        Task<bool> DeleteCleanningPlanAsync(Guid cleanningPlanId);
        Task<CleanningPlanDto> UpdateCleanningPlan(UpdateCleanningPlanDto updateCleanningPlanDto);
    }
}
