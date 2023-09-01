using Microsoft.AspNetCore.Mvc;
using VastikaProject.BusinessAccessLayer.Interfaces;
using VastikaProject.BusinessAccessLayer.Services;
using VastikaProject.Entities;
using VastikaProject.Models;

namespace VastikaProject.Controllers;

public class CustomerController : Controller
{

    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    // GET
    public IActionResult Index()
    {
        var customerList = _customerService.GetCustomerList();
        List<CustomersModel> list = new List<CustomersModel>();
        foreach (var customer in customerList)
        {
            list.Add(new CustomersModel()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName

            });

        }
        return View(list);
    }
    

    
    [HttpPost]
    public IActionResult Create(CustomersModel model)
    {
        model.Id = 12;
        if (ModelState.IsValid)
        {
            var customer = new Customer()
            {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName
               
            };
            var result=  _customerService.AddCustomer(customer);
            if (result)
                return RedirectToAction("Index");
   
        }

        return View();
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    public IActionResult Update()
    {
        return View();
    }
}