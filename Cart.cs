using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplyDiscount
{
    class Cart
    {
        /// <summary>
        /// Method gets all the offers in project and calls the CalculateCartDiscount, which returns applied discount amount
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public double ProcessCart(List<Order> cart)
        {
            double cartTotal = CalculateCartValue(cart);
            
            Type ruleType = typeof(IOffer);
            IEnumerable<IOffer> offers = GetType().Assembly.GetTypes()
                                            .Where(p => ruleType.IsAssignableFrom(p) && !p.IsInterface)
                                            .Select(r => Activator.CreateInstance(r) as IOffer);

            DiscountApplier discountedCart = new DiscountApplier(offers);
            return discountedCart.CalculateCartDiscount(cartTotal);
        }

        /// <summary>
        /// Method calculates Cart Total amount
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public double CalculateCartValue(List<Order> cart)
        {
            double cartTotal = 0;
            foreach (Order order in cart)
            {
                cartTotal += (order.Shirt.Price * order.Quantity);
            }

            return cartTotal;
        }
    }
}
