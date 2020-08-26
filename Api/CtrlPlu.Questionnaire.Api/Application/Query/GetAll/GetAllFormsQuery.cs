using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CtrlPlu.Questionnaire.Api.Application.Query.GetById;
using CtrlPlu.Questionnaire.Common.Core.Model;
using CtrlPlu.Questionnaire.Common.Cqrs;
using CtrlPlu.Questionnaire.Core.Form.Repositories;

namespace CtrlPlu.Questionnaire.Api.Application.Query.GetAll
{
    public class GetAllFormsQuery : IQuery<IEnumerable<FormForAllDto>>
    {

        public QueryModel Query { get; set; }
    }
}
