using ApplicationCore.Contracts.Repositories;
using ApplicationCore.entity;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CastRepository : Repository<Cast>, ICastRepository
    {
        public CastRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Cast> GetById(int id)
        {
            return await _dbContext.Casts
                .Include(c => c.MovieCasts).ThenInclude(mc => mc.Movie)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}