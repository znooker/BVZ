using Microsoft.AspNetCore.Mvc;

namespace BVZ.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
