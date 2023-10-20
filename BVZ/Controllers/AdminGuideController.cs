using Microsoft.AspNetCore.Mvc;

namespace BVZ.Controllers
{
    public class AdminGuideController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
