namespace Mirantis.ReportingTool.BLL.Core
{
	using Contracts;
	using System;
	using System.Collections.Generic;
	using Entities;
	using System.Linq;
	using DAL.Contracts;
	using AutoMapper;

	public class ReportLogic : IReportLogic
	{
		private readonly IReportDAO _reportDAO;
		private readonly ICustomLogger _customLogger;
		private readonly IUserDAO _userDAO;
		private readonly IMapper _mapper;

		public ReportLogic(IReportDAO reportDAO, IUserDAO userDAO, IMapper mapper, ICustomLogger customLogger)
		{
			_reportDAO = reportDAO ?? throw new ArgumentNullException(nameof(reportDAO));
			_userDAO = userDAO ?? throw new ArgumentNullException(nameof(userDAO));
			_customLogger = customLogger ?? throw new ArgumentNullException(nameof(customLogger));
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		public void Add(Report report)
		{
			try
			{
				_customLogger.RecordInfo("Addition report has started");
				report.Activities = GetCorrectActivities(report).ToList();
				report.FuturePlans = GetCorrectFuturePlans(report).ToList();
				_reportDAO.Add(report);
				_customLogger.RecordInfo("Addition report has finished");
			}
			catch (Exception e)
			{
				_customLogger.RecordError(e);
				throw;
			}
		}

		public void Edit(Report report)
		{
			try
			{
				_customLogger.RecordInfo("Editing report has started");
				report.Activities = GetCorrectActivities(report).ToList();
				report.FuturePlans = GetCorrectFuturePlans(report).ToList();
				_reportDAO.Edit(report);
				_customLogger.RecordInfo("Editing report has finished");
			}
			catch (Exception e)
			{
				_customLogger.RecordError(e);
				throw;
			}
		}

		public Report GetById(Guid id)
		{
			try
			{
				_customLogger.RecordInfo($"Getting report by id {id} has started");
				return FetchDependentEntities(_reportDAO.GetById(id));
			}
			catch (Exception e)
			{
				_customLogger.RecordError(e);
				throw;
			}
		}

		public IList<Report> SearchForUser(SearchReportModel searchModel)
		{
			try
			{
				_customLogger.RecordInfo("Search report has started");
				return _reportDAO.SearchForUser(searchModel).Select(user => FetchDependentEntities(user)).ToList();
			}
			catch (Exception e)
			{
				_customLogger.RecordError(e);
				throw;
			}
		}

		private IEnumerable<Activity> GetCorrectActivities(Report report)
		{
			if (report.Activities == null)
			{
				throw new ArgumentException("Report should contain at least one activity");
			}

			foreach (var activity in report.Activities)
			{
				if (!string.IsNullOrEmpty(activity.Description))
				{
					activity.ReportId = report.Id;
					activity.Questions = GetCorrectQuestions(activity).ToList();
					yield return activity;
				}
			}
		}

		private IEnumerable<Question> GetCorrectQuestions(Activity activity)
		{
			if (activity.Questions != null)
			{
				foreach (var question in activity.Questions)
				{
					if (!string.IsNullOrEmpty(question.Description))
					{
						question.ActivityId = activity.Id;
						yield return question;
					}
				}
			}
		}

		private IEnumerable<FuturePlan> GetCorrectFuturePlans(Report report)
		{
			if (report.FuturePlans == null)
			{
				throw new ArgumentException("Report should contain at least one future plan");
			}

			foreach (var futurePlan in report.FuturePlans)
			{
				if (!string.IsNullOrEmpty(futurePlan.Description))
				{
					futurePlan.ReportId = report.Id;
					yield return futurePlan;
				}
			}
		}

		public IList<Report> SearchForValidation(SearchReportModel searchModel)
		{
			try
			{
				return _reportDAO.SearchForValidation(searchModel);
			}
			catch (Exception e)
			{
				_customLogger.RecordError(e);
				throw;
			}
		}

		private Report FetchDependentEntities(Report report)
		{
			if (report.EngineerId != null)
			{
				report.Engineer = _userDAO.GetById(report.EngineerId.Value);
			}
			if (report.ManagerId != null)
			{
				report.Manager = _userDAO.GetById(report.ManagerId.Value);
			}
			return report;
		}
	}
}
