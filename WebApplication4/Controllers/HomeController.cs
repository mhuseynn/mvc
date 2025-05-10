using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Contexts;
using WebApplication4.Models.Concretes;

namespace WebApplication4.Controllers;

[Authorize]
public class HomeController : Controller
{

     AppDbContext _context { get; set; }

   

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        List<Product> products = await _context.Products.ToListAsync();
        
        ViewBag.Sliders=await _context.Sliders.ToListAsync();

        return View(products);
    }
}
