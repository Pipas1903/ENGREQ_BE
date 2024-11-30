using AMAP_FARM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    // GET
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        return Ok(await _context.Products.ToListAsync());
    }

    // POST
    [HttpPost]
    public async Task<IActionResult> CreateProduct(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, product);
    }

}
