

using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;

    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<MovieDetailsModel> GetMovieDetails(int id)
    {
        var movie = await _movieRepository.GetMovieById(id);

        if (movie == null) return null;

        var movieDetails = new MovieDetailsModel
        {
            Id = movie.Id,
            Title = movie.Title,
            Overview = movie.Overview,
            PosterUrl = movie.PosterUrl,
            ReleaseDate = movie.ReleaseDate,
            Revenue = movie.Revenue,
            Budget = movie.Budget,
            Genres = movie.MovieGenres.Select(mg => new GenreModel
            {
                Id = mg.Genre.Id,
                Name = mg.Genre.Name
            }).ToList(),
            Casts = movie.MovieCasts.Select(mc => new CastModel
            {
                Id = mc.CastId,
                Name = mc.Cast.Name,
                Character = mc.Character,
                ProfilePath = mc.Cast.ProfilePath
            }).ToList(),
            Trailers = movie.Trailers.Select(t => new TrailerModel
            {
                Id = t.Id,
                Name = t.Name,
                TrailerUrl = t.TrailerUrl
            }).ToList()
        };

        return movieDetails;
    }
}
