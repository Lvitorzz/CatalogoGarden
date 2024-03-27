using System.ComponentModel.DataAnnotations;

namespace catalogo_produtos.Models
{
    public class MoradorModel
    {
        [Key]
        public int Id { get; set; }
        public string NomeMorador { get; set; }
        public string Endereco { get; set; }
        public int NumeroApartamento { get; set; }
        public string NumeroWhatsApp { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataDeCriacao { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime DataDeAlteracao { get; set; } = DateTime.Now.ToLocalTime();
    }
}
