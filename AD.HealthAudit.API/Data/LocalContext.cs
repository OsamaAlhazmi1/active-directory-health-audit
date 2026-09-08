using AD.HealthAudit.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AD.HealthAudit.API.Data;

public class LocalContext(DbContextOptions<LocalContext> options ): DbContext (options)
{
    public DbSet <User> Users => Set<User>();
    public DbSet<Computer> Computers => Set<Computer>();
    public DbSet<Domian> Domians => Set<Domian>();
    public DbSet<Group> Groups => Set<Group>();


}
