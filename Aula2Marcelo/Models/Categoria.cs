using System.ComponentModel.DataAnnotations;

namespace Aula2Marcelo.Models
{
    public class Categoria
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Nome { get; set; }

    }
}