using CleaningManagement.Application.UseCases.CleanningPlan.BusinessLogic;
using CleaningManagement.Application.UseCases.CleanningPlan.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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
        /// <summary>
        /// Gets customer cleaning plans by given customerId
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>List of cleanning plans</returns>

        [HttpGet("/api/customers/{customerId}/plans")]
        public async Task<IActionResult> GetPlansByCustomerId(int customerId)
        {
            var plansDtos = await _cleanningPlanService.GetByCustomerIdAsync(customerId);

            return Ok(plansDtos);
        }

        /// <summary>
        /// Delete cleanning plan by given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _cleanningPlanService.DeleteAsync(id);

            return Ok(result);
        }


        /// <summary>
        /// Update cleanning plan
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateCleanningPlanDto"></param>
        /// <returns>Updated created cleanning plan</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT 
        ///     {
        ///        "title": "Changed title",
        ///        "customerId": 11,
        ///        "description": "Changed description text"
        ///     }
        ///</remarks>

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCleanningPlanRequestDto updateCleanningPlanDto)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Provide valid Id");
            }

            var cleanningPlanDto = await _cleanningPlanService.Update(new UpdateCleanningPlanDto(id, updateCleanningPlanDto));

            return Ok(cleanningPlanDto);
        }

        /// <summary>
        /// Create cleanning plan
        /// </summary>
        /// <param name="createCleanningPlanDto"></param>
        /// <returns>A newly created cleanning plan</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST 
        ///     {
        ///        "title": "Title for testing purposes",
        ///        "customerId": 2,
        ///        "description": "description text"
        ///     }
        ///</remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateCleanningPlanDto createCleanningPlanDto)
        {

            var resultDto = await _cleanningPlanService.CreateAsync(createCleanningPlanDto);
            return Ok(resultDto);
        }
    }
}