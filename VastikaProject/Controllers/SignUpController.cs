using Microsoft.AspNetCore.Mvc;
using VastikaProject.Models;

namespace Vastika_Project.Controllers
{
    public class SignUpController : Controller
    {
        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAccount(SignUpModel signUpModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(CreateAccount));
            }

            return View();
        }
    }

}