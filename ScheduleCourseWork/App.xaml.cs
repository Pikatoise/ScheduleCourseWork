using Microsoft.Extensions.Configuration;
using System.Windows;

namespace ScheduleCourseWork
{
    public partial class App : Application
    {
        private static IConfiguration? config;

        public static ScheduleContext? DbSchedule;

        public static bool CanConnect { 
            get 
            {
                return DbSchedule.Database.CanConnect(); 
            }
        }

        public App()
        {
            config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            DbSchedule = new ScheduleContext(config.GetConnectionString("database"));
        }
    }
}
