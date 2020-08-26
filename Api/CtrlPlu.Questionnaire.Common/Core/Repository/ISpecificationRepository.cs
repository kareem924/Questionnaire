using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CtrlPlu.Questionnaire.Common.Core.Domain;
using CtrlPlu.Questionnaire.Common.Core.Model;

namespace CtrlPlu.Questionnaire.Common.Core.Repository
{
    public interface ISpecificationRepository<TEntity> where TEntity : class, IAggregateRoot

    {
        TEntity GetById(object id);

        Task<TEntity> GetByIdAsync(object id);

        TEntity Find(ISpecification<TEntity> spec);

        Task<TEntity> FindAsync(ISpecification<TEntity> specification);

        ICollection<TEntity> FindAll(ISpecification<TEntity> specification);

        Task<ICollection<TEntity>> FindAllAsync(ISpecification<TEntity> specification);

        Task<PagedResult<TEntity, IVM>> GetAllPagedAsync(
            ISpecification<TEntity> specification,
            QueryModel query,
            Func<TEntity, IVM> func);

        TEntity Add(TEntity entity);

        Task<TEntity> AddAsync(TEntity entity);

        IEnumerable<TEntity> AddRange(IReadOnlyCollection<TEntity> entityList);

        Task<IEnumerable<TEntity>> AddRangeAsync(IReadOnlyCollection<TEntity> entityList);

        TEntity Update(TEntity updated, object key);

        Task<TEntity> UpdateAsync(TEntity updated, object key);

        void Delete(TEntity entity);

        void Attach(TEntity entity);

        int Count(ISpecification<TEntity> spec);

        Task<bool> AnyAsync(ISpecification<TEntity> spec);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> spec);

        Task<int> CountAsync(ISpecification<TEntity> spec);

        Task<TEntity> GetSingleOrDefaultAsync(ISpecification<TEntity> spec);

        Task<TEntity> GetFirstOrDefaultAsync(ISpecification<TEntity> spec);
    }
}
