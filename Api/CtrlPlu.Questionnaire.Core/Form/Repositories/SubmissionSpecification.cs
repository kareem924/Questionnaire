using System;
using System.Collections.Generic;
using System.Text;
using CtrlPlu.Questionnaire.Common.Core.Repository;

namespace CtrlPlu.Questionnaire.Core.Form.Repositories
{
    public sealed class SubmissionSpecification : BaseSpecification<Entities.Submission>
    {
        public SubmissionSpecification(int fieldId) : base(submission => submission.Field.Id == fieldId)
        {
            AddInclude(submission => submission.MultiValues);
            AddInclude(submission => submission.Field);
        }

        public SubmissionSpecification() : base()
        {

        }
    }
}
