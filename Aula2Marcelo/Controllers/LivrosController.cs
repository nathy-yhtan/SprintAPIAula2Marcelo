using Aula2Marcelo.DTOs;
using Aula2Marcelo.Repositories;
using Aula2Marcelo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aula2Marcelo.Controllers
{

    [Route("api/[controller]")] //api/livros
    [ApiController]
    public class LivrosController : ControllerBase
    {

        //variável de acesso ao banco
        private readonly ILivroService _service;

        //injeção de dependencia
        public LivrosController(ILivroService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.ListarTodos());


        [HttpPost]
        public async Task<IActionResult> Post(LivroDTO livroDto)
        {

            try
            {
                await _service.Criar(livroDto);
                return Ok("Livro cadastrado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Erro 400
            }

        }

    }

}