using Microsoft.AspNetCore.Mvc;

namespace BVZ.Controllers
{
    public class AdminAnimalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
