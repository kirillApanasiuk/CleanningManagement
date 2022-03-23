using CleaningManagement.Api;
using CleanningManagement.Infrastructure.Data.DbContexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace CleanningManagement.Tests.Integration
{
    public class TestingWebAppFactory<TEntryPoint> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<CleanningManagementDbContext>));

                if (descriptor != null)
                    services.Remove(descriptor);

                var connectionString = "Server=(localdb)\\mssqllocaldb;Database=CleanningManagementTestDB;Trusted_Connection=True;";

                services.AddDbContext<CleanningManagementDbContext>(opts =>
                                opts.UseSqlServer(connectionString,
                                x => x.MigrationsAssembly("CleanningManagement.Infrastructure"))
                                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
               );

                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                {
                    using (var appContext = scope.ServiceProvider.GetRequiredService<CleanningManagementDbContext>())
                    {
                        try
                        {
                            appContext.Database.Migrate();
                        }
                        catch (System.Exception)
                        {

                            throw;
                        }
                    }
                }
            }
            );
        }
    }
}
