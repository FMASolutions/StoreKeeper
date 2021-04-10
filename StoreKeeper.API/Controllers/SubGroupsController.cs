using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreKeeper.Core.Services;
using StoreKeeper.Core.DTOs;

namespace StoreKeeper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubGroupController : ControllerBase
    {
        private readonly ISubGroupService _subGroupService;
        public SubGroupController(ISubGroupService subGroupService)
        {
            this._subGroupService = subGroupService;
        }
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<SubGroupDTO>>> GetAllSubGroups()
        {
            return Ok( await _subGroupService.GetAllWithProductGroup());
        }
    }
}
