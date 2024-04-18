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
        public DbSet<Associar> Associar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizzaria>().HasKey(p => p.Id);
            modelBuilder.Entity<Promover>().HasOne(p => p.Pizzaria).WithMany().HasForeignKey(p => p.CodigoPizzaria);

            modelBuilder.Entity<Produto>().HasKey(p => p.Id);
            modelBuilder.Entity<Fornecedor>().HasKey(p => p.Id);

            modelBuilder.Entity<Associar>().HasKey(p => p.Id);
            //modelBuilder.Entity<Associar>().HasOne(p => p.Produto).WithMany().HasForeignKey(p => p.IdProduto);
            //modelBuilder.Entity<Associar>().HasOne(p => p.Fornecedor).WithMany().HasForeignKey(p => p.IdFornecedor);

            base.OnModelCreating(modelBuilder);
        }
    }
}
