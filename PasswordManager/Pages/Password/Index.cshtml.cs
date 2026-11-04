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
    public PasswordEntry? CurrentPassword { get; set; }

    [BindProperty]
    public string? ConfirmPassword { get; set; }

    public string? Message { get; set; } = "No Password Selected to Edit";

    public void OnGet()
    {
        Passwords = _passwordDatabase.GetAllPasswords();
    }

    public void OnPostSet()
    {
        Passwords = _passwordDatabase.GetAllPasswords();
    }

    public void OnPostDelete()
    {
        if (CurrentPassword is null)
        {
            Message = "Did not delete, password was not deleted";
        }
        else
        {
            Message = "Password deleted, cannot recover";
            _passwordDatabase.DeletePasswordEntry(CurrentPassword.Id);
        }

        CurrentPassword = null;
        Passwords = _passwordDatabase.GetAllPasswords();
    }

    public void OnPostChange()
    {
        if(!ModelState.IsValid)
        {
            Message = "Invalid password entry, password did not change";
        }
        else if(CurrentPassword is null || CurrentPassword.Password != ConfirmPassword)
        {
            Message = "Password's did not match, did not change password";
        }
        else
        {
            Message = "Password Updated";
            _passwordDatabase.UpdatePasswordEntry(CurrentPassword);
        }

        CurrentPassword = null;
        Passwords = _passwordDatabase.GetAllPasswords();
    }
}

