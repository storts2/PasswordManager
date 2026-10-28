using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Models;

public class PasswordDetails
{

    [Key]
    public int Id { get; set; }

    public string? Company { get; set; }

    public string? Password { get; set; }
}
