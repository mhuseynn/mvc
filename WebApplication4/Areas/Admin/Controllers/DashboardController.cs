﻿using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Areas.Admin.Controllers;

[Area("Admin")]
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
