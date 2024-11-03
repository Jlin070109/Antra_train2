using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Services
{
    public interface IGenreServiceAsync
    {
        Task<int> AddGenre(Genre genre);
        Task<int> UpdateGenre(Genre genre, int id);
        Task<int> DeleteGenre(int id);
        Task<IEnumerable<Genre>> GetAllGenre();
        Task<Genre> GetGenreById(int id);
    }
}
