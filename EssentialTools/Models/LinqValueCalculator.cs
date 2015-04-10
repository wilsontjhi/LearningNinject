using System.Collections.Generic;
using System.Linq;

namespace EssentialTools.Models
{
    public class LinqValueCalculator : IValueCalculator
    {
        private readonly IDiscountHelper _Discounter;

        public LinqValueCalculator(IDiscountHelper discounter)
        {
            _Discounter = discounter;
        }

        public decimal ValueProducts(IEnumerable<Product> products)
        {
            var totalPrice = products.Sum(p => p.Price);
            return _Discounter.ApplyDiscount(totalPrice);
        }
    }
}