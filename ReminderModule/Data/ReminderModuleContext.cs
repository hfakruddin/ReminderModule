using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReminderModule.Data.Models;

namespace ReminderModule.Data
{
    public class ReminderModuleContext : DbContext
    {
        public ReminderModuleContext (DbContextOptions<ReminderModuleContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ReminderModule.Data.Models.Reminder> Reminder { get; set; } = default!;
        public DbSet<ReminderModule.Data.Models.Emailsetup> Emailsetup { get; set; } = default!;
    }
}
