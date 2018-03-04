namespace Mirantis.ReportingTool.PL.WebUI.Automapper
{
	using AutoMapper;
	using Mirantis.ReportingTool.Entities;
	using System;

	public static class AutoMapperProfile
	{
		public static MapperConfiguration InitializeAutoMapper()
		{
			MapperConfiguration config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<Models.SearchReportVM, Entities.SearchReportModel>();
				cfg.CreateMap<Entities.SearchReportModel, Models.SearchReportVM>();
				
				cfg.CreateMap<Models.SearchTaskVM, Entities.SearchTaskModel>();
				cfg.CreateMap<Entities.SearchTaskModel, Models.SearchTaskVM>();

				cfg.CreateMap<Models.QuestionVM, Entities.Question>();
				cfg.CreateMap<Entities.Question, Models.QuestionVM>().ForMember(x => x.Id, x => x.NullSubstitute(Guid.Empty));

				cfg.CreateMap<Models.ActivityVM, Entities.Activity>();
				cfg.CreateMap<Entities.Activity, Models.ActivityVM>().ForMember(x => x.Id, x => x.NullSubstitute(Guid.Empty));

				cfg.CreateMap<Models.FuturePlanVM, Entities.FuturePlan>();
				cfg.CreateMap<Entities.FuturePlan, Models.FuturePlanVM>().ForMember(x => x.Id, x => x.NullSubstitute(Guid.Empty));

				cfg.CreateMap<Models.ReportVM, Entities.Report>();
				cfg.CreateMap<Entities.Report, Models.ReportVM>().ForMember(x => x.Id, x => x.NullSubstitute(Guid.Empty));

				cfg.CreateMap<Entities.User, Models.CookieUser>();
				cfg.CreateMap<Models.UserVM, Entities.User>();

				cfg.CreateMap<Models.TaskVM, Entities.Task>()
					.ForMember(x => x.Reporter, x => x.AllowNull())
					.ForMember(x => x.Assignee, x => x.AllowNull());
				cfg.CreateMap<Entities.Task, Models.TaskVM>()
					.ForMember(x => x.Id, x => x.NullSubstitute(Guid.Empty));

				cfg.CreateMap<Models.ProjectVM, Entities.Project>();
				cfg.CreateMap<Entities.Project, Models.ProjectVM>().ForMember(x => x.Id, x => x.NullSubstitute(Guid.Empty));
			});

			return config;
		}
	}
}