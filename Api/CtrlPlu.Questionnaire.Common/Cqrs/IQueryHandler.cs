using MediatR;

namespace CtrlPlu.Questionnaire.Common.Cqrs
{
    public interface IQueryHandler<TQuery, TQueryResult> : IRequestHandler<TQuery, TQueryResult>
        where TQuery : IQuery<TQueryResult>
    {
      
    }
}
