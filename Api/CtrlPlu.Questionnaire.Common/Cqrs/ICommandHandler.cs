using MediatR;

namespace CtrlPlu.Questionnaire.Common.Cqrs
{
    public interface ICommandHandler<TCommand> : INotificationHandler<TCommand>
        where TCommand : ICommand
    {

    }
}
