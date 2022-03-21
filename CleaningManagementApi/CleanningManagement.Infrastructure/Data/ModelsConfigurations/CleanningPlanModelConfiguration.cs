using CleaningManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace CleanningManagement.Infrastructure.Data.ModelsConfigurations
{
    public static class CleanningPlanModelConfiguration
    {
        public static ModelBuilder ConfigureCleanningPlan(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CleanningPlan>().HasKey(x => x.Id);
            modelBuilder.Entity<CleanningPlan>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<CleanningPlan>().Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(256);

            modelBuilder.Entity<CleanningPlan>().Property(x => x.CustomerId).IsRequired();

            modelBuilder.Entity<CleanningPlan>().Property(x => x.CreatedAt)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<CleanningPlan>().Property(x => x.Description).HasMaxLength(512);

            return modelBuilder;
        }
    }
}
