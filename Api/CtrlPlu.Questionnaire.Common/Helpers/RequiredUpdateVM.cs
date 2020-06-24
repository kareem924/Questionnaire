using System.Collections.Generic;
using CtrlPlu.Questionnaire.Common.Core.Model;

namespace CtrlPlu.Questionnaire.Common.Helpers
{
    public class RequiredUpdateVM<T> where T : IVM
    {
        public T Entity { get; set; }
        public IList<SelectListItem> SelectListItems { get; set; }
    }
}
