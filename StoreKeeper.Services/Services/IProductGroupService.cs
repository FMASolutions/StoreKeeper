using System.Collections.Generic;
using System.Threading.Tasks;
using StoreKeeper.Services.DTOs;

namespace StoreKeeper.Services
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
