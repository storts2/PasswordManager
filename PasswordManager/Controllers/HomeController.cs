using Microsoft.AspNetCore.Mvc;
using PasswordManager.Models;
using PasswordManager.Services;
using System.Diagnostics;

namespace PasswordManager.Controllers;

public class HomeController : Controller
{
    IPasswordEntryServices _passwordEntryService;

    public HomeController(IPasswordEntryServices passwordEntryService)
    {
        _passwordEntryService = passwordEntryService;
    }

    public IActionResult Index()
    {
        return View();
    }
}
