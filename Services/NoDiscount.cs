using SOLIDPrinciples.Interfaces;

namespace SOLIDPrinciples.Services
{
    public class NoDiscount : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal price) => price;
    }
}
