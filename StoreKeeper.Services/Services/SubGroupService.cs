using System.Collections.Generic;
using System.Threading.Tasks;
using StoreKeeper.Core.Models;
using StoreKeeper.Services.DTOs;
using StoreKeeper.Data;

namespace StoreKeeper.Services
{
    public class SubGroupService : BaseService, ISubGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SubGroupService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<SubGroupDTO> CreateSubGroup(SubGroupSaveDTO newSubGroup)
        {
            SubGroup subGroup = base._mapper.Map<SubGroupSaveDTO, SubGroup>(newSubGroup);
            _unitOfWork.SubGroups.Add(subGroup);
            await _unitOfWork.CommitAsync();
            var createdSubGroup = await _unitOfWork.SubGroups.SingleOrDefaultAsync(x => x.Code == newSubGroup.Code && x.Name == newSubGroup.Name);
            return base._mapper.Map<SubGroup, SubGroupDTO>(createdSubGroup);
        }
        public async Task<SubGroupDTO> GetSubGroupByID(int subGroupID)
        {
            var subGroup = await _unitOfWork.SubGroups.GetByIDAsync(subGroupID); 
            return _mapper.Map<SubGroup, SubGroupDTO>(subGroup);
        }
        public async Task<IEnumerable<SubGroupDTO>> GetSubGroupsByProductGroup(int productGroupID)
        {
            var subGroups = await _unitOfWork.SubGroups.GetAllWithProductGroupByProductGroupIDAsync(productGroupID);
            return _mapper.Map<IEnumerable<SubGroup>, IEnumerable<SubGroupDTO>>(subGroups); 
        }
        public async Task<IEnumerable<SubGroupDTO>> GetAllWithProductGroup()
        {
            var subGroups = await _unitOfWork.SubGroups.GetAllWithProductGroupAsync();
            return _mapper.Map<IEnumerable<SubGroup>, IEnumerable<SubGroupDTO>>(subGroups); 
        }
        public async Task UpdateSubGroup(SubGroupDTO subGroupToBeUpdated, SubGroupDTO subGroup)
        {
            subGroupToBeUpdated.Code = subGroup.Code;
            subGroupToBeUpdated.Name = subGroup.Name;

            await _unitOfWork.CommitAsync();
        }
        public async Task DeleteSubGroup(SubGroupDTO subGroup)
        {
            var subG = _mapper.Map<SubGroupDTO, SubGroup>(subGroup);
            _unitOfWork.SubGroups.Remove(subG);
            await _unitOfWork.CommitAsync();
        }
    }
}
