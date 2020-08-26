using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CtrlPlu.Questionnaire.Common.Cqrs;
using CtrlPlu.Questionnaire.Core.Form.Entities;
using CtrlPlu.Questionnaire.Core.Form.Repositories;

namespace CtrlPlu.Questionnaire.Api.Application.Query.GetById
{
    public class GetFormByIdQueryHandler : IQueryHandler<GetFormByIdQuery, FormForIdDto>
    {
        private readonly IFormRepository _formRepository;

        public GetFormByIdQueryHandler(IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }

        public async Task<FormForIdDto> Handle(GetFormByIdQuery request, CancellationToken cancellationToken)
        {
            var form = await _formRepository.GetFirstOrDefaultAsync(new FormSpecification(request.Id));
            return MapFromFormToFormForId(form);
        }

        private FormForIdDto MapFromFormToFormForId(Form form)
        {
            var formDto = new FormForIdDto();
            if (form.Sections != null)
            {
                formDto.Sections = form.Sections.Select(MapFromSectionToSectionDto);
            }
            return formDto;
        }

        private SectionDto MapFromSectionToSectionDto(Section section)
        {
            if (section == null)
            {
                return null;
            }
            return new SectionDto
            {
                Description = section.Description,
                Title = section.Title,
                Fields = section.Fields
                    .OrderBy(field => field.Order)
                    .Select(MapFromFieldToFieldDto)
            };
        }

        private FieldDto MapFromFieldToFieldDto(Field field)
        {
            if (field == null)
            {
                return null;
            }
            return new FieldDto
            {
                Id = field.Id,
                Type = field.Type,
                PlaceHolder = field.PlaceHolder,
                InputMask = field.InputMask,
                IsRequired = field.IsRequired,
                Label = field.Label,
                RatingValue = MapFromRatingValueToRatingValueDto(field.Rating),
                FieldOptions = field.Options
                    .OrderBy(option => option.Order)
                    .Select(MapFromOptionValueToOptionValueDto)
            };
        }

        private FieldOptionDto MapFromOptionValueToOptionValueDto(FieldOptions fieldOption)
        {
            if (fieldOption == null)
            {
                return null;
            }
            return new FieldOptionDto
            {
                Value = fieldOption.OptionValue,
                Id = fieldOption.Id
            };
        }

        private RatingValueDto MapFromRatingValueToRatingValueDto(RatingValue rating)
        {
            if (rating == null)
            {
                return null;
            }
            return new RatingValueDto
            {
                ToLabel = rating.ToLabel,
                From = rating.From,
                FromLabel = rating.FromLabel,
                To = rating.To
            };
        }
    }
}
