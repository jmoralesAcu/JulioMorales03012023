using CesarMorales.ApplicationLayer;
using CesarMorales.Interfaces;
using CesarMorales.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CesarMorales
{
    public class Startup
    {
        readonly string policy = "MyPolicy";
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cesar Morales", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(policy,
                    builder =>
                    {
                        builder.AllowAnyHeader()
                            .WithOrigins("*")
                            .AllowAnyMethod()
                            .SetIsOriginAllowed((Host) => true);
                    });
            });

            services.AddSingleton<IInfrastructure, Infrastructure>();
            services.AddScoped<IPersonaApplication, PersonaApplication>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cesar Morales"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(policy);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
