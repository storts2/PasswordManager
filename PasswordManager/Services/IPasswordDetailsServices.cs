using PasswordManager.Models;
using PasswordManager.PasswordDbContext;

namespace PasswordManager.Services;

public interface IPasswordDetailsServices
{
    public List<PasswordEntry> GetAllPassword();

    public PasswordEntry GetPasswordEntry(int id);

    public void DeletePasswordEntry(int id);

    public void UpdatePasswordEntry(PasswordEntry pEntry);

    public void AddPasswordEntry(PasswordEntry pEntry);

}
