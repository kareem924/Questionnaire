using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CtrlPlu.Questionnaire.Common.Core.Domain;

namespace CtrlPlu.Questionnaire.Core.Form.Entities
{
    public class Section : BaseEntity
    {
        private List<Field> _fields = new List<Field>();

        public string Title { get; private set; }

        public string Description { get; private set; }

        public IReadOnlyCollection<Field> Fields => _fields.AsReadOnly();

        private Section()
        {
        }

        public Section(string title, string description)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Description = description;
        }

        public void AddFields(params Field[] fields)
        {
            foreach (var field in fields)
            {
                _fields.Add(field);
            }
        }

        public void RemoveFields(params Field[] fields)
        {
            _fields = _fields.Except(fields).ToList();
        }

        public void UpdateFields(params Field[] fields)
        {
            var fieldsToRemove = _fields.Except(fields).ToArray();
            var fieldsToAdd = fields.Except(_fields).ToArray();
            RemoveFields(fieldsToRemove);
            AddFields(fieldsToAdd);
        }
    }
}
