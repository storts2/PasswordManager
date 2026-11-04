using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Models;

public class PasswordEntry
{

    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 1)]
    public string? Company { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 1)]
    public string? Password { get; set; }
}
