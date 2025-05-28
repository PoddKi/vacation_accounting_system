using Microsoft.EntityFrameworkCore;
using VacationAccountingSystem.Domain.Entities;

namespace VacationAccountingSystem.Data;

public class VacationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Department> Departments { get; set; }

    public VacationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {

    }
}
