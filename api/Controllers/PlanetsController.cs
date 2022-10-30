using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class PlanetsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
