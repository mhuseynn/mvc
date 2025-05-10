using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Contexts;
using WebApplication4.Models.Concretes;

namespace WebApplication4.Areas.Admin.Controllers;
[Area("Admin")]
public class SliderController : Controller
{

    AppDbContext _context;

    public SliderController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _context.Sliders.ToListAsync();

        return View(categories);
    }


    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Slider slider)
    {

        var safeFileName = Path.GetFileName(slider.File.FileName);


        var filePath = Path.Combine("C:\\Users\\I Novbe\\Desktop\\mvc\\WebApplication4\\wwwroot\\images", safeFileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            slider.File.CopyTo(stream);
        }


        slider.ImgUrl = safeFileName;

        await _context.AddAsync(slider);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        var c = await _context.Sliders.FindAsync(id);


        _context.Sliders.Remove(c!);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }
    public IActionResult Update(int id)
    {
        var c = _context.Sliders.FirstOrDefault(x => x.Id == id);

        return View(c);
    }


    [HttpPost]
    public async Task<IActionResult> Update(Slider slider)
    {

        _context.Update(slider);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

}
