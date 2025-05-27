using Microsoft.EntityFrameworkCore;
using VacationAccountingSystem.Domains.Entities;

namespace VacationAccountingSystem.Data;

public class VacationDbContext : DbContext
{
    public VacationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {

    }
    
    public DbSet<User> Users { get; set; }
}
