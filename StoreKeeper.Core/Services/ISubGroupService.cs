using System.Collections.Generic;
using System.Threading.Tasks;
using StoreKeeper.Core.DTOs;

namespace StoreKeeper.Core.Services
{
    public interface ISubGroupService
    {
        Task<SubGroupDTO> GetSubGroupByID(int id);
        Task<IEnumerable<SubGroupDTO>> GetSubGroupsByProductGroup(int productGroupID);
        Task<IEnumerable<SubGroupDTO>> GetAllWithProductGroup();
        Task<SubGroupDTO> CreateSubGroup(SubGroupSaveDTO newSubGroup);
        Task UpdateSubGroup(SubGroupDTO subGroupToBeUpdated, SubGroupDTO subGroup);
        Task DeleteSubGroup(SubGroupDTO subGroup);
    }
}
