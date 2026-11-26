using Aula2Marcelo.DTOs;
using Aula2Marcelo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Aula2Marcelo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;


        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] LoginDTO dto)
        {
            try
            {
                await _authService.Registrar(dto);
                return Ok(new { mensagem = "Usuario cadastrado com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            try
            {
                var token = await _authService.Login(dto);
                return Ok(new { token, usuario = dto.NomeUsuario });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { erro = ex.Message });
            }
        }

    }
}