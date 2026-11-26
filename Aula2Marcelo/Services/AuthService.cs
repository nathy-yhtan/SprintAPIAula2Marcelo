using Aula2Marcelo.DTOs;
using Aula2Marcelo.Models;
using Aula2Marcelo.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Aula2Marcelo.Services
{
    public class AuthService : IAuthService
    {

        private readonly IUsuarioRepository _repository;


        private readonly IConfiguration _configuration;


        private readonly PasswordHasher<Usuario> _passwordHasher = new();


        public AuthService(IUsuarioRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }


        //criptografar senha e salvar
        public async Task Registrar(LoginDTO dto)
        {
            var existente = await _repository.BuscarPorNome(dto.NomeUsuario);

            if (existente != null)
            {
                throw new Exception("Esse nome de usuario ja existe");
            }

            var novoUsuario = new Usuario
            {
                NomeUsuario = dto.NomeUsuario
            };

            novoUsuario.Senha = _passwordHasher.HashPassword(novoUsuario, dto.Senha);

        }


        public async Task<string> Login(LoginDTO dto)
        {

            var usuario = await _repository.BuscarPorNome(dto.NomeUsuario);

            if (usuario == null)
            {
                throw new UnauthorizedAccessException("Usuario ou senha invalidos");
            }

            var resultado = _passwordHasher.VerifyHashedPassword(usuario, usuario.Senha, dto.Senha);

            if (resultado == PasswordVerificationResult.Failed)
            {
                throw new UnauthorizedAccessException("Usuario ou senha invalidos");
            }

            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                   {
                        new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                        new Claim(ClaimTypes.Name, usuario.NomeUsuario)
                    }),

                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key)
                   , SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }


    }
}
