using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PasswordManager.Models;
using PasswordManager.Services;

namespace PasswordManager.Pages.Password;

public class AddPasswordModel : PageModel
{
    private IPasswordEntryServices _passwordDatabase;
    private readonly UserManager<IdentityUser> _userManger;

    public AddPasswordModel(IPasswordEntryServices passwordDatabase, UserManager<IdentityUser> userManager)
    {
        _passwordDatabase = passwordDatabase;
        _userManger = userManager;
    }

    [BindProperty]
    public PasswordEntry? NewPassword { get; set; }

    public string? AuthenticatedUserId { get; set; }

    public string Message { get; set; } = "Password has not been created yet...";

    public void OnGet()
    {
        AuthenticatedUserId = _userManger.GetUserId(User);
    }

    public void OnPostNew()
    {
        AuthenticatedUserId = _userManger.GetUserId(User);

        if (!ModelState.IsValid || NewPassword is null)
        {
            Message = "Password input invalid, no password created";
        }
        else if (NewPassword.UserId != AuthenticatedUserId) {
            Message = "Password not created, why you tryna hack me?";
        }
        else
        {
            Message = "Password created, take a look in the vault";
            _passwordDatabase.AddPasswordEntry(NewPassword);
        }

        NewPassword = null;
    }
}