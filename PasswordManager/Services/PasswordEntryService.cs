using PasswordManager.Models;
using PasswordManager.PasswordDbContext;

namespace PasswordManager.Services;

public class PasswordEntryService : IPasswordEntryServices
{
    PWordDbContext _context;

    public PasswordEntryService(PWordDbContext context)
    {
        _context = context;
    }

    public List<PasswordEntry> GetAllPassword()
    {
        return _context.Passwords.ToList();
    }

    public PasswordEntry GetPasswordEntryById(int id)
    {
        return _context.Passwords.Where(p => p.Id == id).FirstOrDefault();
    }

    public void DeletePasswordEntry(int id)
    {
        PasswordEntry pEntry = GetPasswordEntryById(id);
        _context.Passwords.Remove(pEntry);
    }

    public void UpdatePasswordEntry(PasswordEntry pEntry)
    {
        _context.Passwords.Update(pEntry);
    }

    public void AddPasswordEntry(PasswordEntry pEntry)
    {
        _context.Passwords.Add(pEntry);
    }
}
