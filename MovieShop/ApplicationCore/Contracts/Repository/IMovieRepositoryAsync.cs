using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Contracts.Repository
{
    public interface IMovieRepositoryAsync: IRepositoryAsync<Movie>
    {
        Task<Movie> GetHighestGrossingMovies();

        Task<Movie> GetMoviebyId(int movieId);

        Task<IEnumerable<Movie>> GetMovieDetails(string sort, int page, int count);

        Task<IEnumerable<Movie>> GetMostRecentMovies(int number = 20);

        Task<IEnumerable<Movie>> GetAllMovie(string sort, int page, int count);

        Task<IEnumerable<Movie>> GetMoviesByGenre(int genreId);
    }
}
