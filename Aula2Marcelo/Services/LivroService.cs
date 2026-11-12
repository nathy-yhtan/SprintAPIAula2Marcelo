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

    }

}