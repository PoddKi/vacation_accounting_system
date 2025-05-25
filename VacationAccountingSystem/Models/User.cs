namespace VacationAccountingSystem.Models
{
    public class User
    {
        public int Id { get; }
        public string FullName { get; }
        public RolesEnum Role { get; }
        public Department Department { get; }
        public List<Vacation> Vacations { get; }

        public User (int id, string fullName, RolesEnum role, Department department)
        {
            Id = id;
            FullName = fullName;
            Role = role;
            Department = department;
            Vacations = new List<Vacation> ();
        }
    }
}
