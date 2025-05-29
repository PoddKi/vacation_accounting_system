using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacationAccountingSystem.Models;

[Table("Vacation")]
public record Vacation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; init; }

    [Column("user")]
    [MaxLength(100)]
    public string User { get; init; }

    [Column("start_date")]
    public DateTime startDate { get; init; }

    [Column("end_date")]
    public DateTime endDate { get; init; }

    [Column("deputy")]
    [MaxLength(100)]
    public string Deputy { get; init; }

}
