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

//-----------------------------------CREATE-----------------------------------------------
    [HttpPost]
    public IActionResult Create(CustomersModel model)
    {

        if (ModelState.IsValid)
        {
            var customer = new Customer()
            {

                FirstName = model.FirstName,
                LastName = model.LastName

            };
            var result = _customerService.AddCustomer(customer);
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

    //----------------------------------UPDATE----------------------------------------------------
    
    [HttpGet]
    public IActionResult Update(int? id)  // Make the id parameter nullable
    {
        if (!id.HasValue)
        {
            return NotFound("Customer ID is required.");
        }

        var customer = _customerService.GetCustomerById(id.Value);

        var model = new CustomersModel
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName
        };

        return View(model);
    }
    
    [HttpPost]
    public IActionResult Update(CustomersModel model)
    {
        if (ModelState.IsValid)
        {
            // Ensure that an Id is provided
            if (!model.Id.HasValue)
            {
                ModelState.AddModelError("", "Customer ID is required for updating.");
                return View(model);
            }

            // Retrieve the existing customer from the database
            var customerToUpdate = _customerService.GetCustomerById(model.Id.Value);

            // Update the properties of the retrieved customer
            customerToUpdate.FirstName = model.FirstName;
            customerToUpdate.LastName = model.LastName;

            var result = _customerService.UpdateCustomer(customerToUpdate);

            if (result)
            {
                
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Error updating the customer. Please try again.");
            }
        }

        // If there's an issue or model state is invalid, return to the same view with the model
        return View(model);
    }


    public IActionResult Update()
    {
        return View();

    }

    //--------------------------------------Delete------------------------------------
    public IActionResult Delete(int? id)
    {
        var result = _customerService.DeleteCustomer(id.Value);
        return RedirectToAction("Index");
    }
    
    
}