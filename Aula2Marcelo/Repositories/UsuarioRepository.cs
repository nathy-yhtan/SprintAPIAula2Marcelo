
using Aula2Marcelo.Data;
using Aula2Marcelo.Models;
using Microsoft.EntityFrameworkCore;

namespace Aula2Marcelo.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;


        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<Usuario?> BuscarPorNome(string nomeUsuario)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.NomeUsuario == nomeUsuario);
        }


        public async Task Adicionar(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

    }
}