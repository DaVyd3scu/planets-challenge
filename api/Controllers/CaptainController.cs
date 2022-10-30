using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class CaptainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
