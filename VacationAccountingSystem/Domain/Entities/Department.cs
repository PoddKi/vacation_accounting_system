using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacationAccountingSystem.Domain.Entities;

[Table("deparment")]
public record Department
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; init; }

    [Column("name")]
    [MaxLength(100)]
    public string Name { get; init; }

    [Column("parent_id")]
    public int parent_id { get; init; }
}
