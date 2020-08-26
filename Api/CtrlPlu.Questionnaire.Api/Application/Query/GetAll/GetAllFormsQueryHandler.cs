using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CtrlPlu.Questionnaire.Api.Application.Query.GetById;
using CtrlPlu.Questionnaire.Common.Cqrs;
using CtrlPlu.Questionnaire.Core.Form.Repositories;

namespace CtrlPlu.Questionnaire.Api.Application.Query.GetAll
{
    public class GetAllFormsQueryHandler : IQueryHandler<GetAllFormsQuery, IEnumerable<FormForAllDto>>
    {

        private readonly IFormRepository _formRepository;

        public GetAllFormsQueryHandler(IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }

        public async Task<IEnumerable<FormForAllDto>> Handle(GetAllFormsQuery request, CancellationToken cancellationToken)
        {
            //var form = await _formRepository.GetAllPagedAsync(new FormSpecification(), request.Query);
            //return MapFromFormToFormForId(form);
            return null;
        }


    }
}
