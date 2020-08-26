using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CtrlPlu.Questionnaire.Common.Core.UnitOFWork;
using CtrlPlu.Questionnaire.Common.Cqrs;
using CtrlPlu.Questionnaire.Core.Form.Entities;
using CtrlPlu.Questionnaire.Core.Form.Repositories;

namespace CtrlPlu.Questionnaire.Api.Application.Command.AddSubmit
{
    public class SubmitCommandHandler : ICommandHandler<SubmitCommand>
    {
        private readonly IFormRepository _formRepository;
        private readonly ISubmissionRepository _submissionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SubmitCommandHandler(
            IFormRepository formRepository,
            ISubmissionRepository submissionRepository,
            IUnitOfWork unitOfWork)
        {
            _formRepository = formRepository;
            _submissionRepository = submissionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(SubmitCommand notification, CancellationToken cancellationToken)
        {
            var form = await _formRepository
                .GetFirstOrDefaultAsync(new FormSpecification(notification.FormId));
            if (form == null)
            {
                throw new Exception("");
            }
            foreach (var notificationFiledsValue in notification.FiledsValues)
            {
                var existedField = form.Sections
                    .SelectMany(section => section.Fields)
                    .FirstOrDefault(field => field.Id == notificationFiledsValue.Id);
                var submittedValue = new Submission(existedField, notificationFiledsValue.Value);
                if (notificationFiledsValue.Values != null &&
                    notificationFiledsValue.Values.Any())
                {
                    foreach (var value in notificationFiledsValue.Values)
                    {
                        var fieldMutliValue = new FieldMultiValues(existedField, value);
                        submittedValue.AddMultiValues(fieldMutliValue);
                    }
                }
                _submissionRepository.Add(submittedValue);
            }
            await _unitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
