using System.ComponentModel.DataAnnotations;

namespace Aula2Marcelo.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string Usuario { get; set; } = string.Empty;

        [Required]
        public string Senha { get; set; } = string.Empty;
    }
}
