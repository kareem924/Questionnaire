using System.Collections.Generic;
using System.Threading.Tasks;
using CtrlPlu.Questionnaire.Common.Core.Domain;
using CtrlPlu.Questionnaire.Common.Core.Model;

namespace CtrlPlu.Questionnaire.Common.Core.Repository
{
    public interface ISpecificationRepository<T> where T : class, IAggregateRoot

    {
        T GetById(object id);

        Task<T> GetByIdAsync(object id);

        T Find(ISpecification<T> spec);

        Task<T> FindAsync(ISpecification<T> specification);

        ICollection<T> FindAll(ISpecification<T> specification);

        Task<ICollection<T>> FindAllAsync(ISpecification<T> specification);

        Task<PagedResult<T, IVM>> GetAllPagedAsync(ISpecification<T> specification, QueryModel query);

        T Add(T entity);

        Task<T> AddAsync(T entity);

        IEnumerable<T> AddRange(IReadOnlyCollection<T> entityList);

        Task<IEnumerable<T>> AddRangeAsync(IReadOnlyCollection<T> entityList);

        T Update(T updated, object key);

        Task<T> UpdateAsync(T updated, object key);

        void Delete(T entity);

        void Attach(T entity);

        int Count(ISpecification<T> spec);

        Task<int> CountAsync(ISpecification<T> spec);
    }
}
