using CleaningManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanningManagement.Infrastructure.Data.Seeds
{
    public static class InitialDataSeed
    {
        public static ModelBuilder Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CleanningPlan>().HasData(
                new CleanningPlan
                {
                    Id = Guid.Parse("183eef1f-e4eb-489d-bd3d-720443bce7c2"),
                    CustomerId = 1,
                    Description = "Simple cleanning plan",
                    CreatedAt = DateTime.Now,
                    Title = "Simple",
                }); ;

            return modelBuilder;
        }
    }
}
