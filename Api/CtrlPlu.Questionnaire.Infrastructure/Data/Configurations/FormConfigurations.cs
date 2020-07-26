using System;
using CtrlPlu.Questionnaire.Core.Form.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CtrlPlu.Questionnaire.Infrastructure.Data.Configurations
{
    public class FormConfigurations : IEntityTypeConfiguration<Form>
    {
        public void Configure(EntityTypeBuilder<Form> builder)
        {
            builder.HasMany(form => form.Sections)
                .WithOne()
                .IsRequired()
                .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
