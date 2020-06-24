using System.Collections.Generic;

namespace CtrlPlu.Questionnaire.Common.Core.Model
{
    public class SaveResult
    {
        public int Affected { get; set; }

        public IList<Error> Errors{ get; set; }

        public SaveResult()
        {
            Errors = new List<Error>();
        }
    }
}