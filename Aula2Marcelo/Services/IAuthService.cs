using Aula2Marcelo.DTOs;

namespace Aula2Marcelo.Services
{
    public interface IAuthService
    {
        Task Registrar(LoginDTO dto);


        Task<string> Login(LoginDTO dto);
    }
}