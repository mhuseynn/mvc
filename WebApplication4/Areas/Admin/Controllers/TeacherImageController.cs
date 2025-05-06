using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Contexts;
using WebApplication4.Models.Concretes;

namespace WebApplication4.Areas.Admin.Controllers;
[Area("Admin")]
public class TeacherImageController : Controller
{
    AppDbContext _context;

    public TeacherImageController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _context.TeachersImages.ToListAsync();

        return View(categories);
    }


    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(TeacherImage slider)
    {

        if (!slider.formFile.ContentType.Contains("image"))
        {
            return View();
        }

        var safeFileName = Path.GetFileName(slider.formFile.FileName);

        
        string fileName;

        if (safeFileName.Length>100)
        {
            fileName = Guid.NewGuid().ToString() + safeFileName.Substring(safeFileName.Length - 64);
        }
        else
        {
            fileName = Guid.NewGuid().ToString() + safeFileName;
        }
        

       

        var filePath = Path.Combine("C:\\Users\\I Novbe\\Desktop\\mvc\\WebApplication4\\wwwroot\\images", fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            slider.formFile.CopyTo(stream);
        }


        slider.ImgUrl = fileName;

        await _context.AddAsync(slider);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        var c = await _context.TeachersImages.FindAsync(id);


        _context.TeachersImages.Remove(c!);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }
    public IActionResult Update(int id)
    {
        var c = _context.TeachersImages.FirstOrDefault(x => x.Id == id);

        return View(c);
    }


    [HttpPost]
    public async Task<IActionResult> Update(TeacherImage slider)
    {

        if (slider.formFile != null)
        {
            if (!slider.formFile.ContentType.Contains("image"))
            {
                return View();
            }
            
            var safeFileName = Path.GetFileName(slider.formFile.FileName);
            string fileName;

            if (safeFileName.Length > 100)
            {
                fileName = Guid.NewGuid().ToString() + safeFileName.Substring(safeFileName.Length - 64);
            }
            else
            {
                fileName = Guid.NewGuid().ToString() + safeFileName;
            }


           

            var filePath = Path.Combine("C:\\Users\\I Novbe\\Desktop\\mvc\\WebApplication4\\wwwroot\\images", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                slider.formFile.CopyTo(stream);
            }

            slider.ImgUrl = fileName;




            _context.Update(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        else
        {
            return RedirectToAction("Index");
        }
    }
}
