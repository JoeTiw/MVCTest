using Microsoft.AspNetCore.Mvc;

namespace VastikaProject.Controllers;

public class OrderItemController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}