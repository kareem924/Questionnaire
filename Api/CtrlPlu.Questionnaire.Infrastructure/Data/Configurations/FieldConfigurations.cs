using CtrlPlu.Questionnaire.Core.Form.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CtrlPlu.Questionnaire.Infrastructure.Data.Configurations
{
   public class FieldConfigurations : IEntityTypeConfiguration<Field>
    {
        public void Configure(EntityTypeBuilder<Field> builder)
        {
            builder.Property(field => field.IsRequired).HasDefaultValue(false);
            builder.Property(field => field.Type).IsRequired();
            builder.Property(field => field.Label).IsRequired();
            builder.HasMany(form => form.Submission)
                .WithOne()
                .IsRequired()
                .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.HasMany(form => form.Options)
                .WithOne()
                .IsRequired()
                .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
