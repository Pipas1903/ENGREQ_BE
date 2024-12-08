using AMAP_FARM.DTO;
using AMAP_FARM.Models;
using AMAP_FARM.Services;
using Microsoft.AspNetCore.Mvc;

namespace AMAP_FARM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        // GET: api/ProductCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> GetProductCategories()
        {
            var productCategories = await _productCategoryService.GetAllProductCategoriesAsync();
            return Ok(productCategories);
        }

        // GET: api/ProductCategory/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategory>> GetProductCategory(int id)
        {
            var productCategory = await _productCategoryService.GetProductCategoryByIdAsync(id);
            if (productCategory == null)
            {
                return NotFound();
            }

            return Ok(productCategory);
        }

        // POST: api/ProductCategory
        [HttpPost]
        public async Task<ActionResult<ProductCategory>> CreateProductCategory(ProductCategoryCreateDto productCategoryCreateDto)
        {
            if (productCategoryCreateDto == null)
            {
                return BadRequest("ProductCategory data is invalid.");
            }

            var createdProductCategory = await _productCategoryService.CreateProductCategoryAsync(productCategoryCreateDto);
            return CreatedAtAction(nameof(GetProductCategory), new { id = createdProductCategory.Id }, createdProductCategory);
        }

        // PUT: api/ProductCategory/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductCategory(int id, ProductCategory productCategory)
        {
            if (id != productCategory.Id)
            {
                return BadRequest("ProductCategory ID mismatch.");
            }

            var success = await _productCategoryService.UpdateProductCategoryAsync(id, productCategory);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/ProductCategory/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductCategory(int id)
        {
            var success = await _productCategoryService.DeleteProductCategoryAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
