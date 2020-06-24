using System;
using System.Collections.Generic;
using System.Text;
using CtrlPlu.Questionnaire.Common.Core.Domain;

namespace CtrlPlu.Questionnaire.Core.Form.Entities
{
    public class Form : AuditableEntity, IAggregateRoot
    {
        private  List<Section> _sections = new List<Section>();

        public string Name { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public IReadOnlyCollection<Section> Sections => _sections.AsReadOnly();

        private Form()
        {

        }
    }
}
