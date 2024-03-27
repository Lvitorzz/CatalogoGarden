using Microsoft.EntityFrameworkCore;
using catalogo_produtos.Models;

namespace catalogo_produtos.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<AdminModel> Admins { get; set; }
        public DbSet<MoradorModel> Moradores { get; set; }
        public DbSet<MoradorProdutosModel> MoradoresProdutos { get; set; }
    }
}
