﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portal.Domain.Entities;
using Portal.Persistance.Configs;

namespace Portal.Persistance
{
    public class PortalDbContext : DbContext
    {
        public PortalDbContext()
        {

        }

        public PortalDbContext(DbContextOptions<PortalDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ClassConfig());
            builder.ApplyConfiguration(new StudentConfig());
        }

        public DbSet<Class> Class { get; set; }
        public DbSet<Student> Student { get; set; }

    }
}
