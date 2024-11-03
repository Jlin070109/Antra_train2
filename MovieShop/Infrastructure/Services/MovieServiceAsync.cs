using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    public class MovieServiceAsync: IMovieServiceAsync
    {
        private IMovieRepositoryAsync _repository;
        public MovieServiceAsync(IMovieRepositoryAsync repo)
        {
            _repository = repo;
        }

        public async Task<int> AddMovie(Movie movie)
        {
            return await _repository.Insert(movie);
        }

        public async Task<int> DeleteMovie(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<IEnumerable<Movie>> GetAllMovie(string sort, int page, int count)
        {
            return await _repository.GetAllMovie(sort, page, count);
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Movie> GetMovieById(int id)
        {
            return await _repository.GetMoviebyId(id);
        }

        public async Task<int> UpdateMovie(Movie movie, int id)
        {
            if (movie.Id == id)
            {
                return await _repository.Update(movie);
            }
            return 0;
        }

        public async Task<IEnumerable<Movie>> GetMovieDetails(string sort, int page, int count)
        {
            return await _repository.GetMovieDetails(sort, page, count);
        }

        public async Task<IEnumerable<Movie>> GetMoviesByGenre(int genreId)
        {
            var res = await _repository.GetMoviesByGenre(genreId);
            return res;

        }
    }
}
