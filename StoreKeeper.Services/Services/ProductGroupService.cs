using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreKeeper.Core.Models;
using StoreKeeper.Services.DTOs;
using StoreKeeper.Services.Validators;
using StoreKeeper.Data;

namespace StoreKeeper.Services
{
    public class ProductGroupService : BaseService, IProductGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductGroupService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<ProductGroupDTO> CreateProductGroup(ProductGroupSaveDTO newProductGroup)
        {
            var validator = new ProductGroupSaveDTOValidator();
            var validationResult = await validator.ValidateAsync(newProductGroup);

            if(!validationResult.IsValid)
            {
                string errors = "";
                foreach(var error in validationResult.Errors)                
                    errors += error.ErrorMessage + Environment.NewLine;                
                throw new ArgumentException(errors);
            }
            ProductGroup productGroup = base._mapper.Map<ProductGroupSaveDTO, ProductGroup>(newProductGroup);
            _unitOfWork.ProductGroups.Add(productGroup);
            await _unitOfWork.CommitAsync();
            var createdProdGroup = await _unitOfWork.ProductGroups.GetByCodeAsync(newProductGroup.Code);
            return base._mapper.Map<ProductGroup, ProductGroupDTO>(createdProdGroup);
        }
        public async Task<ProductGroupDTO> GetProductGroupByID(int productGroupID)
        {
            var productGroup = await _unitOfWork.ProductGroups.GetByIDAsync(productGroupID);
            return base._mapper.Map<ProductGroup, ProductGroupDTO>(productGroup);
        }
        public async Task<ProductGroupDTO> GetProductGroupByCode(string code)
        {
            var productGroup = await _unitOfWork.ProductGroups.GetByCodeAsync(code);
            return base._mapper.Map<ProductGroup, ProductGroupDTO>(productGroup);
        }
        public async Task<IEnumerable<ProductGroupDTO>> GetAll()
        {
            var productGroups = await _unitOfWork.ProductGroups.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductGroup>, IEnumerable<ProductGroupDTO>>(productGroups);
        }
        public async Task UpdateProductGroup(ProductGroupDTO productGroupToBeUpdated)
        {
            var validator = new ProductGroupDTOUpdateValidator();
            var validationResult = await validator.ValidateAsync(productGroupToBeUpdated);

            if(!validationResult.IsValid)
                return; //TODO ERROR.....
            var currentProductGroup = await _unitOfWork.ProductGroups.GetByIDAsync(productGroupToBeUpdated.ID);

            currentProductGroup.Code = productGroupToBeUpdated.Code;
            currentProductGroup.Name = productGroupToBeUpdated.Name;
            currentProductGroup.Description = productGroupToBeUpdated.Description;
            
            await _unitOfWork.CommitAsync();
        }
        public async Task DeleteProductGroup(ProductGroupDTO productGroup)
        {
            ProductGroup prodG = _mapper.Map<ProductGroupDTO, ProductGroup>(productGroup);
            _unitOfWork.ProductGroups.Remove(prodG);
            await _unitOfWork.CommitAsync();
        }

    }
}
