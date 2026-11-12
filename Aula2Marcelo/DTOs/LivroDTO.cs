using System.ComponentModel.DataAnnotations;

namespace Aula2Marcelo.DTOs
{

    public class LivroDTO
    {

        [Required(ErrorMessage ="O título é obrigatório")]
        [StringLength(100, MinimumLength =3, ErrorMessage ="O título deve ter entre 3 e 100 caracteres.")]
        public string Titulo { get; set; } = string.Empty; //"isso pode dar valor nulo e msm assim n afetaria negativamente"


        [Required(ErrorMessage = "O nome do autor é obrigatório")]
        public string Autor { get; set; } = string.Empty;


        [Range(1500, 2026, ErrorMessage ="Ano de publicação inválido")]
        public int AnoPublicacao { get; set; }


        [Required(ErrorMessage ="Informe a categoria desse livro.")]
        public int CategoriaId { get; set; }
    }

}