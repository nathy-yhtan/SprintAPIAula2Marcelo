using Aula2Marcelo.DTOs;
using Aula2Marcelo.Repositories;
using Aula2Marcelo.Services;
using Microsoft.AspNetCore.Authorization;
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


        [Authorize]
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


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, LivroDTO livroDTO)
        {
            try
            {
                await _service.Atualizar(id, livroDTO);
                return Ok(new { mensagem = "Livro atualizado com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.Remover(id);
                return Ok(new { mensagem = "Livro deletado com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }

}