using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repository
{
    public interface ICastRepositoryAsync : IRepositoryAsync<Cast>
    {
        Task<IEnumerable<Cast>> GetCastsWithMovie();

        Task<IEnumerable<Cast>> GetAllCast(int page, int count);
    }
}
