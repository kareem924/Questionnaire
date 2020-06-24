using System;
using System.Collections.Generic;
using System.Text;
using CtrlPlu.Questionnaire.Common.Core.Domain;
using CtrlPlu.Questionnaire.Core.Form.Enums;

namespace CtrlPlu.Questionnaire.Core.Form.Entities
{
    public class Field : BaseEntity
    {
        public FieldType Type { get; private set; }

        public bool IsRequired { get; private set; }

        public string PlaceHolder { get; private set; }

        public string Label { get; private set; }

        public string InputMask { get; private set; }

        public Section Section { get; private set; }
    }
}
