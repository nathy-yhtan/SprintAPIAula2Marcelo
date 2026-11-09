using Aula2Marcelo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aula2Marcelo.Controllers
{
    [Route("api/[controller]")] //api/livros
    [ApiController]
    public class LivrosController : ControllerBase
    {

        //variável de acesso ao banco
        private readonly ILivroRepository _repository;

        //injeção de dependencia
        public LivrosController (ILivroRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _repository.ListarTodos());

        //TEM QUE COLOCAR UM NOVO NOME
        [HttpGet("boasvindas")]
        public IActionResult GetBoasVindas()
        {
            string boasVindas = "Bem-vindo ao sistema!";

            return Ok(boasVindas);
        }


    }
}