using Aula2Marcelo.Data;
using Aula2Marcelo.Models;
using Microsoft.EntityFrameworkCore;

//como vai fazer
namespace Aula2Marcelo.Repositories
{
    //class criada para boas práticas
    public class LivroRepository : ILivroRepository
    {

        //variável banco de dados
        private readonly AppDbContext _context;

        public LivroRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Livro>> ListarTodos()
        {
            //retornar todos os livros do banco com o nome da categoria (ao inves do Id)
            return await _context.Livros
                .Include(I => I.Categoria)
                .ToListAsync();
        }

        // Salvar no banco
        public async Task Adicionar(Livro Livro)
        {
            await _context.Livros.AddAsync(Livro);
            await _context.SaveChangesAsync();
        }

    }
}