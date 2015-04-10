using System.Web.Mvc;
using EssentialTools.Models;

namespace EssentialTools.Controllers
{
    public class HomeController : Controller
    {
        private readonly IValueCalculator _Calc;
        private readonly Product[] _Products;

        public HomeController(IValueCalculator calc, IValueCalculator uselessCalc)
        {
            _Calc = calc;
            _Products = new Product[]
            {
                new Product { Name = "Kayak", Category = "Water-sports", Price = 275M },
                new Product { Name = "Lifejacket", Category = "Water-sports", Price = 48.95M },
                new Product { Name = "Soccer ball", Category = "Soccer", Price = 19.50M },
                new Product { Name = "Corner flag", Category = "Soccer", Price = 34.95M },
            };
        }

        public ActionResult Index()
        {
            ShoppingCart cart = new ShoppingCart(_Calc) { Products = _Products };
            decimal totalValue = cart.CalculateProductTotal();

            return View(totalValue);
        }
    }
}