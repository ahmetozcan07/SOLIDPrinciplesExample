using SOLIDPrinciples.Interfaces;
using SOLIDPrinciples.Services;

namespace SOLIDPrinciples.Factories
{
    public class DiscountFactory
    {
        //Factory Pattern
        public IDiscountStrategy Create(string discountType, int discountAmount)
        {
            switch (discountType?.ToLower())
            {
                case "percentage":
                    return new PercentageDiscount(discountAmount);

                case "fixed":
                    return new FixedDiscount(discountAmount);

                default:
                    return new NoDiscount();
            }
        }
    }
}
