using Microsoft.EntityFrameworkCore;

namespace VacationAccountingSystem.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Department> Departments { get; set; }
        
        public DbSet<Vacation> Vacations { get; set; }

        public DbSet<AuditLog> AuditLogs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Конфигурации моделей
            modelBuilder.Entity<User>().HasKey(e => e.Id);
            modelBuilder.Entity<Vacation>().HasKey(v => v.Id);
            modelBuilder.Entity<AuditLog>().HasKey(a => a.Id);
            modelBuilder.Entity<Department>().HasKey(d => d.Id);

            // Настройка User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(e => e.Department)
                    .WithMany(d => d.Users)
                    .HasForeignKey(e => e.Department)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Настройка Vacation
            modelBuilder.Entity<Vacation>(entity =>
            {
                entity.HasKey(v => v.Id);

                entity.Property(v => v.StartDate)
                    .IsRequired();

                entity.Property(v => v.EndDate)
                    .IsRequired();

                entity.Property(v => v.Deputy)
                    .IsRequired()
                    .HasMaxLength(50);


                entity.HasOne(v => v.User)
                    .WithMany(v => v.Vacations)
                    .HasForeignKey(v => v.User)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Настройка Department
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(d => d.Id);

                entity.Property(d => d.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<AuditLog>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.Property(a => a.Action)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
