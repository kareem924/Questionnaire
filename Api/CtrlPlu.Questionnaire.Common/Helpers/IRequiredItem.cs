using System.Collections.Generic;

namespace CtrlPlu.Questionnaire.Common.Helpers
{
    public interface IRequiredItem
    {
        IList<SelectListItem> GetItems();
    }
}
