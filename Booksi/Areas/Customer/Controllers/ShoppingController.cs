using Microsoft.AspNetCore.Mvc;

namespace Booksi.Areas.Customer.Controllers
{
    public class ShoppingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
