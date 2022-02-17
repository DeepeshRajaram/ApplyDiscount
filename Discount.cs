/*
 * Here, all the discounts are defined which calculate the discount in its CalculateDiscount method
 * All classes are implementing IOffer, based on this I am picking them up during processing
 */

namespace ApplyDiscount
{
    //public class BuyTwoGetOne : IOffer
    //{
    //    public double CalculateDiscount(double cartTotal)
    //    {
    //        return (cartTotal * 1 / 2);
    //    }
    //}

    public class BuyThreeGetOne : IOffer
    {
        public double CalculateDiscount(double cartTotal)
        {
            return cartTotal * 1 / 3;
        }
    }

    public class Flat40Off : IOffer
    {
        public double CalculateDiscount(double cartTotal)
        {
            return cartTotal * 0.40;
        }
    }

    public class Flat30Plus20Off : IOffer
    {
        public double CalculateDiscount(double cartTotal)
        {
            double val = cartTotal - (cartTotal * 0.30);
            return (cartTotal * 0.30) + val * 0.20;
        }
    }
}
