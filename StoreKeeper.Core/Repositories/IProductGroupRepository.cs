using System.Threading.Tasks;
using StoreKeeper.Core.Models;

namespace StoreKeeper.Core.Repositories
{
    public interface IProductGroupRepository : IRepository<ProductGroup>
    {
        Task<ProductGroup> GetByCodeAsync(string code);
    }
}
