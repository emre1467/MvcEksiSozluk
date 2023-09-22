using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Controllers
{
    public class AuthorizationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
