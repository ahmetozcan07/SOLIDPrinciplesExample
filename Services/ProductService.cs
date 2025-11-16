using SOLIDPrinciples.Interfaces;
using SOLIDPrinciples.Models;

namespace SOLIDPrinciples.Services
{
    public class ProductService : IReadableProductService, IWritableProductService
    {
        public List<Product> _products = new();
        private IDiscountStrategy _discountStrategy;

        public ProductService(IDiscountStrategy discountStrategy)
        {
            _discountStrategy = discountStrategy;
        }

        public void SetDiscountStrategy(IDiscountStrategy discountStrategy)
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
            if (_products.Any(p => p.Id == product.Id))
                throw new Exception($"Product with ID {product.Id} already exists!");
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
