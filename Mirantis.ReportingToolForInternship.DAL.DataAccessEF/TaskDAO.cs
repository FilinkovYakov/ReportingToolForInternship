namespace Mirantis.ReportingTool.DAL.DataAccessEF
{
	using Mirantis.ReportingTool.DAL.Contracts;
	using Mirantis.ReportingTool.Entities;
	using System;
	using System.Collections.Generic;
	using System.Configuration;
	using System.Data.Entity;
	using System.Linq;

	public class TaskDAO : ITaskDAO
	{
		private static string connectionString = ConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;

		public void Add(Task task)
		{
			using (var dbContext = new CustomDBContext(connectionString))
			{
				dbContext.Tasks.Add(task);
				dbContext.SaveChanges();
			}
		}

		public void Edit(Task task)
		{
			using (var dbContext = new CustomDBContext(connectionString))
			{
				var originalTask = dbContext.Tasks.Find(task.Id);
				dbContext.Entry(originalTask).CurrentValues.SetValues(task);
				dbContext.Entry(originalTask).Property(x => x.ReporterId).IsModified = false;
				dbContext.SaveChanges();
			}
		}

		public Task GetById(Guid id)
		{
			using (var dbContext = new CustomDBContext(connectionString))
			{
				return dbContext.Tasks.Where(task => task.Id == id)
					.Include(task => task.Project)
					.FirstOrDefault();
			}
		}

		public IList<Task> GetByUserId(Guid userId)
		{
			using (var dbContext = new CustomDBContext(connectionString))
			{
				return dbContext.Tasks
					.Where(task => task.ReporterId == userId || task.AssigneeId == userId).ToList();
			}
		}

		public IList<Task> Search(SearchTaskModel searchModel)
		{
			using (var dbContext = new CustomDBContext(connectionString))
			{
				var query = dbContext.Tasks.Select(task => task);
				if (searchModel.ProjectId != null)
				{
					query = query.Where(task => task.ProjectId == searchModel.ProjectId);
				}

				if (searchModel.ReporterId != null)
				{
					query = query.Where(task => task.ReporterId == searchModel.ReporterId);
				}

				if (searchModel.AssigneeId != null)
				{
					query = query.Where(task => task.AssigneeId == searchModel.AssigneeId);
				}

				if (!string.IsNullOrEmpty(searchModel.Title))
				{
					query = query.Where(task => task.Title.Contains(searchModel.Title));
				}

				if (!string.IsNullOrEmpty(searchModel.Status) && searchModel.Status != "All")
				{
					query = query.Where(task => task.Title == searchModel.Title);
				}

				return query.Include(task => task.Project).ToList();
			}
		}
	}
}
