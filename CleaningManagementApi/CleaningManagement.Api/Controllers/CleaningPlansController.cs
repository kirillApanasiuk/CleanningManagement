using CleaningManagement.Application.UseCases.CleanningPlan.BusinessLogic;
using CleaningManagement.Application.UseCases.CleanningPlan.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CleaningManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CleaningPlansController : ControllerBase
    {
        private readonly ICleanningPlanService _cleanningPlanService;

        public CleaningPlansController(ICleanningPlanService cleanningPlanService)
        {
            _cleanningPlanService = cleanningPlanService;
        }

        [HttpGet("customers/{customerId}")]
        public async Task<IActionResult> AllPlans(int customerId)
        {
            var plansDtos = await _cleanningPlanService.GetCleanningPlansAsync(customerId);

            return Ok(plansDtos);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCleanningPlan(Guid id )
        {
            var result = await _cleanningPlanService.DeleteCleanningPlanAsync(id);

            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCleanningPlan(Guid id,[FromBody] UpdateCleanningPlanRequestDto updateCleanningPlanDto)
        {

            var cleanningPlanDto = await _cleanningPlanService.UpdateCleanningPlan(new UpdateCleanningPlanDto(id, updateCleanningPlanDto));

            return Ok(cleanningPlanDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCleanningPlan([FromBody] CreateCleanningPlanDto createCleanningPlanDto) 
        {
            var resultDto =  await _cleanningPlanService.CreateCleanningPlanAsync(createCleanningPlanDto);
            return Ok(resultDto);
        }
    }
}