using System.ComponentModel.DataAnnotations;

namespace Aula2Marcelo.DTOs
{
 
    public class CategoriaDTO
    {

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O nome deve ter entre 5 e 100 caracteres.")]
        public string Nome { get; set; }
    
    }

}