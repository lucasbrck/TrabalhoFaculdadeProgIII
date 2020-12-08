using ControleVendas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleVendas.Data
{
    public class ControleVendasContext:DbContext
    {
        public ControleVendasContext(DbContextOptions<ControleVendasContext> options) : base(options)
        {
            
        }


        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<PedidoModel> Pedidos { get; set; }
        public DbSet<PedidoProduto> PedidoProdutos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PedidoProduto>()
                .HasKey(a => new { a.PedidoModelId, a.ProdutoModelId });
        }

    } 
}
