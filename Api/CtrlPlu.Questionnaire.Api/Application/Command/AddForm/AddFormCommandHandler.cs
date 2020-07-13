using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CtrlPlu.Questionnaire.Common.Core.UnitOFWork;
using CtrlPlu.Questionnaire.Common.Cqrs;
using CtrlPlu.Questionnaire.Core.Form.Entities;
using CtrlPlu.Questionnaire.Core.Form.Repositories;

namespace CtrlPlu.Questionnaire.Api.Application.Command.AddForm
{
    public class AddFormCommandHandler : ICommandHandler<AddFormCommand>
    {
        private readonly IFormRepository _formRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddFormCommandHandler(IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }

        public async Task Handle(AddFormCommand notification, CancellationToken cancellationToken)
        {
            var form = new Form(notification.Title, notification.Description);
            if (notification.Sections != null)
            {
                var sections = notification.Sections.Select(section =>
                {
                    var addedSection = new Section(section.Title, section.Description);
                    var addedFields = section.Fields.Select(field =>
                    {
                        var addedField = new Field(
                            field.Type,
                            field.IsRequired,
                            field.PlaceHolder,
                            field.Label,
                            field.InputMask);
                        var fieldOptions = field.FieldOptions.Select(option =>
                            new FieldOptions(option.Value));
                        addedField.AddOptions(fieldOptions.ToArray());
                        return addedField;
                    });
                    addedSection.AddFields(addedFields.ToArray());
                    return addedSection;
                });
                form.AddSections(sections.ToArray());
                await _formRepository.AddAsync(form);
                await _unitOfWork.SaveEntitiesAsync(cancellationToken);
            }


        }
    }
}
