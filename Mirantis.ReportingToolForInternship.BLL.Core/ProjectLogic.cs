namespace Mirantis.ReportingTool.BLL.Core
{
	using Mirantis.ReportingTool.BLL.Contracts;
	using Mirantis.ReportingTool.DAL.Contracts;
	using Mirantis.ReportingTool.Entities;
	using System;
	using System.Collections.Generic;

	public class ProjectLogic : IProjectLogic
	{
		private ICustomLogger _customLogger;
		private IProjectDAO _projectDAO;

		public ProjectLogic(IProjectDAO projectDAO, ICustomLogger customLogger)
		{
			_projectDAO = projectDAO;
			_customLogger = customLogger;
		}

		public void Add(Project project)
		{
			try 
			{
				_customLogger.RecordInfo("Addition project has started");
				_projectDAO.Add(project);
				_customLogger.RecordInfo("Addition project has finished");
			}
			catch (Exception ex)
			{
				_customLogger.RecordError(ex);
				throw;
			}
		}

		public void Delete(Guid id)
		{
			try
			{
				_customLogger.RecordInfo("Deletion project has started");
				_projectDAO.Delete(id);
				_customLogger.RecordInfo("Deletion project has finished");
			}
			catch (Exception ex)
			{
				_customLogger.RecordError(ex);
				throw;
			}
		}

		public void Edit(Project project)
		{
			try
			{
				_customLogger.RecordInfo("Edition project has started");
				_projectDAO.Edit(project);
				_customLogger.RecordInfo("Edition project has finished");
			}
			catch (Exception ex)
			{
				_customLogger.RecordError(ex);
				throw;
			}
		}

		public IList<Project> GetAll()
		{
			try
			{
				_customLogger.RecordInfo("Getting all project has started");
				return _projectDAO.GetAll();
			}
			catch (Exception ex)
			{
				_customLogger.RecordError(ex);
				throw;
			}
		}

		public Project GetById(Guid id)
		{
			try
			{
				_customLogger.RecordInfo($"Getting project by id {id} has started");
				return _projectDAO.GetById(id);
			}
			catch (Exception ex)
			{
				_customLogger.RecordError(ex);
				throw;
			}
		}
	}
}
