using System;
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

        private Field()
        {

        }

        public Field(
            FieldType type,
            bool isRequired,
            string placeHolder,
            string label,
            string inputMask)
        {
            Type = type;
            IsRequired = isRequired;
            PlaceHolder =placeHolder;
            Label = !string.IsNullOrWhiteSpace(Label)
                ? Label
                : throw new ArgumentNullException(nameof(Label));
            InputMask = inputMask;
        }
    }
}
