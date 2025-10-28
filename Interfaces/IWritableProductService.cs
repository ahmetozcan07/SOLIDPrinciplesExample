using SOLIDPrinciples.Models;

namespace SOLIDPrinciples.Interfaces
{
    public interface IWritableProductService
    {
        void Add(Product product);
        void Delete(int id);
    }
}
