using AMAP_FARM.DTO;
using AMAP_FARM.Models;
using AMAP_FARM.Services;
using Microsoft.AspNetCore.Mvc;

namespace AMAP_FARM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService _productTypeService;

        public ProductTypeController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        // GET: api/ProductType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductType>>> GetProductTypes()
        {
            var productTypes = await _productTypeService.GetAllProductTypesAsync();
            return Ok(productTypes);
        }

        // GET: api/ProductType/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductType>> GetProductType(int id)
        {
            var productType = await _productTypeService.GetProductTypeByIdAsync(id);
            if (productType == null)
            {
                return NotFound();
            }

            return Ok(productType);
        }

        // POST: api/ProductType
        [HttpPost]
        public async Task<ActionResult<ProductType>> CreateProductType(ProductTypeCreateDto productTypeCreateDto)
        {
            if (productTypeCreateDto == null)
            {
                return BadRequest("ProductType data is invalid.");
            }

            var createdProductType = await _productTypeService.CreateProductTypeAsync(productTypeCreateDto);
            return CreatedAtAction(nameof(GetProductType), new { id = createdProductType.Id }, createdProductType);
        }

        // PUT: api/ProductType/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductType(int id, ProductType productType)
        {
            if (id != productType.Id)
            {
                return BadRequest("ProductType ID mismatch.");
            }

            var success = await _productTypeService.UpdateProductTypeAsync(id, productType);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/ProductType/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductType(int id)
        {
            var success = await _productTypeService.DeleteProductTypeAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
