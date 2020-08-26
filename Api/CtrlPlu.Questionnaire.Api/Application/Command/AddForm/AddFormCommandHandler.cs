using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CtrlPlu.Questionnaire.Common.Core.UnitOFWork;
using CtrlPlu.Questionnaire.Common.Cqrs;
using CtrlPlu.Questionnaire.Core.Form.Entities;
using CtrlPlu.Questionnaire.Core.Form.Repositories;
using MediatR;

namespace CtrlPlu.Questionnaire.Api.Application.Command.AddForm
{
    public class AddFormCommandHandler : IQueryHandler<AddFormCommand, int>
    {
        private readonly IFormRepository _formRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddFormCommandHandler(IFormRepository formRepository, IUnitOfWork unitOfWork)
        {
            _formRepository = formRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<int> Handle(AddFormCommand request, CancellationToken cancellationToken)
        {
            var form = new Form(
                request.Sections.FirstOrDefault().Title,
                request.Sections.FirstOrDefault().Description);
            if (request.Sections != null)
            {
                var sections = request.Sections.Select(section =>
                {
                    var addedSection = new Section(section.Title, section.Description);
                    var addedFields = section.Fields.Select(field =>
                    {
                        var addedField = new Field(
                            field.Type,
                            field.IsRequired,
                            field.PlaceHolder,
                            field.Label,
                            field.InputMask,
                            field.Order,
                            new RatingValue(
                                field.RatingValue.From,
                                field.RatingValue.To,
                                field.RatingValue.FromLabel,
                                field.RatingValue.ToLabel));
                        if (field.FieldOptions.All(option => option != null))
                        {
                            {
                                var fieldOptions = field.FieldOptions.Select(option =>
                                    new FieldOptions(option.Value, option.Order));
                                addedField.AddOptions(fieldOptions.ToArray());
                            }
                        }
                        return addedField;
                    });
                    addedSection.AddFields(addedFields.ToArray());
                    return addedSection;
                });
                form.AddSections(sections.ToArray());
                await _formRepository.AddAsync(form);
                await _unitOfWork.SaveEntitiesAsync(cancellationToken);
            }
            return form.Id;
        }
    }
}
