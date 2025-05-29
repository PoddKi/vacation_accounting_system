using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacationAccountingSystem.Models;

[Table("user")]
public record User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; init; }

    [Column("email")]
    [Required]
    public string Email { get; init; }

    [Column("password")]
    [Required]
    [MaxLength(50)]
    public string Password { get; init; }

    [Column("role")]
    [Required]
    [MaxLength(20)]
    public string Role { get; init; }

    [Column("full_name")]
    [Required]
    [MaxLength(100)]
    public string FullName { get; init; }

    [Column("function")]
    [Required]
    [MaxLength(100)]
    public string Function { get; init; }

    [ForeignKey("department_id")]
    [Required]
    public Department Department { get; init; }

    //public List<Vacation> Vacations { get; }
}
