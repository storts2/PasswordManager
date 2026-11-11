using PasswordManager.Models;
using PasswordManager.PasswordDbContext;
using Microsoft.AspNetCore.DataProtection;

namespace PasswordManager.Services;

public class PasswordEntryService : IPasswordEntryServices
{
    PWordDbContext _context;
    IDataProtector _protector;

    public PasswordEntryService(PWordDbContext context, IDataProtectionProvider provider)
    {
        _context = context;
        _protector = provider.CreateProtector("green");
    }

    public List<PasswordEntry> GetAllPasswords()
    {
        List<PasswordEntry> HashedPasswords = _context.Passwords.ToList();

        foreach (PasswordEntry pWord in HashedPasswords)
        {
            pWord.Password = _protector.Unprotect(pWord.Password);
        }

        return HashedPasswords;
    }

    public List<PasswordEntry> GetAllPasswordsByUserId(string id)
    {
        List<PasswordEntry> HashedPasswords = _context.Passwords.Where(p => p.UserId == id).ToList();

        foreach (PasswordEntry pWord in HashedPasswords)
        {
            pWord.Password = _protector.Unprotect(pWord.Password);
        }

        return HashedPasswords;
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
        pEntry.Password = _protector.Protect(pEntry.Password);

        _context.Passwords.Update(pEntry);
        _context.SaveChanges();
    }

    public void AddPasswordEntry(PasswordEntry pEntry)
    {
        pEntry.Password = _protector.Protect(pEntry.Password);

        _context.Passwords.Add(pEntry);
        _context.SaveChanges();
    }
}
