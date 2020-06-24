using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CtrlPlu.Questionnaire.Common.Core.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CtrlPlu.Questionnaire.Infrastructure.Data
{
    public class QuestionnaireDbContext : DbContext, ICtrlPlusDbContext
    {
        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public EntityEntry Entry<TEntity>(object entity) where TEntity : class
        {
            throw new NotImplementedException();
        }
    }
}
