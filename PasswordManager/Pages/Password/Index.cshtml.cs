using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PasswordManager.Models;
using PasswordManager.Services;

namespace PasswordManager.Pages.Password;

public class IndexModel : PageModel
{
    private IPasswordEntryServices _passwordDatabase;

    public IndexModel(IPasswordEntryServices passwordDatabase)
    {
        _passwordDatabase = passwordDatabase;
        Passwords = new List<PasswordEntry>();
    }

    public List<PasswordEntry> Passwords { get; set; }

    [BindProperty]
    public int CurrentId { get; set; }

    public void OnGet()
    {
        Passwords = _passwordDatabase.GetAllPasswords();
    }
}

