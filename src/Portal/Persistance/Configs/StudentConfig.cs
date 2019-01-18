using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.Entities;
using System;

namespace Portal.Persistance.Configs
{
    class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(p => p.GivenName).HasMaxLength(20).IsRequired();
            builder.Property(p => p.SureName).HasMaxLength(20).IsRequired();
            builder.Property(p => p.Age).IsRequired();

            builder.HasKey(s => new { s.ClassId, s.SureName });
        }
    }
}
