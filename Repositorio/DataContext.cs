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
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Associar> Associar { get; set; }
        public DbSet<Vender> Vender { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().HasKey(p => p.Id);
            modelBuilder.Entity<Fornecedor>().HasKey(p => p.Id);

            modelBuilder.Entity<Associar>().HasOne(p => p.Produto).WithMany().HasForeignKey(p => p.IdProduto);
            modelBuilder.Entity<Associar>().HasOne(p => p.Fornecedor).WithMany().HasForeignKey(p => p.IdFornecedor);

            modelBuilder.Entity<Vender>().HasKey(p => p.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
