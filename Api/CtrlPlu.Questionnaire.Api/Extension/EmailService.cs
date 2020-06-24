using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Extensions
{
    public static class EmailService
    {
        public static void ConfigureEmailService(this IServiceCollection services, IConfiguration Configuration)
        {
            //services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
        }
    }
}
