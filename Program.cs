using System;
using System.Collections.Generic;

namespace ApplyDiscount
{
    class Program
    {
        static void Main(string[] args)
        {
            //Created Shirt objects
            Shirt P1 = new Shirt { ShirtCode = "P1", Price = 100 };
            Shirt P2 = new Shirt { ShirtCode = "P2", Price = 300 };
            Shirt P3 = new Shirt { ShirtCode = "P3", Price = 200 };

            //Added orders in the cart
            List<Order> cart = new List<Order>() {
                new Order { Shirt=P1, Quantity=2 },
                new Order { Shirt=P3, Quantity=4 },
            };

            
            Cart objCart = new Cart();
            //calling cart method to process orders and apply discount
            double discount = objCart.ProcessCart(cart);

            //gets cart value for display
            double cartValue = objCart.CalculateCartValue(cart);

            //formatting output
            Console.WriteLine(string.Format("|{0,10}|{1,10}|{2,10}|{3,10}|","Shirt Code","Price","Quantity", "Total"));
            
            foreach (Order order in cart)
            {
                Console.WriteLine(string.Format("|{0,-10}|{1,10}|{2,10}|{3,10}|"
                                    , order.Shirt.ShirtCode, order.Shirt.Price, order.Quantity, order.Shirt.Price * order.Quantity));
                
            }
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine(string.Format("Cart Value before Discount: {0} | Discount Amount: {1} | Final Cart Value: {2}"
                                , cartValue, Math.Round(discount,2), Math.Round(cartValue - discount,2)));
            
            Console.ReadLine();
        }
    }
}
