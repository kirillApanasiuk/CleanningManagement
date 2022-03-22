using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using CleanningManagement.Infrastructure.Data.DbContexts;
using CleaningManagement.Application;
using CleaningManagement.Application.UseCases.CleanningPlan.BusinessLogic;
using FluentValidation.AspNetCore;
using System.Reflection;
using CleaningManagement.Api.ValidationRules.CleanningPlan;
using System.IO;
using System;

namespace CleaningManagement.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(opts => {
                    opts.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                }
               );

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Cleanning Plan web API",
                    Description = "Service oriented REST APIs, which allow customers to create cleaning plans"
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            services.AddScoped<ICleanningPlanService, CleanningPlanService>();

            services.AddDbContext<CleanningManagementDbContext>(opts =>
                opts.UseSqlServer(Configuration.GetConnectionString("SqlServerDbProviderCMDataBase"),
                x => x.MigrationsAssembly("CleanningManagement.Infrastructure"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
