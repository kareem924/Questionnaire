using System.Reflection;
using CtrlPlu.Questionnaire.Api.Extension;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
namespace CtrlPlu.Questionnaire.Api
{
    public class Startup
    {
        readonly string _myAllowSpecificOrigins = "_myAllowOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Infrastructure.Configure.ConfigureServices(
                services,
                Configuration.GetConnectionString("DefaultConnection"));
            services.ConfigureJWT(Configuration);  // configure jwt authentication
            services.ConfigureSwagger(); //configure swagger
            services.AddControllers().AddNewtonsoftJson(); ;
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddCors(options =>
            {
                options.AddPolicy(_myAllowSpecificOrigins,
                    builder =>
                    {
                        builder
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(_myAllowSpecificOrigins);
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
