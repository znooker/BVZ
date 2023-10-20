using Microsoft.AspNetCore.Mvc;

namespace BVZ.Controllers
{
    public class AdminTourController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
