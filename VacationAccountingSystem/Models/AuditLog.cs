
// Модель лога действий
namespace VacationAccountingSystem.Models
{
    public class AuditLog
    {
        public int Id { get; }
        public string Action { get; }
        public DateTime Time { get; }
        public AuditLog(int id, string action, DateTime time) 
        {
            Id = id;
            Action = action;
            Time = time;
        }
    }
}
