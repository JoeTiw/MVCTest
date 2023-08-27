using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VastikaProject.Models;
namespace VastikaProject.Controllers;

public class ProductsController : Controller
{
    
    private readonly DbDataContext _context;

    public ProductsController(DbDataContext context)
    {
        _context = context;
    }
    
    // GET: Products
    public async Task<IActionResult> Index()
    {
        // return _context.Customers != null ? 
        //             View(await _context.Customers.ToListAsync()) :
        //             Problem("Entity set 'VastikaProjectContext.Customers'  is null.");

        try
        {
            var productsList = _context.Products.ToList();
            return View(productsList);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    
    // GET: Customers/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.Products == null)
        {
            return NotFound();
        }

        var products = await _context.Products
            .FirstOrDefaultAsync(m => m.Id == id);
        if (products == null)
        {
            return NotFound();
        }

        return View(products);
    }
    
    //------------------------CREATE-----------------------------------
    
    // GET: Customers/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Customers/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,ProductId,ProductName,ProductDescription,ProductPrice")] Products products)
    {
        if (ModelState.IsValid)
        {
            _context.Add(products);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(products);
    }
    
    //--------------------UPDATE-------------------------------------
    
    // GET: Customers/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.Products == null)
        {
            return NotFound();
        }

        var products = await _context.Products.FindAsync(id);
        if (products == null)
        {
            return NotFound();
        }
        return View(products);
    }
    // POST: Customers/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,ProductName,ProductDescription,ProductPrice")] Products products)
    {
        if (id != products.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(products);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(products.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(products);
    }
    
    // GET: Customers/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Products == null)
        {
            return NotFound();
        }

        var products = await _context.Products
            .FirstOrDefaultAsync(m => m.Id == id);
        if (products == null)
        {
            return NotFound();
        }

        return View(products);
    }

    // POST: Customers/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Products == null)
        {
            return Problem("Entity set 'VastikaProjectContext.Customers'  is null.");
        }
        var products = await _context.Customers.FindAsync(id);
        if (products != null)
        {
            _context.Customers.Remove(products);
        }
            
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ProductsExists(int id)
    {
        return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}


