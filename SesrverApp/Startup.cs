using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ServerApp.Application;
using ServerApp.Infrastructure;

namespace ServerApp
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
            //services.AddCors(x => x.AddDefaultPolicy(y => { y.AllowAnyMethod(); y.AllowAnyOrigin(); y.AllowAnyHeader(); }));
            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SesrverApp", Version = "v1" });
            });
            services.AddMediatR(typeof(Application.DependencyInjection).Assembly);
            services.AddInfrastructure(Configuration);
            services.AddApplication(Configuration);       
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SesrverApp v1"));
            }

            app.UseRouting();

            app.UseCors(x =>
            {
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
                x.AllowAnyHeader();
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
