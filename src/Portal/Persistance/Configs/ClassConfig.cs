using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Persistance.Configs
{
    class ClassConfig : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(20).IsRequired();
            builder.Property(p => p.Teacher).HasMaxLength(30).IsRequired();
            builder.Property(p => p.Location).HasMaxLength(50).IsRequired();
            builder.HasMany(p => p.Students);

        }
    }
}
