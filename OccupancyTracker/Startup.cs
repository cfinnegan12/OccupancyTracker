using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OccupancyData;
using OccupancyServices;
using OccupancyServices.Interfaces;

namespace OccupancyTracker
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
            var server = Configuration["DBServer"];
            var port = Configuration["DBPort"] ?? "1433";
            var user = Configuration["DBUser"];
            var password = Configuration["DBPassword"];
            var database = Configuration["DBName"] ?? "OccupancyDB";

            services.AddControllersWithViews();

            //Dependancy Injection
            services.AddScoped<IBuildingService, BuildingService>();
            services.AddScoped<IComputerService, ComputerService>();
            services.AddScoped<ISpaceService, SpaceService>();
            services.AddScoped<ILabService, LabService>();


            services.AddDbContext<OccupancyDbContext>(options
                => options.UseSqlServer($"Server={server},{port};Initial Catalog={database};User ID={user};Password={password}"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, OccupancyDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            dbContext.Database.Migrate();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
