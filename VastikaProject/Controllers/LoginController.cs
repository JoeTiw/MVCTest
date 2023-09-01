using Microsoft.AspNetCore.Mvc;
using VastikaProject.BusinessAccessLayer.Interfaces;
using VastikaProject.Models;

namespace VastikaProject.Controllers
{
    public class LoginController : Controller
    {
        private ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var isValid = _loginService.Login(loginModel.LoginUsername, loginModel.LoginPassword);
                if (isValid)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }

        public IActionResult SignOut()
        {
            return RedirectToAction("SignIn");
        }
    }
}