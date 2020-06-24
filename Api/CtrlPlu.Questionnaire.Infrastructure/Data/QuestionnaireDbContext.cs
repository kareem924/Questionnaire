using System;
using System.Threading;
using System.Threading.Tasks;
using CtrlPlu.Questionnaire.Common.Core.DBContext;
using CtrlPlu.Questionnaire.Common.Core.Domain;
using CtrlPlu.Questionnaire.Common.Core.Model;
using CtrlPlu.Questionnaire.Common.Core.UnitOFWork;
using CtrlPlu.Questionnaire.Common.Helpers;
using CtrlPlu.Questionnaire.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CtrlPlu.Questionnaire.Infrastructure.Data
{
    public class QuestionnaireDbContext : DbContext, ICtrlPlusDbContext, IUnitOfWork
    {
        public QuestionnaireDbContext(DbContextOptions<QuestionnaireDbContext> options) : base(options) { }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public SaveResult SaveResult { get; }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await base.SaveChangesAsync(cancellationToken);
            return true;
        }

        public void AddError(int code, string error)
        {
            throw new NotImplementedException();
        }

        public void AddError(Error error)
        {
            throw new NotImplementedException();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=CtrlPlusQuestionnaire;Integrated Security=true;Connect Timeout=90;Encrypt=False;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var type in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(type.ClrType))
                    modelBuilder.SetSoftDeleteFilter(type.ClrType);
            }
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new FormConfigurations());
            modelBuilder.ApplyConfiguration(new SubmissionConfigurations());
            modelBuilder.ApplyConfiguration(new FieldConfigurations());
            modelBuilder.ApplyConfiguration(new SectionConfigurations());
        }

        //public void SetGlobalQuery<T>(ModelBuilder builder) where T : AuditableEntity
        //{
        //    builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        //}
    }
}
