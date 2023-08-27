using Microsoft.AspNetCore.Mvc;
using VastikaProject.Models;

namespace VastikaProject.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("SignIn");
            }

            return View();
        }
    }
}