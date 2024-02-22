using System.ComponentModel.DataAnnotations;

namespace catalogo_produtos.Models
{
    public class AdminModel
    {
        [Key]
        public int Id { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set;}

    }
}
