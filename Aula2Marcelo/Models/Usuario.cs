using System.ComponentModel.DataAnnotations;

namespace Aula2Marcelo.Models
{
    public class Usuario
    {
        public int Id { get; set; }


        [Required]
        public string NomeUsuario { get; set; } = string.Empty;


        [Required]
        public string Senha { get; set; } = string.Empty;
    }
}
