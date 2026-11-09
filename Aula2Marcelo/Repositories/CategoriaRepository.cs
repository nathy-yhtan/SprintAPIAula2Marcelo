using Aula2Marcelo.Data;
using Aula2Marcelo.Models;
using Microsoft.EntityFrameworkCore;

namespace Aula2Marcelo.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> ListarTodos()
        {
            //retornar todos os livros do banco com o nome da categoria (ao inves do Id)
            return await _context.Categorias
                .ToListAsync();
        }

        // Salvar no banco
        public async Task Adicionar(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }
    }
}