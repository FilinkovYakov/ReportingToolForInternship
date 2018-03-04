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

		public DbSet<Project> Projects { get; set; }
		public DbSet<Task> Tasks { get; set; }
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

			modelBuilder.Entity<Project>()
				.HasMany<Task>(c => c.Tasks)
				.WithRequired(x => x.Project)
				.WillCascadeOnDelete(true);

			modelBuilder.Entity<Task>()
				.HasMany<Report>(c => c.Reports)
				.WithRequired(x => x.Task)
				.WillCascadeOnDelete(true);

			modelBuilder.Entity<Report>()
				.HasMany<Activity>(c => c.Activities)
				.WithRequired(x => x.Report)
				.WillCascadeOnDelete(true);

			modelBuilder.Entity<Report>()
				.HasMany<FuturePlan>(c => c.FuturePlans)
				.WithRequired(x => x.Report)
				.WillCascadeOnDelete(true);

			modelBuilder.Entity<Activity>()
				.HasMany<Question>(c => c.Questions)
				.WithRequired(x => x.Activity)
				.WillCascadeOnDelete(true);

			base.OnModelCreating(modelBuilder);
		}
	}
}