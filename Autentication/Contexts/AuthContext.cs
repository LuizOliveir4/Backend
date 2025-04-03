using Autentication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Autentication.Contexts;

public class AuthContext(DbContextOptions<AuthContext> options) : IdentityDbContext<AppUser>(options)
{
    public DbSet<AppUserAddress> UserAddresses { get; set; }
}
