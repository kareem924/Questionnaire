using System;
using CtrlPlu.Questionnaire.Core.Form.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CtrlPlu.Questionnaire.Infrastructure.Data.Configurations
{
    public class SectionConfigurations : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.Property(form => form.Description).HasMaxLength(Int32.MaxValue);
            builder.Property(form => form.Title).IsRequired();
            builder.HasMany(form => form.Fields)
                .WithOne()
                .IsRequired()
                .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
