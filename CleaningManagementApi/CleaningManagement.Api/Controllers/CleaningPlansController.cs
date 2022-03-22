using CleaningManagement.Application.UseCases.CleanningPlan.BusinessLogic;
using CleaningManagement.Application.UseCases.CleanningPlan.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CleaningManagement.Api.Controllers
{
    [ApiController]
    [Route("api/cleanning-plans")]
    public class CleaningPlansController : ControllerBase
    {
        private readonly ICleanningPlanService _cleanningPlanService;

        public CleaningPlansController(ICleanningPlanService cleanningPlanService)
        {
            _cleanningPlanService = cleanningPlanService;
        }

        [HttpGet("/api/customers/{customerId}/plans")]
        public async Task<IActionResult> GetPlansByCustomerId(int customerId)
        {
            var plansDtos = await _cleanningPlanService.GetCleanningPlansAsync(customerId);

            return Ok(plansDtos);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id )
        {
            var result = await _cleanningPlanService.DeleteCleanningPlanAsync(id);

            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id,[FromBody] UpdateCleanningPlanRequestDto updateCleanningPlanDto)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Provide valid Id");
            }

            var cleanningPlanDto = await _cleanningPlanService.UpdateCleanningPlan(new UpdateCleanningPlanDto(id, updateCleanningPlanDto));

            return Ok(cleanningPlanDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCleanningPlanDto createCleanningPlanDto) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var resultDto =  await _cleanningPlanService.CreateCleanningPlanAsync(createCleanningPlanDto);
            return Ok(resultDto);
        }
    }
}