using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    public class GenreServiceAsync : IGenreServiceAsync
    {
        private IGenreRepositoryAsync _repository;
        public GenreServiceAsync(IGenreRepositoryAsync repo)
        {
            _repository = repo;
        }

        public async Task<int> AddGenre(Genre genre)
        {
            return await _repository.Insert(genre);
        }

        public async Task<int> DeleteGenre(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<IEnumerable<Genre>> GetAllGenre()
        {
            return await _repository.GetAll();
        }

        public async Task<Genre> GetGenreById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<int> UpdateGenre(Genre genre, int id)
        {
            if (genre.Id == id)
            {
                return await _repository.Update(genre);
            }
            return 0;
        }
    }
}
