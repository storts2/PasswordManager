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

    public List<PasswordEntry> GetAllPasswords()
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
        _context.SaveChanges();
    }

    public void UpdatePasswordEntry(PasswordEntry pEntry)
    {
        _context.Passwords.Update(pEntry);
        _context.SaveChanges();
    }

    public void AddPasswordEntry(PasswordEntry pEntry)
    {
        _context.Passwords.Add(pEntry);
        _context.SaveChanges();
    }
}
