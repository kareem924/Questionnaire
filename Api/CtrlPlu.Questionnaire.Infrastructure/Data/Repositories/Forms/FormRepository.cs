using CtrlPlu.Questionnaire.Core.Form.Entities;
using CtrlPlu.Questionnaire.Core.Form.Repositories;

namespace CtrlPlu.Questionnaire.Infrastructure.Data.Repositories.Forms
{
    public class FormRepository : EfRepository<Form>, IFormRepository
    {
        public FormRepository(QuestionnaireDbContext dbContext) : base(dbContext)
        {
        }
    }
}
