using System.Collections.Generic;
using CtrlPlu.Questionnaire.Common.Cqrs;

namespace CtrlPlu.Questionnaire.Api.Application.Query.GetAll
{
    public class GetAllFormsQuery : IQuery<IEnumerable<FormForAllDto>>
    {
    }
}
