
using Microsoft.AspNetCore.Mvc;

namespace FactoryMethod.Controllers
{
    public class ProductDetailController : Controller
    {
        public IActionResult Index(decimal total)
        {
            //factories
            Earn.LocalEarnFactory localEarnFactory = new Earn.LocalEarnFactory(0.20m);

            // products
            var localEarn = localEarnFactory.GetEarn();

            // total
            ViewBag.totalLocal = (total + localEarn.Earn(total));


            return View();
        }
    }
}
