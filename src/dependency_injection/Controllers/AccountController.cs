using Microsoft.AspNetCore.Mvc;

namespace dependency_injection.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
