using System.Numerics;

namespace VacationAccountingSystem.Models
{
    public class Department
    {
        public int Id { get; }
        public string Name { get; }
        public int? ParentId { get; }

        public Department(int id, string name, int? parentId = null)
        {
            Id = id;
            Name = name;
            ParentId = parentId;
        }
    }
}
