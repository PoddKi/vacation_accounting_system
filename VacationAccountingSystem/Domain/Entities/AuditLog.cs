using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacationAccountingSystem.Domain.Entities;

[Table("audit_log")]
public record AuditLog
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; init; }

    [Column("action")]
    [MaxLength(100)]
    public string Action { get; init; }

    [Column("date_time")]
    public DateTime DateTime { get; init; }
}
