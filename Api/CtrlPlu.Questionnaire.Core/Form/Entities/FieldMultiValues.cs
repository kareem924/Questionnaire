using CtrlPlu.Questionnaire.Common.Core.Domain;

namespace CtrlPlu.Questionnaire.Core.Form.Entities
{
    public class FieldMultiValues : BaseEntity
    {
        public Field Type { get; private set; }

        public string Value { get; private set; }
    }
}
