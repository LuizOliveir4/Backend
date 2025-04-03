using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Autentication.Models;

public class AppUserAddress
{
    [Key, ForeignKey(nameof(User))]
    public string UserId { get; set; } = null!;
    public string? StreetName { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }

    public AppUser User { get; set; } = null!;
}
