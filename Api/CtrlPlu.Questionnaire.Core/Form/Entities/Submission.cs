using System;
using System.Collections.Generic;
using CtrlPlu.Questionnaire.Common.Core.Domain;

namespace CtrlPlu.Questionnaire.Core.Form.Entities
{
    public class Submission : BaseEntity, IAggregateRoot
    {
        private List<FieldMultiValues> _multiValues = new List<FieldMultiValues>();

        public Field Field { get; set; }

        public string Value { get; set; }

        public IReadOnlyCollection<FieldMultiValues> MultiValues => _multiValues.AsReadOnly();

        private Submission()
        {
        }

        public Submission(Field field, string value)
        {
            Field = field ?? throw new ArgumentNullException(nameof(field));
            Value = !string.IsNullOrWhiteSpace(value)
                ? value
                : string.Empty;
        }

        public void AddMultiValues(params FieldMultiValues[] multiValues)
        {
            foreach (var value in multiValues)
            {
                _multiValues.Add(value);
            }
        }
    }
}
