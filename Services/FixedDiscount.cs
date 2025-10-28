using SOLIDPrinciples.Interfaces;

namespace SOLIDPrinciples.Services
{
    public class FixedDiscount : IDiscountStrategy
    {
        private readonly decimal _amount;

        public FixedDiscount(decimal amount)
        {
            _amount = amount;
        }

        public decimal ApplyDiscount(decimal price)
        {
            return price - _amount;
        }
    }
}
