using System;
using System.Collections.Generic;
using System.Text;
using CtrlPlu.Questionnaire.Common.Core.Domain;

namespace CtrlPlu.Questionnaire.Core.Form.Entities
{
    public class FieldMutliValues : BaseEntity
    {
        public Field Type { get; private set; }

        public string Value { get; private set; }
    }
}
