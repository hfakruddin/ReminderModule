namespace ReminderModule.Data.Models
{
    public class Reminder
    {
        public int ReminderId { get; set; }
        public string Title { get; set; }
        public DateTime ReminderDateTime { get; set; }
        public bool EmailSent { get; set; }
    }
}
