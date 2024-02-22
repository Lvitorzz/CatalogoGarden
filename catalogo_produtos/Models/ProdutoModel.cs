using catalogo_produtos.Enums;
using System.ComponentModel.DataAnnotations;

namespace catalogo_produtos.Models
{
    public class ProdutoModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Link { get; set; }
        public string UrlImagem { get; set; }
        public bool Ativo { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public CategoriaEnum Categoria { get; set; }
        public DateTime DataDeCriacao { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime DataDeAlteracao { get; set; } = DateTime.Now.ToLocalTime();
    }
}
