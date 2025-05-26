using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VacationAccountingSystem.Models;

namespace VacationAccountingSystem.Domains.Entities;

[Table("user")]
public record User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; init; }

    [Column("full_name")]
    [MaxLength(100)]
    public string FullName { get; init; }

    [Column("role")]
    [MaxLength(100)]
    public RolesEnum Role { get; init; }

    [Column("department")]
    [MaxLength(100)]
    public string Department { get; init; }
}
