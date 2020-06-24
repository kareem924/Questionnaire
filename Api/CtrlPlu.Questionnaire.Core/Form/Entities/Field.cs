using System;
using System.Collections.Generic;
using System.Linq;
using CtrlPlu.Questionnaire.Common.Core.Domain;
using CtrlPlu.Questionnaire.Core.Form.Enums;

namespace CtrlPlu.Questionnaire.Core.Form.Entities
{
    public class Field : BaseEntity
    {
        private List<Submission> _submission = new List<Submission>();

        private List<FieldOptions> _options = new List<FieldOptions>();
        public FieldType Type { get; private set; }

        public bool IsRequired { get; private set; }

        public string PlaceHolder { get; private set; }

        public string Label { get; private set; }

        public string InputMask { get; private set; }

        public Section Section { get; private set; }

        public IReadOnlyCollection<Submission> Submission => _submission.AsReadOnly();

        public IReadOnlyCollection<FieldOptions> Options => _options.AsReadOnly();

        private Field()
        {

        }

        public Field(
            FieldType type,
            bool isRequired,
            string placeHolder,
            string label,
            string inputMask)
        {
            UpdateField(type, isRequired, placeHolder, label, inputMask);
        }

        public void UpdateField(FieldType type,
            bool isRequired,
            string placeHolder,
            string label,
            string inputMask)
        {

            Type = type;
            IsRequired = isRequired;
            PlaceHolder = placeHolder;
            Label = !string.IsNullOrWhiteSpace(label)
                ? label
                : throw new ArgumentNullException(nameof(Label));
            InputMask = inputMask;
        }

        public void AddOptions(params FieldOptions[] options)
        {
            foreach (var option in options)
            {
                _options.Add(option);
            }
        }

        public void RemoveOptions(params FieldOptions[] options)
        {
            _options = _options.Except(options).ToList();
        }

        public void UpdateOptions(params FieldOptions[] options)
        {
            var optionsToRemove = _options.Except(options).ToArray();
            var optionsToAdd = options.Except(_options).ToArray();
            RemoveOptions(optionsToRemove);
            AddOptions(optionsToAdd);
        }
    }
}
