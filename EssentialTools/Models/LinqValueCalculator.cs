using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EssentialTools.Models
{
    public class LinqValueCalculator : IValueCalculator
    {
        private static int _Counter = 0;
        private readonly IDiscountHelper _Discounter;

        public LinqValueCalculator(IDiscountHelper discounter)
        {
            _Discounter = discounter;

            Debug.WriteLine("Instance " + ++_Counter + " created");
        }

        public decimal ValueProducts(IEnumerable<Product> products)
        {
            var totalPrice = products.Sum(p => p.Price);
            return _Discounter.ApplyDiscount(totalPrice);
        }
    }
}