//biblioteca p/ restrições de integridade dos atributos da tabelo
using System.ComponentModel.DataAnnotations;


namespace Aula2Marcelo.Models
{
    public class Livro
    {

        //escrever "Id" já o identifica como PRIMARY KEY
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Titulo { get; set; }

        [Required]
        [MaxLength(100)]
        public string Autor { get; set; }

        public int AnoPublicacao { get; set; }

    }
}
