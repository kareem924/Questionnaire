using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CtrlPlu.Questionnaire.Common.Core.DBContext
{
    public partial interface ICtrlPlusDbContext : IDisposable
    {
        DatabaseFacade Database { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();

        Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken);

        ChangeTracker ChangeTracker { get; }

        EntityEntry Entry<TEntity>(object entity) where TEntity : class;

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        string ToString();
    }
}
