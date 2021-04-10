using System.Threading.Tasks;
using StoreKeeper.Core.Repositories;
using StoreKeeper.Data.Repositories;

namespace StoreKeeper.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreKeeperDbContext _context;
        private ProductGroupRepository _productGroupRepository;
        private SubGroupRepository _subGroupRepository;
        public UnitOfWork(StoreKeeperDbContext context)
        {
            this._context = context;
        }
        public IProductGroupRepository ProductGroups => _productGroupRepository = _productGroupRepository ?? new ProductGroupRepository(_context);
        public ISubGroupRepository SubGroups => _subGroupRepository = _subGroupRepository ?? new SubGroupRepository(_context);
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
