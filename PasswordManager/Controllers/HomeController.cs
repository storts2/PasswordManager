using Microsoft.AspNetCore.Mvc;
using PasswordManager.Models;
using PasswordManager.Services;
using System.Diagnostics;

namespace PasswordManager.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
