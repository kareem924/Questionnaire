﻿using CtrlPlu.Questionnaire.Core.Form.Enums;
using System.Collections.Generic;

namespace CtrlPlu.Questionnaire.Api.Application.Query.GetById
{
    public class FormForIdDto
    {
        public IEnumerable<SectionDto> Sections { get; set; }
    }

    public class SectionDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<FieldDto> Fields { get; set; }
    }

    public class FieldDto
    {
        public int Id { get; set; }

        public FieldType Type { get; set; }

        public bool IsRequired { get; set; }

        public string PlaceHolder { get; set; }

        public string Label { get; set; }

        public string InputMask { get; set; }

        public RatingValueDto RatingValue { get; set; }

        public IEnumerable<FieldOptionDto> FieldOptions { get; set; }
    }

    public class FieldOptionDto
    {
        public string Value { get; set; }

        public int Id { get; set; }

    }

    public class RatingValueDto
    {
        public int From { get; set; }

        public int To { get; set; }

        public string FromLabel { get; set; }

        public string ToLabel { get; set; }
    }
}
