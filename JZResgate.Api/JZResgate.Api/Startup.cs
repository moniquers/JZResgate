using JZResgate.Infra.Data.Context;
using JZResgate.Infra.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace JZResgate.Api
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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder =>
                        builder.WithOrigins("*")
                        .WithMethods("*")
                        .WithHeaders("*"));
            });

            services.AddControllers();

            services.AddDbContext<ApplicationContext>(
                options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("Default"));
                }
               );

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "JZResgate", Version = "v1" }));

            services.AddTransient<IRecoveryTruckRepository, RecoveryTruckRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("AllowOrigin");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "JZResgate");

            });

            var applicationContext = serviceProvider.GetService<ApplicationContext>();
            applicationContext.Database.Migrate();

        }
    }
}
