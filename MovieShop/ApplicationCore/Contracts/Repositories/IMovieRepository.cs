using ApplicationCore.entity;
using ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

using ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieCardModel>> GetTopGrossingMoviesAsync();
        Task<Movie> GetMovieDetailsAsync(int id);
        Task<PaginatedResultSet<MovieCardModel>> GetMoviesByGenreAsync(int genreId, int pageSize = 30, int pageNumber = 1);
    }
}