using Aula2Marcelo.Models;
using Microsoft.EntityFrameworkCore;

namespace Aula2Marcelo.Data
{

    public class AppDbContext : DbContext
    {

        // construtor para receber as configurações do banco de dados
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //informa ao EF p/ criar uma tabela chamada "Livros" baseada na classe Livro
        public DbSet<Livro> Livros { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

    }

}