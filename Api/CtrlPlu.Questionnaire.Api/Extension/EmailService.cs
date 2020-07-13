using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CtrlPlu.Questionnaire.Api.Extension
{
    public static class EmailService
    {
        public static void ConfigureEmailService(this IServiceCollection services, IConfiguration Configuration)
        {
            //services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
        }
    }
}
