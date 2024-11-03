using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Repository
{
    public class MovieRepositoryAsync: BaseRepositoryAsync<Movie>, IMovieRepositoryAsync
    {
        private readonly MovieShopAppDbContext _context;
        
        public MovieRepositoryAsync(MovieShopAppDbContext c) : base(c)
        {
            _context = c;
        }

        public async Task<Movie> GetHighestGrossingMovies()
        {
            var revenue = await _context.Movies.MaxAsync(x => x.Revenue);
            return _context.Movies.FirstOrDefault(x => x.Revenue == revenue);
        }

        public async Task<Movie> GetMoviebyId(int movieId)
        {
            return await _context.Movies.
                Include(x => x.MovieGenres).ThenInclude(mg => mg.Genre).
                Include(x => x.MovieCasts).ThenInclude(mc => mc.Cast).
                Include(x => x.Trailers).FirstOrDefaultAsync(x => x.Id == movieId);
        }


        public async Task<IEnumerable<Movie>> GetMovieDetails(string sort, int page, int count)
        {
            if(sort == "Id")
            {
                return await _context.Movies.
                    Include(x => x.MovieGenres).ThenInclude(mg => mg.Genre).
                    Include(x => x.MovieCasts).ThenInclude(mc => mc.Cast).
                    Include(x => x.Trailers).OrderBy(x=> x.Id).
                    Skip((page-1)*count).Take(count).ToListAsync();
            }
            else
            {                
                return await _context.Movies.
                    Include(x => x.MovieGenres).ThenInclude(mg => mg.Genre).
                    Include(x => x.MovieCasts).ThenInclude(mc => mc.Cast).
                    Include(x => x.Trailers).OrderByDescending(x => x.ReleaseDate).
                    Skip((page - 1) * count).Take(count).ToListAsync();
            }
        }

        public async Task<IEnumerable<Movie>> GetAllMovie(string sort, int page, int count)
        {
            if (sort == "Id")
            {
                return await _context.Movies.OrderBy(x => x.Id).
                    Skip((page - 1) * count).Take(count).ToListAsync();
            }
            else
            {
                return await _context.Movies.OrderByDescending(x => x.ReleaseDate).
                    Skip((page - 1) * count).Take(count).ToListAsync();
            }
        }

        public async Task<IEnumerable<Movie>> GetMostRecentMovies(int number = 20)
        {
            return await _context.Movies.OrderByDescending(x => x.ReleaseDate).Take(number).ToListAsync(); ;
        }

        public async Task<IEnumerable<Movie>> GetMoviesByGenre(int genreId)
        {
            var genre = await _context.Genres.
                Include(x => x.MovieGenres).ThenInclude(mg => mg.Movie).
                FirstOrDefaultAsync(x => x.Id == genreId);
            List<Movie> res = new();
            foreach (MovieGenre movieGenre in genre.MovieGenres)
            {
                res.Add(movieGenre.Movie);
            }
            return res;
        }

    }


}
