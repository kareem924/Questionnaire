using System;
using System.Collections.Generic;
using System.Linq;
using CtrlPlu.Questionnaire.Common.Core.Domain;

namespace CtrlPlu.Questionnaire.Core.Form.Entities
{
    public class Form : AuditableEntity, IAggregateRoot
    {
        private List<Section> _sections = new List<Section>();

        public IReadOnlyCollection<Section> Sections => _sections.AsReadOnly();

        public Form()
        {
        }

        public void AddSections(params Section[] sections)
        {
            foreach (var field in sections)
            {
                _sections.Add(field);
            }
        }

        public void RemoveSections(params Section[] sections)
        {
            _sections = _sections.Except(sections).ToList();
        }

        public void UpdateSections(params Section[] sections)
        {
            var fieldsToRemove = _sections.Except(sections).ToArray();
            var fieldsToAdd = sections.Except(_sections).ToArray();
            RemoveSections(fieldsToRemove);
            AddSections(fieldsToAdd);
        }
    }
}
