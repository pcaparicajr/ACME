using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ACME.Models;

namespace ACME.API.Database
{
    public class ACMEContext : DbContext
    {
        public ACMEContext(DbContextOptions<ACMEContext> options) : base(options)
        {

        }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ACME;Integrated Security=True;");
        }*/

        public DbSet<Pedido>? Pedidos { get; set; }
        public DbSet<Produto>? Produtos { get; set; }
        public DbSet<ItensPedido>? ItensPedidos { get; set; }
     
        //Mocando alguns dados
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().HasData(
                new Produto { Id = 1, NomeProduto = "Martelo", Valor = 10 },
                new Produto { Id = 2, NomeProduto = "Serrote", Valor = 20 },
                new Produto { Id = 3, NomeProduto = "Prego", Valor = 3 }
            );
            modelBuilder.Entity<Pedido>().HasData(
                new Pedido { Id = 1, NomeCliente = "Maria", EmailCliente = "Maria@gmail.com", Pago = true, DataCriacao = DateTime.Today },
                new Pedido { Id = 2, NomeCliente = "Jose", EmailCliente = "Josegmail.com", Pago = true, DataCriacao = DateTime.Today }
            );
            modelBuilder.Entity<ItensPedido>().HasData(
                new ItensPedido { Id = 1, IdPedido = 1, IdProduto = 1, Quantidade = 5 },
                new ItensPedido { Id = 2, IdPedido = 1, IdProduto = 2, Quantidade = 7 },
                new ItensPedido { Id = 3, IdPedido = 2, IdProduto = 2, Quantidade = 2 },
                new ItensPedido { Id = 4, IdPedido = 2, IdProduto = 3, Quantidade = 4 }
            );


            modelBuilder.Entity<Pedido>()
                .HasMany(a => a.Produtos)
                .WithMany(a => a.Pedidos)
                .UsingEntity<ItensPedido>(
                    q => q.HasOne(a => a.Produto)
                );
        }
    }
}
