using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ReminderModule.Data.Models
{
    public class Emailsetup
    {
        public int Id { get; set; }
        [DisplayName("Email Server Host")]
        public required string EmailHost { get; set; }

        [DisplayName("Email Server Port No")]
        public int Port { get; set; }

        [DisplayName("Enable SSL")]
        public bool EnableSSL { get; set; }

        [DisplayName("Email User Name")]
        public required string HUName { get; set; }

        [DisplayName("Email Password")]        
        public required string HUPassword { get; set; }

        [DisplayName("Time Interval for batch file in minutes")]
        public int Interval { get; set; } = 5;

        [DisplayName("From Email id")]
        public required string EmailFrom { get; set; }

        [DisplayName("To Email id")]
        public required string EmailTo { get; set; }

        [DisplayName("Subject")]
        public required string Subject { get; set; }

        [DisplayName("Email Body")]
        [DataType(DataType.MultilineText)]
        public required string Body { get; set; }


        //public string LogFilePath { get; set; }

        [DisplayName("Sender's Name")]
        public required string SenderName { get; set; }
    }
}
