using Microsoft.AspNetCore.Mvc;
using ProductAPI.Data;
using ProductAPI.Models;

[ApiController]
[Route("productAPI")]
public class ProductAPIController : ControllerBase
{
    private readonly ProductDbContext _context;

    public ProductAPIController(ProductDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        return Ok(_context.Products.ToList());
    }
}
