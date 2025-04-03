using Data.Enitties;
using Microsoft.EntityFrameworkCore;
namespace Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<MemberEntity> Members { get; set; }
    public DbSet<StatusEntity> Statuses { get; set; }
    public DbSet<ProjectEntity> Projects { get; set; }
    public DbSet<ClientEntity> Clients { get; set; }
}
