namespace SOLIDPrinciples.Interfaces
{
    public interface IDiscountStrategy
    {
        decimal ApplyDiscount(decimal price);
    }
}
