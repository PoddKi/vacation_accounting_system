using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacationAccountingSystem.Models;

[Table("department")]
public record Department
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; init; }

    [Column("name")]
    [Required]
    [MaxLength(100)]
    public string Name { get; init; }

    [ForeignKey("parent_id")]
    public Department? ParentDepartment { get; init; }

    //public List<User> Users { get; }
}
