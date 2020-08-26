using System;
using CtrlPlu.Questionnaire.Common.Core.Domain;

namespace CtrlPlu.Questionnaire.Core.Form.Entities
{
    public class FieldMultiValues : BaseEntity
    {
        public Field Type { get; private set; }

        public string Value { get; private set; }

        public FieldMultiValues(Field field, string value)
        {
            Type = field ?? throw new ArgumentNullException(nameof(field));
            Value = !string.IsNullOrWhiteSpace(value)
                ? value
                : string.Empty;
        }

        private FieldMultiValues()
        {

        }
    }
}
