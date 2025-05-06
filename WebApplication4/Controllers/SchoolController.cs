using Microsoft.AspNetCore.Mvc;
using WebApplication4.Contexts;

namespace WebApplication4.Controllers;

public class SchoolController : Controller
{

    AppDbContext _context { get; set; }



    public SchoolController(AppDbContext context)
    {
        _context = context;
    }





    public IActionResult Index()
    {
        var tImages = _context.TeachersImages.ToList();
        return View(tImages);
    }
}
