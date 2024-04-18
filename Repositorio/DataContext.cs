using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Pizzaria> Pizzaria { get; set; }
        public DbSet<Promover> Promover { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizzaria>().HasKey(p => p.Id);
            modelBuilder.Entity<Produto>().HasKey(p => p.Id);
            modelBuilder.Entity<Fornecedor>().HasKey(p => p.Id);
            modelBuilder.Entity<Promover>().HasOne(p => p.Pizzaria).WithMany().HasForeignKey(p => p.CodigoPizzaria);

            base.OnModelCreating(modelBuilder);
        }
    }
}
