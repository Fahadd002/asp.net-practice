using dependency_injection.Interface;
using Microsoft.AspNetCore.Mvc;

namespace dependency_injection.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMembership _membership;

        public AccountController([FromKeyedServices("ScopedMembership1")] IMembership membership)
        {
            _membership = membership;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
