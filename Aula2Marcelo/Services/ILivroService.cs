using Aula2Marcelo.DTOs;
using Aula2Marcelo.Models;

namespace Aula2Marcelo.Services
{
    public interface ILivroService
    {
        Task<IEnumerable<Livro>> ListarTodos();

        Task Criar(LivroDTO livroDTO);

        Task Atualizar(int id, LivroDTO livroDTO);

        Task Remover(int id);
    }
}
