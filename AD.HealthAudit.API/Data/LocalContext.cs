using AD.HealthAudit.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AD.HealthAudit.API.Data;

public class LocalContext(DbContextOptions<LocalContext> options ): DbContext (options)
{
    public DbSet <User> Users => Set<User>();
    public DbSet<Computer> Computers => Set<Computer>();
    public DbSet<Domain> Domain => Set<Domain>();
    public DbSet<Group> Groups => Set<Group>();
    public DbSet<DomainController> DomainController => Set<DomainController>();


}
