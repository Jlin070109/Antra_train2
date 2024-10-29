using ApplicationCore.Contracts.Repositories;
using ApplicationCore.entity;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Movie>> GetHighestGrossingMoviesAsync()
        {
            return await _dbContext.Movies
                .OrderByDescending(m => m.Revenue)
                .Take(30)
                .ToListAsync();
        }

        public override async Task<Movie> GetByIdAsync(int id)
        {
            return await _dbContext.Movies
                .Include(m => m.MovieGenres).ThenInclude(mg => mg.Genre)
                .Include(m => m.Trailers)
                .Include(m => m.MovieCasts).ThenInclude(mc => mc.Cast)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<PaginatedResultSet<Movie>> GetMoviesByGenreAsync(int genreId, int pageSize = 30, int pageNumber = 1)
        {
            var totalMovies = await _dbContext.MovieGenres.Where(mg => mg.GenreId == genreId).CountAsync();
            var movies = await _dbContext.MovieGenres
                .Where(mg => mg.GenreId == genreId)
                .Include(mg => mg.Movie).ThenInclude(m => m.MovieGenres)
                .OrderByDescending(mg => mg.Movie.Revenue)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(mg => mg.Movie)
                .ToListAsync();

            return new PaginatedResultSet<Movie>(movies, pageNumber, pageSize, totalMovies);
        }
    }
}