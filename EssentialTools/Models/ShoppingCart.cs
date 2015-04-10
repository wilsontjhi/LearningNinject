using System.Collections.Generic;

namespace EssentialTools.Models
{
    public class ShoppingCart
    {
        private IValueCalculator _Calc;

        public ShoppingCart(IValueCalculator calc)
        {
            _Calc = calc;
        }

        public IEnumerable<Product> Products { get; set; }

        public decimal CalculateProductTotal()
        {
            return _Calc.ValueProducts(Products);
        }
    }
}