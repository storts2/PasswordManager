using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PasswordManager.Models;
using PasswordManager.Services;

namespace PasswordManager.Pages.Password;

public class AddPasswordModel : PageModel
{
    private IPasswordEntryServices _passwordDatabase;

    public AddPasswordModel(IPasswordEntryServices passwordDatabase)
    {
        _passwordDatabase = passwordDatabase;
    }

    [BindProperty]
    public PasswordEntry NewPassword { get; set; }


    public string Message { get; set; } = "Password has not been created yet...";
    public void OnPostNew()
    {
        if(!ModelState.IsValid)
        {
            Message = "Password input invalid, no password created";
        }
        else
        {
            _passwordDatabase.AddPasswordEntry(NewPassword);
        }
    }
}
