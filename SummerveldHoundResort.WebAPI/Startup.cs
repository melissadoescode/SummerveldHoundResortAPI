using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SummerveldHoundResort.Infrastructure.Interfaces.Dapper;
using SummerveldHoundResort.Infrastructure.Services;
using SummerveldHoundResort.Infrastructure.Enum;
using SummerveldHoundResort.Infrastructure.Factories;
using SummerveldHoundResort.Infrastructure.Repositories;
using SummerveldHoundResort.Infrastructure.Interfaces;

namespace SummerveldHoundResort.WebAPI
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SummerveldHoundResort.WebAPI", Version = "v1" });
            });
            services.AddDbContext<DataContext.AppDbContext>(options =>
                          options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IDapper, DapperService>();

            var connectionDict = new Dictionary<DbConnectionName, string>
            {
                { DbConnectionName.SummerveldHoundResortDev, this.Configuration.GetConnectionString("DefaultConnection") }
            };

            services.AddSingleton<IDictionary<DbConnectionName, string>>(connectionDict);
        }

        // This method gets called by the runtime. SUse this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SummerveldHoundResort.WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
