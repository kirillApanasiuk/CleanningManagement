namespace CleaningManagement.Application.UseCases.CleanningPlan.DTOs
{
    public class UpdateCleanningPlanDto: UpdateCleanningPlanRequestDto
    {
        public Guid Id { get; set; }
        public UpdateCleanningPlanDto(Guid id, UpdateCleanningPlanRequestDto updateCleanningPlanRequestDto)
        {
            Id = id;
            Title = updateCleanningPlanRequestDto.Title;
            Description = updateCleanningPlanRequestDto.Description;
            CustomerId = updateCleanningPlanRequestDto.CustomerId;
        }
    }
}
