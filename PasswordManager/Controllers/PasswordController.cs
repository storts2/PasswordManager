using Microsoft.AspNetCore.Mvc;
using PasswordManager.Services;

namespace PasswordManager.Controllers;

public class PasswordController : Controller
{
    IPasswordEntryServices _passwordEntryService;

    public PasswordController(IPasswordEntryServices passwordEntryService)
    {
        _passwordEntryService = passwordEntryService;
    }

    public IActionResult Index ()
    {
        return View(_passwordEntryService.GetAllPasswords());
    }
}
