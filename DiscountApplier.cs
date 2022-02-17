using System.Collections.Generic;
using System.Linq;

namespace ApplyDiscount
{
    /// <summary>
    /// Discount Applier get the offers and calls the Calculate Discount method of all the Discount classes 
    /// which are implementing IOffer interface
    /// </summary>
    public class DiscountApplier
    {
        private readonly IEnumerable<IOffer> offers;
        public DiscountApplier(IEnumerable<IOffer> discount)
        {
            offers = discount;
        }

        /// <summary>
        /// Returns the max discount applied to cart
        /// </summary>
        /// <param name="cartTotal"></param>
        /// <returns></returns>
        public double CalculateCartDiscount(double cartTotal)
        {
            List<double> cartDiscount = new List<double>();
            foreach (IOffer offer in offers)
            {
                cartDiscount.Add(offer.CalculateDiscount(cartTotal));
            }

            cartDiscount.Sort();
            return cartDiscount.LastOrDefault();
        }
    }
}
