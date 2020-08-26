using System;
using System.Collections.Generic;
using System.Linq;
using CtrlPlu.Questionnaire.Common.Core.Domain;
using CtrlPlu.Questionnaire.Core.Form.Enums;

namespace CtrlPlu.Questionnaire.Core.Form.Entities
{
    public class Field : BaseEntity
    {

        private List<FieldOptions> _options = new List<FieldOptions>();

        public FieldType Type { get; private set; }

        public bool IsRequired { get; private set; }

        public string PlaceHolder { get; private set; }

        public string Label { get; private set; }

        public string InputMask { get; private set; }

        public int Order { get; set; }

        public RatingValue Rating { get; private set; }


        public IReadOnlyCollection<FieldOptions> Options => _options.AsReadOnly();

        private Field()
        {

        }

        public Field(
            FieldType type,
            bool isRequired,
            string placeHolder,
            string label,
            string inputMask,
            int order,
            RatingValue rate = null)
        {
            UpdateField(type, isRequired, placeHolder, label, inputMask, order, rate);
        }

        public void UpdateField(FieldType type,
            bool isRequired,
            string placeHolder,
            string label,
            string inputMask,
            int order,
            RatingValue rate = null)
        {

            Type = type;
            IsRequired = isRequired;
            PlaceHolder = placeHolder;
            Label = !string.IsNullOrWhiteSpace(label)
                ? label
                : string.Empty;
            InputMask = inputMask;
            Order = order;
            Rating = rate;
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
