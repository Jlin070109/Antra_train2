using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public class PurchaseRepositoryAsync : BaseRepositoryAsync<Purchase>, IPurchaseRepositoryAsync
    {
        public PurchaseRepositoryAsync(MovieShopAppDbContext c) : base(c)
        {
        }
    }
}
