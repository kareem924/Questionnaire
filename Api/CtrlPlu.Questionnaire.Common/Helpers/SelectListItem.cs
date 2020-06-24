using System.Collections.Generic;

namespace CtrlPlu.Questionnaire.Common.Helpers
{
    public class SelectListItem
    {
        public string Key { get; set; }
        public IList<RequiredItems> Values { get; set; }
    }
}
