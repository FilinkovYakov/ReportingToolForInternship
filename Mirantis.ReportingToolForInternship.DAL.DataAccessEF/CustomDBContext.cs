namespace Mirantis.ReportingToolForInternship.DAL.DataAccessEF
{
    using Entities;
    using System.Data.Entity;

    public class CustomDBContext : DbContext
    {
        static CustomDBContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<CustomDBContext>());
        }

        public CustomDBContext() { }

        public CustomDBContext(string connString) : base(connString) { }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<FuturePlan> FuturePlans { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}