using System;
using System.Collections.Generic;
using CtrlPlu.Questionnaire.Common.Core.Domain;

namespace CtrlPlu.Questionnaire.Core.Form.Entities
{
    public class Submission : BaseEntity, IAggregateRoot
    {
        private List<FieldMultiValues> _multiValues = new List<FieldMultiValues>();

        public Form Form { get; set; }

        public Field Field { get; set; }

        public string value { get; set; }

        public IReadOnlyCollection<FieldMultiValues> MultiValues => _multiValues.AsReadOnly();

        private Submission()
        {
        }

        public Submission(Form form, Field field, string value)
        {
            Form = form ?? throw new ArgumentNullException(nameof(form));
            Field = field ?? throw new ArgumentNullException(nameof(field));
            value = !string.IsNullOrWhiteSpace(value)
                ? value
                : throw new ArgumentNullException(nameof(value));
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
