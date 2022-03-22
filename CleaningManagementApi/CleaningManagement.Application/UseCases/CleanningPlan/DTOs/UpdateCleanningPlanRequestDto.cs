using System;

namespace CleaningManagement.Application.UseCases.CleanningPlan.DTOs
{
    public class UpdateCleanningPlanRequestDto
    {
        public string Title { get; set; }
        public int CustomerId { get; set; }
        public string Description { get; set; }
    }
}
