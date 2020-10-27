using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CtrlPlu.Questionnaire.Core.Form.Enums;

namespace CtrlPlu.Questionnaire.Api.Application.Query.GetFormResults
{
    public class FormSummaryDto
    {
        public int FormId { get; set; }

        public List<FormAnswerSummaryDto> AnswersSummary { get; set; }
    }

    public class FormAnswerSummaryDto
    {
        public FieldType FieldType { get; set; }

        public string Label { get; set; }

        public MultiValueSummaryDto MultiValueSummary { get; set; }

        public IEnumerable<string> ValueSummary { get; set; }
    }

    public class MultiValueSummaryDto
    {
        public IEnumerable<string> Answers { get; set; }

        public IEnumerable<int> AnswerCount { get; set; }
    }
}