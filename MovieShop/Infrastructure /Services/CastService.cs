using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRepository;

        public CastService(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }

        public async Task<CastDetailsModel> GetCastDetails(int id)
        {
            var cast = await _castRepository.GetById(id);

            if (cast == null) return null;

            var castDetails = new CastDetailsModel
            {
                Id = cast.Id,
                Name = cast.Name,
                Gender = cast.Gender,
                TmdbUrl = cast.TmdbUrl,
                ProfilePath = cast.ProfilePath,
                Movies = cast.MovieCasts.Select(mc => new MovieCardModel
                {
                    Id = mc.Movie.Id,
                    Title = mc.Movie.Title,
                    PosterUrl = mc.Movie.PosterUrl
                }).ToList()
            };

            return castDetails;
        }
    }
}