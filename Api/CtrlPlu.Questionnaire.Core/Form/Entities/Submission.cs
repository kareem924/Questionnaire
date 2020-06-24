using CtrlPlu.Questionnaire.Common.Core.Domain;

namespace CtrlPlu.Questionnaire.Core.Form.Entities
{
    public class Submission : BaseEntity, IAggregateRoot
    {
        public Form Form { get; set; }

        public Field Field { get; set; }

        public string value { get; set; }



    }
}
