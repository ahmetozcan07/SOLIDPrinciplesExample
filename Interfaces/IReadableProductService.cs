using SOLIDPrinciples.Models;

namespace SOLIDPrinciples.Interfaces
{
    public interface IReadableProductService
    {
        IEnumerable<Product> GetAll();
        Product? GetById(int id);
    }
}
