using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreKeeper.Core.Models;
using StoreKeeper.Core.Repositories;

namespace StoreKeeper.Data.Repositories
{
    public class SubGroupRepository : Repository<SubGroup>, ISubGroupRepository 
    {
        public SubGroupRepository(StoreKeeperDbContext context)
            : base(context) { } 
        public async Task<IEnumerable<SubGroup>> GetAllWithProductGroupByProductGroupIDAsync(int productGroupID)
        {
            return await StoreKeeperDbContext.SubGroups
                .Include(m => m.ProductGroup)
                .Where(m => m.ProductGroupID == productGroupID)
                .ToListAsync();
        }
        public async Task<IEnumerable<SubGroup>> GetAllWithProductGroupAsync()
        {
            return await StoreKeeperDbContext.SubGroups
                .Include(m => m.ProductGroup)
                .ToListAsync();
        }
        private StoreKeeperDbContext StoreKeeperDbContext
        {
            get { return Context as StoreKeeperDbContext; }
        }
    }
}
