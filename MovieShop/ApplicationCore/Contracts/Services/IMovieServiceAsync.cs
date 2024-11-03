using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Services
{
    public interface IMovieServiceAsync
    {
        Task<int> AddMovie(Movie movie);

        Task<int> DeleteMovie(int id);

        Task<IEnumerable<Movie>> GetAllMovie(string sort, int page, int count);

        Task<IEnumerable<Movie>> GetAll();

        Task<Movie> GetMovieById(int id);

        Task<int> UpdateMovie(Movie movie, int id);

        Task<IEnumerable<Movie>> GetMovieDetails(string sort, int page, int count);

        Task<IEnumerable<Movie>> GetMoviesByGenre(int genreId);
    }
}
