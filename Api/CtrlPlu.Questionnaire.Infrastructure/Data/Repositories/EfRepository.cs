using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CtrlPlu.Questionnaire.Common.Core.Domain;
using CtrlPlu.Questionnaire.Common.Core.Model;
using CtrlPlu.Questionnaire.Common.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace CtrlPlu.Questionnaire.Infrastructure.Data.Repositories
{
    public abstract class EfRepository<T> : ISpecificationRepository<T> where T : class, IAggregateRoot
    {
        private readonly QuestionnaireDbContext _dbContext;

        protected EfRepository(QuestionnaireDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T GetById(object id)
        {
            return _dbContext.Set<T>().Find(id);

        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public T Find(ISpecification<T> spec)
        {
            return ApplySpecification(spec).SingleOrDefault();
        }

        public async Task<T> FindAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).SingleOrDefaultAsync();
        }

        public ICollection<T> FindAll(ISpecification<T> specification)
        {
            return ApplySpecification(specification).ToList();
        }

        public async Task<ICollection<T>> FindAllAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public IEnumerable<T> AddRange(IReadOnlyCollection<T> entityList)
        {
            _dbContext.Set<T>().AddRange(entityList);
            return entityList;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IReadOnlyCollection<T> entityList)
        {
            await _dbContext.Set<T>().AddRangeAsync(entityList);
            return entityList;
        }

        public T Update(T updated, object key)
        {
            T existing = _dbContext.Set<T>().Find(key);
            if (existing != null)
            {
                _dbContext.Entry(existing).CurrentValues.SetValues(updated);
            }
            return existing;
        }

        public Task<T> UpdateAsync(T updated, object key)
        {

            _dbContext.Entry(updated).State = EntityState.Modified;
            return Task.FromResult(updated);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void Attach(T entity)
        {
            _dbContext.Set<T>().Attach(entity);
        }

        public int Count(ISpecification<T> spec)
        {
            return ApplySpecification(spec).Count();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }

        public async Task<PagedResult<T,IVM>> GetAllPagedAsync(ISpecification<T> specification, QueryModel query)
        {
            var data = ApplySpecification(specification);
            return new PagedResult<T, IVM>(data,query.CurrentPage,query.PageSize,null);
        }
    }
}
