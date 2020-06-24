using CtrlPlu.Questionnaire.Common.Cqrs;

namespace CtrlPlu.Questionnaire.Api.Application.Command.UpdateForm
{
    public class UpdateFormCommand : ICommand
    {
        public int Id { get; set; }
    }
}
