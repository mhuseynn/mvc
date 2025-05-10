using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Contexts;
using WebApplication4.Models.Concretes;


namespace WebApplication4.Areas.Admin.Controllers;
[Area("Admin")]
public class ProductController : Controller
{

    AppDbContext _context;

    public ProductController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _context.Products.Include(x=>x.Category).Include(x=>x.Tags).ToListAsync();

        return View(products);
    }


    public IActionResult Create()
    {
        ViewBag.Categories=_context.Categories.ToList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {

        var safeFileName = Path.GetFileName(product.File.FileName);


        var filePath = Path.Combine("C:\\Users\\I Novbe\\Desktop\\mvc\\WebApplication4\\wwwroot\\images", safeFileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            product.File.CopyTo(stream);
        }


        product.ImageUrl =safeFileName;

        await _context.AddAsync(product);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        var c = await _context.Products.FindAsync(id);


        _context.Products.Remove(c!);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    public IActionResult Update(int id)
    {
        var c = _context.Products.Include(x=>x.Category).FirstOrDefault(x => x.Id == id);
        ViewBag.Categories = _context.Categories.ToList();

        return View(c);
    }


    [HttpPost]
    public async Task<IActionResult> Update(Product slider)
    {
        if (slider.File != null)
        {
            if (!slider.File.ContentType.Contains("image"))
            {
                return View();
            }

            var safeFileName = Path.GetFileName(slider.File.FileName);
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
                slider.File.CopyTo(stream);
            }

            slider.ImageUrl = fileName;


            _context.Products.Update(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        else
        {

            _context.Update(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
