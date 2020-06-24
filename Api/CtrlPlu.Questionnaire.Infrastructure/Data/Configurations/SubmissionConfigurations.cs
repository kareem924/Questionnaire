using CtrlPlu.Questionnaire.Core.Form.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CtrlPlu.Questionnaire.Infrastructure.Data.Configurations
{
    public class SubmissionConfigurations : IEntityTypeConfiguration<Submission>
    {
        public void Configure(EntityTypeBuilder<Submission> builder)
        {
            builder.HasMany(form => form.MultiValues)
                .WithOne()
                .IsRequired()
                .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
