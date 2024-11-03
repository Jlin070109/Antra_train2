using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public class CastRepositoryAsync : BaseRepositoryAsync<Cast>, ICastRepositoryAsync
    {
        private readonly MovieShopAppDbContext _context;
        public CastRepositoryAsync(MovieShopAppDbContext c) : base(c)
        {
            _context = c;
        }

        public async Task<IEnumerable<Cast>> GetCastsWithMovie()
        {
            return await _context.Casts.Include(x => x.MovieCasts).
                ThenInclude(mc => mc.Movie).ToListAsync();
        }

        public async Task<Cast> GetById(int Id)
        {
            return await _context.Casts.Include(x => x.MovieCasts).
                ThenInclude(mc => mc.Movie).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<IEnumerable<Cast>> GetAllCast(int page, int count)
        {
            return await _context.Casts.Skip((page - 1) * count).Take(count).ToListAsync();
        }
    }
}
