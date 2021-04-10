using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreKeeper.Core.Models;
using StoreKeeper.Core.Repositories;

namespace StoreKeeper.Data.Repositories
{
    public class ProductGroupRepository : Repository<ProductGroup>, IProductGroupRepository 
    {
        public ProductGroupRepository(StoreKeeperDbContext context)
            : base(context)
        { } 

        public async Task<ProductGroup> GetByCodeAsync(string code)
        {
            return await StoreKeeperDbContext.ProductGroups
                .SingleOrDefaultAsync(m => m.Code == code);
        }

        private StoreKeeperDbContext StoreKeeperDbContext
        {
            get { return Context as StoreKeeperDbContext; }
        }
    }
}
