using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication4.Models.Concretes;
using WebApplication4.ViewModels;

namespace WebApplication4.Controllers;

[AllowAnonymous]
public class AuthController : Controller
{

    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;

    public AuthController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> LoginAsync(LoginVM model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }

        var result = await _signInManager.PasswordSignInAsync(user,model.Password,model.IsPersistent,false);

        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError("", "Invalid login attempt.");
        return View(model);
    }
    
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterVM registerVM)
    {
        if (!ModelState.IsValid)
        {
            return View(registerVM);
        }
        AppUser user = new AppUser();

        user.Email = registerVM.Email;
        user.Name = registerVM.Name;
        user.Surname = registerVM.Surname;
        user.UserName=registerVM.Username;

        var result = await _userManager.CreateAsync(user,registerVM.Password);

        if (result.Succeeded)
        {
            return RedirectToAction("Login");
        }

        return View();
    }


  
}
