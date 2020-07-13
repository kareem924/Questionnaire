using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CtrlPlu.Questionnaire.Api.Extension
{
    public static class SwaggerService
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }
    }
}
