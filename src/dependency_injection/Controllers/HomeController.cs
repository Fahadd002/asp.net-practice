using dependency_injection.Interface;
using dependency_injection.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace dependency_injection.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMembership _imembership;

        public HomeController(IMembership imembership)
        {
            _imembership = imembership;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAccount(AccountModel model)
        {
            _imembership.CreateUserAccount(model.Name, model.Email, model.Password);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
