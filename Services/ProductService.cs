using SOLIDPrinciples.Interfaces;
using SOLIDPrinciples.Models;

namespace SOLIDPrinciples.Services
{
    public class ProductService : IReadableProductService, IWritableProductService
    {
        private readonly List<Product> _products = new();
        private readonly IDiscountStrategy _discountStrategy;

        public ProductService(IDiscountStrategy discountStrategy)
        {
            _discountStrategy = discountStrategy;
        }

        public IEnumerable<Product> GetAll()
        {
            return _products.Select(p => new Product
            {
                Id = p.Id,
                Name = p.Name,
                Price = _discountStrategy.ApplyDiscount(p.Price)
            });
        }

        public Product? GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
                _products.Remove(product);
        }
    }
}
