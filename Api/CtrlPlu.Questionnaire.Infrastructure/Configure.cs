using CtrlPlu.Questionnaire.Common.Core.UnitOFWork;
using CtrlPlu.Questionnaire.Core.Form.Repositories;
using CtrlPlu.Questionnaire.Infrastructure.Data;
using CtrlPlu.Questionnaire.Infrastructure.Data.Repositories.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CtrlPlu.Questionnaire.Infrastructure
{
    public static class Configure
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            //Context lifetime defaults to "scoped"
            services.AddDbContext<QuestionnaireDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IUnitOfWork>(provider => provider.GetService<QuestionnaireDbContext>());
            services.AddScoped<IFormRepository, FormRepository>();
            services.AddScoped<ISubmissionRepository, SubmissionRepository>();
           
        }
    }
}
