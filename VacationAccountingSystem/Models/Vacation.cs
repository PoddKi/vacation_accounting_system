namespace VacationAccountingSystem.Models
{
    public class Vacation
    {
        public int Id { get; }
        public User User { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public User Deputy { get; }

        public Vacation (int id, User user, DateTime startDate, DateTime endDate, User deputy)
        {
            Id = id;
            User = user;
            StartDate = startDate;
            EndDate = endDate;
            Deputy = deputy;
        }
    }
}
