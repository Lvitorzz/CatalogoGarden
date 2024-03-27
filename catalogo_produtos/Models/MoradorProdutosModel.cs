using System.ComponentModel.DataAnnotations;

namespace catalogo_produtos.Models
{
    public class MoradorProdutosModel
    {
        [Key]
        public int Id { get; set; }
        public int MoradorId { get; set; }
        public int ProdutoId { get; set; }
    }
}
