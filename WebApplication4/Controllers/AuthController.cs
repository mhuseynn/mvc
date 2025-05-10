using Microsoft.AspNetCore.Mvc;
using WebApplication4.ViewModels;

namespace WebApplication4.Controllers;

public class AuthController : Controller
{
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(RegisterVM registerVM)
    {
        return View();
    }


    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(RegisterVM loginVM)
    {
        return View();
    }
}
