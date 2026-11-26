using Aula2Marcelo.Models;

namespace Aula2Marcelo.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> BuscarPorNome(string nomeUsuario);

        Task Adicionar(Usuario usuario);
    }
}
