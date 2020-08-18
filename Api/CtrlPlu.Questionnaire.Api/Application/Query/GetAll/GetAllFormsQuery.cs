using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CtrlPlu.Questionnaire.Api.Application.Query.GetById;
using CtrlPlu.Questionnaire.Common.Cqrs;
using CtrlPlu.Questionnaire.Core.Form.Repositories;

namespace CtrlPlu.Questionnaire.Api.Application.Query.GetAll
{
    public class GetAllFormsQuery : IQuery<IEnumerable<FormForAllDto>>
    {
        private readonly IFormRepository _formRepository;

        public GetAllFormsQuery(IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }

        public async Task<FormForIdDto> Handle(FormForAllDto request, CancellationToken cancellationToken)
        {
            //var form = await _formRepository.GetAllPagedAsync();
            //return MapFromFormToFormForId(form);
            return null;
        }
    }
}
