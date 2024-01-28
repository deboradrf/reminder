using System.ComponentModel.DataAnnotations;

namespace Reminder.Models
{
    public class Lembrete
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
    }
}
