using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CtrlPlu.Questionnaire.Common.Cqrs;

namespace CtrlPlu.Questionnaire.Api.Application.Query.GetFormResults
{
    public class GetFormSummaryQuery : IQuery<FormSummaryDto>
    {
        public int FormId { get; set; }
    }
}
