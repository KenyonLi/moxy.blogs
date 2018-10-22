﻿using Microsoft.EntityFrameworkCore;
using Moxy.EntityFramework.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Moxy.EntityFramework.Extensions;

namespace Moxy.EntityFramework
{
    public class MoxyDbContext : DbContext
    {
        public DbSet<Article> Article { get; set; }
        public DbSet<ArticleCategory> ArticleCategory { get; set; }
        public DbSet<SysAdmin> SysAdmin { get; set; }
        public DbSet<SysConfig> SysConfig { get; set; }

        public MoxyDbContext(DbContextOptions<MoxyDbContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly, "Moxy.EntityFramework.Mapping");
            modelBuilder.ApplyDeletedFilter();
        }
    }
}
