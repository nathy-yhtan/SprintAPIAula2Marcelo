using Aula2Marcelo.Models;

//o que vai fazer
namespace Aula2Marcelo.Repositories
{
    //parar de usar B.D. falso
    public interface ILivroRepository
    {

        //task é operação assingrona, roda em segundo plano

        //devolver lista de objetos do tipo livro
        Task<IEnumerable<Livro>> ListarTodos();

        //regra pra criar novos registros
        Task Adicionar(Livro livro);

        Task<Livro?> Buscar(int id);

        Task Atualizar(Livro livro);

        Task Remover(Livro livro);

    }
}