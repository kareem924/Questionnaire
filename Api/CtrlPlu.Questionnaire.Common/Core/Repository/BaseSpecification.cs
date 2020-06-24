using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CtrlPlu.Questionnaire.Common.Core.Model;

namespace CtrlPlu.Questionnaire.Common.Core.Repository
{
    public abstract class BaseSpecification<T> : ISpecification<T>
    {

        protected BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criterias.Add(criteria);
        }

        protected BaseSpecification()
        {
        }

        public List<Expression<Func<T, bool>>> Criterias { get; } = new List<Expression<Func<T, bool>>>();

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();


        public IReadOnlyCollection<Expression<Func<T, bool>>> GetPredicates() => Criterias.AsReadOnly();

        public List<string> IncludeStrings { get; } = new List<string>();


        public Expression<Func<T, object>> OrderBy { get; private set; }


        public Expression<Func<T, object>> OrderByDescending { get; private set; }


        public Expression<Func<T, object>> GroupBy { get; private set; }


        public QueryModel Paging { get; private set; }

        public bool IsPagingEnabled { get; private set; } = false;

        protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected virtual void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }

        protected virtual void ApplyPaging(QueryModel paging)
        {
            Paging = paging;
            IsPagingEnabled = true;
        }

        protected virtual void ApplyOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected virtual void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
        }

        protected virtual void ApplyGroupBy(Expression<Func<T, object>> groupByExpression)
        {
            GroupBy = groupByExpression;
        }

        public ISpecification<T> Where(Expression<Func<T, bool>> criteria)
        {
            Criterias.Add(criteria);
            return this;
        }
    }
}
