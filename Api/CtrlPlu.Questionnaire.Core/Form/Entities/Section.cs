using System;
using System.Collections.Generic;
using System.Text;

namespace CtrlPlu.Questionnaire.Core.Form.Entities
{
    public class Section
    {
        private List<Field> _fields = new List<Field>();

        public string Title { get; private set; }

        public string Description { get; private set; }

        public IReadOnlyCollection<Field> Fields => _fields.AsReadOnly();
    }
}
