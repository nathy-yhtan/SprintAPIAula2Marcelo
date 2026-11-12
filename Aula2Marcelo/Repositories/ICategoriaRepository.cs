using Aula2Marcelo.Models;

namespace Aula2Marcelo.Repositories
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> ListarTodos();
        Task Adicionar(Categoria categoria);
    }
}
