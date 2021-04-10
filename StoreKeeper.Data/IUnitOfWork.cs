using System;
using System.Threading.Tasks;
using StoreKeeper.Core.Repositories;

namespace StoreKeeper.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IProductGroupRepository ProductGroups { get; }
        ISubGroupRepository SubGroups { get; }
        Task<int> CommitAsync();
    }
}
