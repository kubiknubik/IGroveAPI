using IGrove.Management;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shared.Utils;
using Shared.Utils.WebAPI;
using System.Security.Claims;

namespace IGroveAPI
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
             services.AddJwt<Startup>(Configuration)
             .AddSwaggerAuthorize()
             .AddDomain(Configuration)
             .AddMessageBusses(Configuration)
             .AddManagement(Configuration)
             .AddAuthorization(options =>
             {
                 options.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
                 options.AddPolicy("User", policy => policy.RequireClaim(ClaimTypes.Role, "User"));
             });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IGroveAPI v1"));
            }


            app.UseMiddleware<ExceptionMidleware>();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
