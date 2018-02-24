namespace Mirantis.ReportingTool.DAL.DataAccessEF
{
    using Entities;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure.Annotations;

    public class CustomDBContext : DbContext
    {
        static CustomDBContext()
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists<CustomDBContext>());
            Database.SetInitializer(new DropCreateDatabaseAlways<CustomDBContext>());
        }

        public CustomDBContext() { }

        public CustomDBContext(string connString) : base(connString)
        {

        }
        
        public DbSet<Activity> Activities { get; set; }
        public DbSet<FuturePlan> FuturePlans { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Report>()
                .Property(e => e.Title)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                        {
                            new IndexAttribute("Idx_ReportTitle", 0) { IsUnique = true }
                        }));
            modelBuilder.Entity<Report>()
                .Property(e => e.Date)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                        {
                            new IndexAttribute("Idx_ReportTitle", 1) { IsUnique = true }
                        }));
            modelBuilder.Entity<Report>()
                .Property(e => e.ManagerId)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                        {
                            new IndexAttribute("Idx_ReportTitle", 2) { IsUnique = true }
                        }));
            modelBuilder.Entity<Report>()
                .Property(e => e.EngineerId)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                        {
                            new IndexAttribute("Idx_ReportTitle", 3) { IsUnique = true }
                        }));

            base.OnModelCreating(modelBuilder);
        }
    }
}