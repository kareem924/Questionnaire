using MediatR;

namespace CtrlPlu.Questionnaire.Common.Cqrs
{
    public interface IQuery<TQueryResult> : IRequest<TQueryResult>
    {
    }
}
