using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CtrlPlu.Questionnaire.Common.Cqrs;
using CtrlPlu.Questionnaire.Core.Form.Entities;
using CtrlPlu.Questionnaire.Core.Form.Enums;
using CtrlPlu.Questionnaire.Core.Form.Repositories;

namespace CtrlPlu.Questionnaire.Api.Application.Query.GetFormResults
{
    public class GetFormSummaryQueryHandler : IQueryHandler<GetFormSummaryQuery, FormSummaryDto>
    {
        private readonly IFormRepository _formRepository;
        private readonly ISubmissionRepository _submissionRepository;

        public GetFormSummaryQueryHandler(
            IFormRepository formRepository,
            ISubmissionRepository submissionRepository)
        {
            _formRepository = formRepository;
            _submissionRepository = submissionRepository;
        }

        public async Task<FormSummaryDto> Handle(GetFormSummaryQuery request, CancellationToken cancellationToken)
        {
            var form = await _formRepository.GetFirstOrDefaultAsync(new FormSpecification(request.FormId));
            var formFields = form.Sections.SelectMany(section => section.Fields).ToArray();
            var result = new FormSummaryDto { FormId = form.Id, AnswersSummary = new List<FormAnswerSummaryDto>() };
            foreach (var field in formFields)
            {
                var formSubmission = await _submissionRepository
                    .FindAllAsync(new SubmissionSpecification(field.Id));
                var chartType = new[]
                {
                    FieldType.CheckBox,
                    FieldType.MultipleChoice,
                    FieldType.DropDown
                };
                var multiAnswerByValue = formSubmission
                    .Where(_ => chartType.Contains(field.Type))
                    .SelectMany(fieldSubmission => fieldSubmission.MultiValues)
                    .GroupBy(groupedValue => groupedValue.Value)
                    .ToDictionary(groupedResult => groupedResult.Key, groupedResult => groupedResult.Count());
                var xxx = multiAnswerByValue
                    .SelectMany(x => formFields.Select(n => n.Options.Where(v => v.Id == int.Parse(x.Key)))).FirstOrDefault();
                var fieldAnswers = new FormAnswerSummaryDto()
                {
                    FieldType = field.Type,
                    Label = field.Label,
                    ValueSummary = formSubmission
                        .Where(_ => !chartType.Contains(field.Type))
                        .Select(fieldSubmission => fieldSubmission.Value),
                    MultiValueSummary = new MultiValueSummaryDto()
                    {
                        Answers = multiAnswerByValue
                            .Select(groupedValuesKey => formFields
                                .Where(formField => formField.Options
                                    .Any(option => option.Id == int.Parse(groupedValuesKey.Key)))
                                .SelectMany(m => m.Options)
                                .FirstOrDefault(selectedOption =>
                                    selectedOption.Id == int.Parse(groupedValuesKey.Key))
                                ?.OptionValue),
                        AnswerCount = multiAnswerByValue.Select(x => x.Value)
                    }
                };

                result.AnswersSummary.Add(fieldAnswers);
            }
            return result;

        }

    }
}
