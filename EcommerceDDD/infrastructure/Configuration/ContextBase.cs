using Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace infrastructure.Configuration
{
    public class ContextBase : IdentityDbContext<IdentityUser>
    {
        public ContextBase(DbContextOptions<ContextBase> options):base(options)
        {

        }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<CompraUsuario> CompraUsuarios { get; set; }
        public DbSet<IdentityUser> IdentityUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetStringConnetionConfig());
                base.OnConfiguring(optionsBuilder);

            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUser>().ToTable("AspNetUsers").HasKey(t => t.Id);
            base.OnModelCreating(builder);
        }

        private string GetStringConnetionConfig()
        {           
            string strCon = "Data Source=DESKTOP-9LK3UQP;Initial Catalog=ECOMMERCE_DDD;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            return strCon;
        }
    }
}
