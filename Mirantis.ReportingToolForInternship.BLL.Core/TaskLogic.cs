namespace Mirantis.ReportingTool.BLL.Core
{
	using Mirantis.ReportingTool.BLL.Contracts;
	using Mirantis.ReportingTool.DAL.Contracts;
	using Mirantis.ReportingTool.Entities;
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class TaskLogic : ITaskLogic
	{
		private readonly ICustomLogger _customLogger;
		private readonly ITaskDAO _taskDAO;
		private readonly IUserLogic _userLogic;

		public TaskLogic(ITaskDAO taskDAO, IUserLogic userLogic, ICustomLogger customLogger)
		{
			_taskDAO = taskDAO ?? throw new ArgumentNullException(nameof(taskDAO));
			_customLogger = customLogger ?? throw new ArgumentNullException(nameof(customLogger));
			_userLogic = userLogic ?? throw new ArgumentNullException(nameof(userLogic));
		}

		public void Add(Task task)
		{
			try
			{
				task.Status = "Open";
				_customLogger.RecordInfo("Addition task has started");
				_taskDAO.Add(task);
				_customLogger.RecordInfo("Addition task has finished");
			}
			catch (Exception ex)
			{
				_customLogger.RecordError(ex);
				throw;
			}
		}

		public void Edit(Task task)
		{
			try
			{
				_customLogger.RecordInfo("Editing task has started");
				_taskDAO.Edit(task);
				_customLogger.RecordInfo("Editing task has finished");
			}
			catch (Exception ex)
			{
				_customLogger.RecordError(ex);
				throw;
			}
		}

		public Task GetById(Guid id)
		{
			try
			{
				_customLogger.RecordInfo($"Finding task by id {id} has started");
				return FetchDependentEntities(_taskDAO.GetById(id));
			}
			catch (Exception ex)
			{
				_customLogger.RecordError(ex);
				throw;
			}
		}

		public IList<Task> Search(SearchTaskModel searchModel)
		{
			try
			{
				_customLogger.RecordInfo("Search task has started");
				return _taskDAO.Search(searchModel).Select(task => FetchDependentEntities(task)).ToList();
			}
			catch (Exception ex)
			{
				_customLogger.RecordError(ex);
				throw;
			}
		}

		private Task FetchDependentEntities(Task task)
		{
			task.Reporter = _userLogic.GetById(task.ReporterId);
			if (task.AssigneeId.HasValue)
			{
				task.Assignee = _userLogic.GetById(task.AssigneeId.Value);
			}
			return task;
		}
	}
}
