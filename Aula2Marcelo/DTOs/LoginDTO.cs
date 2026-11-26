using System.ComponentModel.DataAnnotations;

namespace Aula2Marcelo.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string NomeUsuario { get; set; } = string.Empty;

        [Required]
        public string Senha { get; set; } = string.Empty;
    }
}
