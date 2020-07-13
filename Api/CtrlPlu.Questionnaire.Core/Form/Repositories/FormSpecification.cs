using System;
using System.Collections.Generic;
using System.Text;
using CtrlPlu.Questionnaire.Common.Core.Repository;

namespace CtrlPlu.Questionnaire.Core.Form.Repositories
{
    public sealed class FormSpecification : BaseSpecification<Entities.Form>
    {
        public FormSpecification(int id) : base(form => form.Id == id)
        {
            AddInclude(form => form.Sections);
            AddInclude("Sections.Fields.Options");
        }
    }
}
