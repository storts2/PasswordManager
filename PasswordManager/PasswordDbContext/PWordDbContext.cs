using Microsoft.EntityFrameworkCore;
using PasswordManager.Models;

namespace PasswordManager.PasswordDbContext;


public class PWordDbContext : DbContext
{
    public PWordDbContext(DbContextOptions<PWordDbContext> options) : base(options) { }

    public DbSet<PasswordEntry> Passwords { get; set; }
}
