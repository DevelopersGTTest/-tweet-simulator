
using Microsoft.AspNetCore.Mvc;

namespace FactoryMethod.Controllers
{
    public class ProductDetailController : Controller
    {
        public IActionResult Index(decimal total)
        {
            //factories
            Earn.LocalEarnFactory localEarnFactory = new Earn.LocalEarnFactory(0.20m);
            Earn.ForeignEarnFactory foreignEarnFactory = new Earn.ForeignEarnFactory(0.30m, 15);



            // products
            var localEarn = localEarnFactory.GetEarn();
            var foreignEarn = foreignEarnFactory.GetEarn();

            // total
            ViewBag.totalLocal = (total + localEarn.Earn(total));
            ViewBag.totalForeign = total + (foreignEarn.Earn(total));

            return View();
        }
    }
}
