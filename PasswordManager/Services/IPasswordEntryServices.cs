using PasswordManager.Models;
using PasswordManager.PasswordDbContext;

namespace PasswordManager.Services;

public interface IPasswordEntryServices
{
    public List<PasswordEntry> GetAllPassword();

    public PasswordEntry GetPasswordEntryById(int id);

    public void DeletePasswordEntry(int id);

    public void UpdatePasswordEntry(PasswordEntry pEntry);

    public void AddPasswordEntry(PasswordEntry pEntry);
}
