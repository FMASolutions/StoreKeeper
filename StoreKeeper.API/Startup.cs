using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using StoreKeeper.Services;
using StoreKeeper.Data;
using Microsoft.EntityFrameworkCore;

namespace StoreKeeper.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<StoreKeeperDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default"), x => x.MigrationsAssembly("StoreKeeper.Data")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProductGroupService, ProductGroupService>();
            services.AddTransient<ISubGroupService, SubGroupService>();
            services.AddSwaggerGen(c =>{ c.SwaggerDoc("v1", new OpenApiInfo { Title = "StoreKeeper.API", Version = "v1" }); });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StoreKeeper.API v1"));
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
