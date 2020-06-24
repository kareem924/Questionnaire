using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CtrlPlu.Questionnaire.Common.Core.Model;

namespace CtrlPlu.Questionnaire.Common.Core.Repository
{
    public interface ISpecification<T>
    {
        List<Expression<Func<T, bool>>> Criterias { get; }

        List<Expression<Func<T, object>>> Includes { get; }

        List<string> IncludeStrings { get; }

        Expression<Func<T, object>> OrderBy { get; }

        Expression<Func<T, object>> OrderByDescending { get; }

        Expression<Func<T, object>> GroupBy { get; }

        QueryModel Paging { get; }

        bool IsPagingEnabled { get; }
    }
}
