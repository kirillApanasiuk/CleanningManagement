using System;

namespace CleaningManagement.Application.UseCases.CleanningPlan.DTOs
{
    public class CreateCleanningPlanDto
    {
        public string Title { get; set; }
        public int CustomerId { get; set; }
        public string Description { get; set; }

    }


}
