using Microsoft.AspNetCore.Mvc;
using SOLIDPrinciples.Interfaces;
using SOLIDPrinciples.Models;

namespace SOLIDPrinciples.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IReadableProductService _readService;
        private readonly IWritableProductService _writeService;

        public ProductController(IReadableProductService readService, IWritableProductService writeService)
        {
            _readService = readService;
            _writeService = writeService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_readService.GetAll());

        [HttpPost]
        public IActionResult Add(Product product)
        {
            _writeService.Add(product);
            return Ok("Product added.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _writeService.Delete(id);
            return Ok("Product deleted.");
        }
    }
}
