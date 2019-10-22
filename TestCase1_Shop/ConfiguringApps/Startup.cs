using System.Globalization;
using Business_Logic_Layer;
using Business_Logic_Layer.Common.Services;
using Business_Logic_Layer.Services;
using Data_Access_Layer.Common.Repositories;
using Data_Access_Layer.Contexts;
using Data_Access_Layer.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace TestCase1_Shop.ConfiguringApps
{
    /// <summary>
    /// Development
    /// </summary>
    public class StartupDevelopment
    {
        private IConfiguration _configuration { get; }
        public StartupDevelopment(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();

            services.BindInjector();
            services.AddTransient<IRepository, Repository>();

            services.AddTransient<ICarService, UserService>();
            services.AddTransient<IUserService, CarService>();
            services.AddTransient<IOrderService, OrderService>();


            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(_configuration.GetConnectionString("DeveloperMSSQL"),
                optionsBuilder => optionsBuilder.MigrationsAssembly("TestCase1_Shop")));

            services.AddMvc((options) =>
            {
                options.CacheProfiles.Add("default", new CacheProfile()
                {
                    Duration = 100,
                    Location = ResponseCacheLocation.Any
                });
                options.Filters.Add<ValidateDataBaseAttribute>();
            })
            .AddRazorPagesOptions(options =>
            {
                options.RootDirectory = "/Pages";
            })
            .AddFluentValidation()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Instance = context.HttpContext.Request.Path,
                        Status = StatusCodes.Status400BadRequest,
                        Type = "https://asp.net/core",
                        Detail = "Please refer to the errors property for additional details."
                    };
                    return new BadRequestObjectResult(problemDetails)
                    {
                        ContentTypes = { "application/problem+json", "application/problem+xml" }
                    };
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<Error>();
            var supportedCultures = new[]
{
                new CultureInfo("en-US"),
                new CultureInfo("en-GB"),
                new CultureInfo("en"),
                new CultureInfo("ru-RU"),
                new CultureInfo("ru"),
            };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("ru-RU"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
    /// <summary>
    /// Production
    /// </summary>
    public class StartupProduction
    {
        private IConfiguration _configuration { get; }
        public StartupProduction(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.BindInjector();

            services.AddTransient<IRepository, Repository>();

            services.AddTransient<ICarService, UserService>();
            services.AddTransient<IUserService, CarService>();
            services.AddTransient<IOrderService, OrderService>();

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(_configuration.GetConnectionString("DeveloperMSSQL"),
                optionsBuilder => optionsBuilder.MigrationsAssembly("TestCase1_Shop")));

            services.AddMvc((options) =>
            {
                options.CacheProfiles.Add("default", new CacheProfile()
                {
                    Duration = 100,
                    Location = ResponseCacheLocation.Any
                });
                options.Filters.Add<ValidateDataBaseAttribute>();
            }).AddRazorPagesOptions(options =>
            {
                options.RootDirectory = "/Pages";
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<Error>();
            var supportedCultures = new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("en-GB"),
                new CultureInfo("en"),
                new CultureInfo("ru-RU"),
                new CultureInfo("ru"),
            };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("ru-RU"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }

    /// <summary>
    /// Other
    /// </summary>
    public class Startup
    {

    }
}
