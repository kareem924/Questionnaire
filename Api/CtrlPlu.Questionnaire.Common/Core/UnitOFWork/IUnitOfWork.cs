using System;
using System.Threading;
using System.Threading.Tasks;
using CtrlPlu.Questionnaire.Common.Core.Model;

namespace CtrlPlu.Questionnaire.Common.Core.UnitOFWork
{
    public interface IUnitOfWork : IDisposable
    {
        SaveResult SaveResult { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));

        void AddError(int code, string error);

        void AddError(Error error);
    }
}