using Microsoft.AspNetCore.Mvc;
using MobileApp.Models;

namespace MobileApp.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Staff staff)
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
