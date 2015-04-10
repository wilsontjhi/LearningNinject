
namespace EssentialTools.Models
{
    public class DefaultDiscountHelper : IDiscountHelper
    {
        private readonly decimal _DiscountSize;

        public DefaultDiscountHelper(decimal discountSize)
        {
            _DiscountSize = discountSize;
        }

        public decimal ApplyDiscount(decimal total)
        {
            return total - (_DiscountSize / 100m * total);
        }
    }
}