using FactoryPatternAndMethod.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternAndMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create order
            var cart = new ShoppingCart();
            var shippingLabel = cart.Finalize();
            Console.WriteLine(shippingLabel) ;
            Console.ReadLine();
        }
    }
}
