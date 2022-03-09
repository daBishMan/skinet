using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductsController : ControllerBase
  {
    private readonly IProductRepository _repository;
    public ProductsController(IProductRepository repository)
    {
      _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
      var products = await _repository.GetProductsAsync();
      return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
      return await _repository.GetProductByIdAsync(id);
    }
  }
}
