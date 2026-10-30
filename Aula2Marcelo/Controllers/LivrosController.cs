using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aula2Marcelo.Controllers
{
    [Route("api/[controller]")] //api/livros
    [ApiController]
    public class LivrosController : ControllerBase
    {


        [HttpGet]
        public IActionResult GetLivros()
        {
            var livrosFalsos = new List<string>
            {
                "O senhor dos anéis",
                "Verity",
                "Memórias do subsolo",
                "O manifesto comunista"
            };

            return Ok(livrosFalsos);
        }


        //TEM QUE COLOCAR UM NOVO NOME
        [HttpGet("boasvindas")]
        public IActionResult GetBoasVindas()
        {
            string boasVindas = "Bem-vindo ao sistema!";

            return Ok(boasVindas);
        }


    }
}