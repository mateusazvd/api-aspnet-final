using System.ComponentModel.DataAnnotations;

namespace Backend_UniFinal.Models
{
    public class Produto
    {
        [Required(ErrorMessage = "O campo de Generico é Obrigatório")]
        public string Id { get; set; }
        [Required(ErrorMessage = "O nome do produto é Obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "A categoria do produto é Obrigatório")]
        public string Categoria { get; set; }
        public string Generico { get; set;}
    }
}
