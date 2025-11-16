using Microsoft.AspNetCore.Mvc;
using SOLIDPrinciples.Factories;
using SOLIDPrinciples.Interfaces;
using SOLIDPrinciples.Models;

namespace SOLIDPrinciples.Controllers
{
    public enum DiscountType
    {
        Percentage,
        Fixed,
        NoDiscount
    }

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IReadableProductService _readService;
        private readonly IWritableProductService _writeService;
        private readonly DiscountFactory _discountFactory;

        public ProductController(IReadableProductService readService, IWritableProductService writeService, DiscountFactory discountFactory)
        {
            _readService = readService;
            _writeService = writeService;
            _discountFactory = discountFactory;
        }

        [HttpGet("{discountType}")]
        public IActionResult GetAll(DiscountType discountType, int discountAmount)
        {
            var discount = _discountFactory.Create(discountType.ToString(), discountAmount);

            var products = _readService
                .GetAll()
                .Select(p =>
                {
                    p.Price = discount.ApplyDiscount(p.Price);
                    return p;
                });

            return Ok(products);
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
