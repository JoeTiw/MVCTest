using Microsoft.AspNetCore.Mvc;

namespace VastikaProject.Controllers;

public class CustomerController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}