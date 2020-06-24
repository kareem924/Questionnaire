using CtrlPlu.Questionnaire.Core.Form.Entities;
using CtrlPlu.Questionnaire.Core.Form.Repositories;

namespace CtrlPlu.Questionnaire.Infrastructure.Data.Repositories.Forms
{
    public class SubmissionRepository : EfRepository<Submission>, ISubmissionRepository
    {
        public SubmissionRepository(QuestionnaireDbContext dbContext) : base(dbContext)
        {
        }
    }
}
