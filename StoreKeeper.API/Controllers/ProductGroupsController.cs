using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreKeeper.Core.Services;
using StoreKeeper.Core.DTOs;

namespace StoreKeeper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductGroupsController : ControllerBase
    {
        private readonly IProductGroupService _productGroupService;
        public ProductGroupsController(IProductGroupService productGroupService)
        {
            this._productGroupService = productGroupService;
        }
        [HttpPost("")]
        public async Task<ActionResult<ProductGroupDTO>> CreateProductGroup([FromBody] ProductGroupSaveDTO prodGroupToCreate)
        {
            try
            {
                var returnResult = await _productGroupService.CreateProductGroup(prodGroupToCreate);
                return returnResult != null ? Ok(returnResult) : BadRequest(prodGroupToCreate);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ProductGroupDTO>>> GetAllProductGroups()
        {
            return Ok( await _productGroupService.GetAll());
        }
        [HttpGet("ById")]
        public async Task<ActionResult<ProductGroupDTO>> GetProductGroupByID(int id)
        {
            return Ok( await _productGroupService.GetProductGroupByID(id) );   
        }
        [HttpPut("")]
        public async Task<ActionResult> UpdateProductGroup(ProductGroupDTO newProductGroup)
        {
            await _productGroupService.UpdateProductGroup(newProductGroup);
            return Ok();
        }
        [HttpDelete("")]
        public async Task<ActionResult> DeleteProductGroup(ProductGroupDTO productGroup)
        {
            try
            {
                await _productGroupService.DeleteProductGroup(productGroup);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
