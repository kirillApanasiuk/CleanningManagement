using CleaningManagement.Domain.Entities;
using CleanningManagement.Infrastructure.Data.ModelsConfigurations;
using CleanningManagement.Infrastructure.Data.Seeds;
using Microsoft.EntityFrameworkCore;

namespace CleanningManagement.Infrastructure.Data.DbContexts
{
    public class CleanningManagementDbContext : DbContext

    {
        public DbSet<CleanningPlan> CleanningPlans { get; set; }
        public CleanningManagementDbContext(DbContextOptions<CleanningManagementDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureCleanningPlan();
            modelBuilder.Seed();
        }
    }
}