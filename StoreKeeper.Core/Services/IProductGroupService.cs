using System.Collections.Generic;
using System.Threading.Tasks;
using StoreKeeper.Core.DTOs;

namespace StoreKeeper.Core.Services
{
    public interface IProductGroupService
    {
        Task<ProductGroupDTO> CreateProductGroup(ProductGroupSaveDTO newProductGroup);
        Task<ProductGroupDTO> GetProductGroupByID(int id);
        Task<ProductGroupDTO> GetProductGroupByCode(string code);
        Task<IEnumerable<ProductGroupDTO>> GetAll();
        Task UpdateProductGroup(ProductGroupDTO productGroupToBeUpdated);
        Task DeleteProductGroup(ProductGroupDTO productGroup);
    }
}
