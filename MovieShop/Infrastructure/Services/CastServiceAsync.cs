using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class CastServiceAsync: ICastServiceAsync
    {
        private ICastRepositoryAsync _repository;
        public CastServiceAsync(ICastRepositoryAsync repo)
        {
            _repository = repo;
        }

        public Task<int> AddCast(Cast cast)
        {
            return _repository.Insert(cast);
        }

        public Task<int> DeleteCast(int id)
        {
            return _repository.Delete(id);
        }

        public async Task<IEnumerable<Cast>> GetAllCast(int page, int count)
        {
            return await _repository.GetAllCast(page, count);
        }

        public async Task<Cast> GetCastById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<int> UpdateCast(Cast cast, int id)
        {
            if (cast.Id == id)
            {
                return await _repository.Update(cast);
            }
            return 0;
        }
        public async Task<IEnumerable<Cast>> GetCastsWithMovie()
        {
            return await _repository.GetCastsWithMovie();
        }
    }
}
