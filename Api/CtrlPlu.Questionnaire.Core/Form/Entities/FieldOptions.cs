using System;
using System.Collections.Generic;
using System.Text;
using CtrlPlu.Questionnaire.Common.Core.Domain;

namespace CtrlPlu.Questionnaire.Core.Form.Entities
{
    public class FieldOptions : BaseEntity
    {
        public string OptionValue { get; private set; }

        public FieldOptions(string optionValue)
        {
            OptionValue = string.IsNullOrWhiteSpace(optionValue)
                ? throw new ArgumentNullException(nameof(optionValue))
                : OptionValue = optionValue;
        }
    }
}
