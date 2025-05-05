using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication4.Contexts;
using WebApplication4.Models.Concretes;

namespace WebApplication4.Areas.Admin.Controllers;


[Area("Admin")]
public class CategoryController : Controller
{

    AppDbContext _context;

    public CategoryController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _context.Categories.ToListAsync();

        return View(categories);
    }


    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Category category)
    {

        await _context.AddAsync(category);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        var c = await _context.Categories.FindAsync(id);


        _context.Categories.Remove(c!);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    public IActionResult Update(int id)
    {
        var c = _context.Categories.FirstOrDefault(x => x.Id == id);

        return View(c);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Update(Category category)
    {

         _context.Update(category);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }
}
