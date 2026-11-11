using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PasswordManager.Models;
using PasswordManager.Services;

namespace PasswordManager.Pages.Password;

public class IndexModel : PageModel
{
    private IPasswordEntryServices _passwordDatabase;
    private readonly UserManager<IdentityUser> _userManger;

    public IndexModel(IPasswordEntryServices passwordDatabase, UserManager<IdentityUser> userManager)
    {
        _passwordDatabase = passwordDatabase;
        _userManger = userManager;
        Passwords = new List<PasswordEntry>();
    }

    public List<PasswordEntry> Passwords { get; set; }

    [BindProperty]
    public PasswordEntry? CurrentPassword { get; set; }

    [BindProperty]
    public string? ConfirmPassword { get; set; }

    public string? AuthenticatedUserId { get; set; }

    public string? Message { get; set; } = "No Password Selected to Edit";

    public void OnGet()
    {
        AuthenticatedUserId = _userManger.GetUserId(User);

        Passwords = _passwordDatabase.GetAllPasswordsByUserId(AuthenticatedUserId);
    }

    public void OnPostSet()
    {
        AuthenticatedUserId = _userManger.GetUserId(User);

        Passwords = _passwordDatabase.GetAllPasswordsByUserId(AuthenticatedUserId);
    }

    public void OnPostDelete()
    {
        AuthenticatedUserId = _userManger.GetUserId(User);

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
        Passwords = _passwordDatabase.GetAllPasswordsByUserId(AuthenticatedUserId);
    }

    public void OnPostChange()
    {
        AuthenticatedUserId = _userManger.GetUserId(User);

        if (!ModelState.IsValid)
        {
            Message = "Invalid password entry, password did not change";
        }
        else if(CurrentPassword is null || CurrentPassword.Password != ConfirmPassword)
        {
            Message = "Password's did not match, did not change password";
        }
        else if (CurrentPassword.UserId != AuthenticatedUserId)
        {
            Message = "Password not changed, you tryna hack me?";
        }
        else
        {
            Message = "Password Updated";
            _passwordDatabase.UpdatePasswordEntry(CurrentPassword);
        }

        CurrentPassword = null;
        Passwords = _passwordDatabase.GetAllPasswordsByUserId(AuthenticatedUserId);
    }
}

