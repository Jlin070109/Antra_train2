using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Services
{
    public interface ICastServiceAsync
    {
        Task<int> AddCast(Cast cast);

        Task<int> DeleteCast(int id);

        Task<IEnumerable<Cast>> GetAllCast(int page, int count);
        Task<Cast> GetCastById(int id);

        Task<int> UpdateCast(Cast cast, int id);

        Task<IEnumerable<Cast>> GetCastsWithMovie();
    }
}
