using SOLIDPrinciples.Interfaces;

namespace SOLIDPrinciples.Services
{
    public class PercentageDiscount : IDiscountStrategy
    {
        private readonly decimal _percent;

        public PercentageDiscount(decimal percent)
        {
            _percent = percent;
        }

        public decimal ApplyDiscount(decimal price)
        {
            return price - (price * _percent / 100);
        }
    }
}
