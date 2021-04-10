using System.Collections.Generic;
using System.Threading.Tasks;
using StoreKeeper.Core.Models;

namespace StoreKeeper.Core.Repositories
{
    public interface ISubGroupRepository : IRepository<SubGroup>
    {
        Task<IEnumerable<SubGroup>> GetAllWithProductGroupByProductGroupIDAsync(int productGroupID);
        Task<IEnumerable<SubGroup>> GetAllWithProductGroupAsync();
    }
}
