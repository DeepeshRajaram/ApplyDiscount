namespace ApplyDiscount
{
    /// <summary>
    /// Interface to enforce CalculateDiscount should be implemented
    /// </summary>
    public interface IOffer
    {
        double CalculateDiscount(double cartTotal);
    }
}
