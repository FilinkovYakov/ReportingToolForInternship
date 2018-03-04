namespace Mirantis.ReportingTool.DAL.DataAccessEF
{
	using Mirantis.ReportingTool.DAL.Contracts;
	using Mirantis.ReportingTool.Entities;
	using System;
	using System.Collections.Generic;
	using System.Configuration;
	using System.Linq;

	public class ProjectDAO : IProjectDAO
	{
		private static string connectionString = ConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;

		public void Add(Project project)
		{
			using (var dbContext = new CustomDBContext(connectionString))
			{
				dbContext.Projects.Add(project);
				dbContext.SaveChanges();
			}
		}

		public void Delete(Guid id)
		{
			using (var dbContext = new CustomDBContext(connectionString))
			{
				var originalProject = dbContext.Projects.Find(id);
				dbContext.Projects.Remove(originalProject);
				dbContext.SaveChanges();
			}
		}

		public void Edit(Project project)
		{
			using (var dbContext = new CustomDBContext(connectionString))
			{
				var originalProject = dbContext.Projects.Find(project.Id);
				dbContext.Entry(originalProject).CurrentValues.SetValues(project);
				dbContext.SaveChanges();
			}
		}

		public IList<Project> GetAll()
		{
			using (var dbContext = new CustomDBContext(connectionString))
			{
				return dbContext.Projects.ToList();
			}
		}

		public Project GetById(Guid id)
		{
			using (var dbContext = new CustomDBContext(connectionString))
			{
				return dbContext.Projects.FirstOrDefault(project => project.Id == id);
			}
		}
	}
}
