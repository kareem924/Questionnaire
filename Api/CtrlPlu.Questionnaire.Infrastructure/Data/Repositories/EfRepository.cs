using CtrlPlu.Questionnaire.Common.Core.Domain;
using CtrlPlu.Questionnaire.Common.Core.Model;
using CtrlPlu.Questionnaire.Common.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CtrlPlu.Questionnaire.Infrastructure.Data.Repositories
{
    public abstract class EfRepository<TEntity> : ISpecificationRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        private readonly QuestionnaireDbContext _dbContext;
        protected DbSet<TEntity> DbSet { get; }

        protected EfRepository(QuestionnaireDbContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }

        public TEntity GetById(object id)
        {
            return DbSet.Find(id);

        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await DbSet.FindAsync(id);
        }

        public TEntity Find(ISpecification<TEntity> spec)
        {
            return ApplySpecification(spec).SingleOrDefault();
        }

        public async Task<TEntity> FindAsync(ISpecification<TEntity> specification)
        {
            return await ApplySpecification(specification).SingleOrDefaultAsync();
        }

        public ICollection<TEntity> FindAll(ISpecification<TEntity> specification)
        {
            return ApplySpecification(specification).ToList();
        }

        public async Task<ICollection<TEntity>> FindAllAsync(ISpecification<TEntity> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        public TEntity Add(TEntity entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            return entity;
        }

        public IEnumerable<TEntity> AddRange(IReadOnlyCollection<TEntity> entityList)
        {
            DbSet.AddRange(entityList);
            return entityList;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IReadOnlyCollection<TEntity> entityList)
        {
            await DbSet.AddRangeAsync(entityList);
            return entityList;
        }

        public TEntity Update(TEntity updated, object key)
        {
            TEntity existing = DbSet.Find(key);
            if (existing != null)
            {
                _dbContext.Entry(existing).CurrentValues.SetValues(updated);
            }
            return existing;
        }

        public Task<TEntity> UpdateAsync(TEntity updated, object key)
        {

            _dbContext.Entry(updated).State = EntityState.Modified;
            return Task.FromResult(updated);
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public void Attach(TEntity entity)
        {
            DbSet.Attach(entity);
        }

        public int Count(ISpecification<TEntity> spec)
        {
            return ApplySpecification(spec).Count();
        }

        public async Task<bool> AnyAsync(ISpecification<TEntity> spec)
        {
            return await ApplySpecification(spec).AnyAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> spec)
        {
            return await DbSet.AsQueryable().AnyAsync(spec);
        }

        public async Task<int> CountAsync(ISpecification<TEntity> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public async Task<TEntity> GetSingleOrDefaultAsync(ISpecification<TEntity> spec)
        {
            return await ApplySpecification(spec).SingleOrDefaultAsync();
        }

        public async Task<TEntity> GetFirstOrDefaultAsync(ISpecification<TEntity> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> spec)
        {
            return SpecificationEvaluator<TEntity>.GetQuery(DbSet.AsQueryable(), spec);
        }

        public Task<PagedResult<TEntity, IVM>> GetAllPagedAsync(
            ISpecification<TEntity> specification,
            QueryModel query,
            Func<TEntity, IVM> func)
        {
            var data = ApplySpecification(specification);
            return Task
                .FromResult(new PagedResult<TEntity, IVM>(data, query.CurrentPage, query.PageSize, null));
        }
    }
}
