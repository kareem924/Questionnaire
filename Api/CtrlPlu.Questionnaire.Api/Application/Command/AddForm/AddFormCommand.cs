using CtrlPlu.Questionnaire.Common.Cqrs;
using CtrlPlu.Questionnaire.Core.Form.Enums;
using System.Collections.Generic;

namespace CtrlPlu.Questionnaire.Api.Application.Command.AddForm
{
    public class AddFormCommand : IQuery<int>
    {
        public IEnumerable<SectionDto> Sections { get; set; }
    }

    public class SectionDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<FieldDto> Fields { get; set; }
    }

    public class FieldDto
    {
        public FieldType Type { get; set; }

        public bool IsRequired { get; set; }

        public string PlaceHolder { get; set; }

        public string Label { get; set; }

        public string InputMask { get; set; }

        public int Order { get; set; }

        public RateDto RatingValue { get; set; }

        public IEnumerable<FieldOptionDto> FieldOptions { get; set; }
    }

    public class FieldOptionDto
    {
        public string Value { get; set; }

        public int Order { get; set; }


    }

    public class RateDto
    {
        public int From { get; set; }

        public int To { get; set; }

        public string FromLabel { get; set; }

        public string ToLabel { get; set; }

    }
}
