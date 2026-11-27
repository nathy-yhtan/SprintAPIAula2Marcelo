using Aula2Marcelo.DTOs;
using Aula2Marcelo.Models;
using Aula2Marcelo.Repositories;

namespace Aula2Marcelo.Services
{

    public class LivroService : ILivroService
    {

        private readonly ILivroRepository _repository;


        public LivroService(ILivroRepository repository)
        {
            _repository = repository;
        }


        public async Task<IEnumerable<Livro>> ListarTodos() =>
            await _repository.ListarTodos();


        public async Task Criar(LivroDTO livroDTO)
        {
            if (livroDTO.AnoPublicacao > DateTime.Now.Year)
                throw new Exception("Não é possivel cadastrar livrosdo futuro");

            var livro = new Livro
            {
                Titulo = livroDTO.Titulo,
                Autor = livroDTO.Autor,
                AnoPublicacao = livroDTO.AnoPublicacao,
                CategoriaId = livroDTO.CategoriaId
            };

            await _repository.Adicionar(livro);
        }


        public async Task Atualizar(int id, LivroDTO livroDTO)
        {
            var livro = await _repository.Buscar(id);

            if (livro == null)
            {
                throw new Exception("Livro não encontrado");
            }

            livro.Titulo = livroDTO.Titulo;
            livro.Autor = livroDTO.Autor;
            livro.AnoPublicacao = livroDTO.AnoPublicacao;
            livro.CategoriaId = livroDTO.CategoriaId;

            await _repository.Atualizar(livro);
        }


        public async Task Remover(int id)
        {
            var livro = await _repository.Buscar(id);

            if (livro == null)
            {
                throw new Exception("Livro não encontrado");
            }

            await _repository.Remover(livro);
        }

    }

}