using System;

namespace CleaningManagement.Application.UseCases.CleanningPlan.DTOs
{
    public class CleanningPlanDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int CustomerId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
