using System;
using System.Collections.Generic;
using System.Text;
using CtrlPlu.Questionnaire.Common.Core.Domain;

namespace CtrlPlu.Questionnaire.Core.Form.Entities
{
    public class RatingValue : AuditableEntity
    {
        public int From { get; private set; }

        public int To { get; private set; }

        public string FromLabel { get; private set; }

        public string ToLabel { get; private set; }

        private RatingValue()
        {

        }

        public RatingValue(int from, int to, string fromLabel, string toLabel)
        {
            From = @from < 0 
                ? throw new ArgumentNullException(nameof(@from)) 
                : @from;
            To = to < 0 || to > 10 
                ? throw new ArgumentNullException(nameof(to)) 
                : to;
            FromLabel = fromLabel;
            ToLabel = toLabel;
        }
    }
}
