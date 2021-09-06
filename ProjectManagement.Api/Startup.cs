using System;
using System.Threading.Tasks;
using OfficeOpenXml;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ProjectManagement.Api.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using ProjectManagement.Api.Data;
using ProjectManagement.Api.Middleware;

namespace ProjectManagement.Api
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
                .AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddDbContext<AppDbContext>(options => options
                .UseLazyLoadingProxies()
                .UseSqlServer(Configuration.GetConnectionString("db")));

            services.AddSingleton<IDateTimeService, DateTimeService>();
            services.AddScoped<IReportGeneratorService, ReportGeneratorService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "ProjectManagement.Api", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; //EPPlus library (composing .xlsx files) licensing type

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                var db = serviceProvider.GetRequiredService<AppDbContext>().Database;
                
                //TODO: use cleaner option to determine whether we use in-memory db
                if (db.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
                    db.Migrate();
            }
            
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjectManagement.Api v1"));

            app.UseMiddleware<ExceptionHandlingMiddleware>();
            
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("", context =>
                {
                    context.Response.Redirect("/swagger", false);
                    return Task.CompletedTask;
                });
                endpoints.MapControllers();
            });
        }
    }
}
