namespace Mirantis.ReportingTool.PL.WebUI.Automapper
{
    using AutoMapper;
    using BLL.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class PLAutomapper
    {
        private static IMapper mapper;

        static PLAutomapper()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Models.SearchVM, Entities.SearchModel>();
                c.CreateMap<Entities.SearchModel, Models.SearchVM>();

                c.CreateMap<Models.QuestionVM, Entities.Question>();
                c.CreateMap<Entities.Question, Models.QuestionVM>().ForMember(x => x.Id, x => x.NullSubstitute(Guid.Empty));

                c.CreateMap<Models.ActivityVM, Entities.Activity>();
                c.CreateMap<Entities.Activity, Models.ActivityVM>().ForMember(x => x.Id, x => x.NullSubstitute(Guid.Empty));

                c.CreateMap<Models.FuturePlanVM, Entities.FuturePlan>();
                c.CreateMap<Entities.FuturePlan, Models.FuturePlanVM>().ForMember(x => x.Id, x => x.NullSubstitute(Guid.Empty));

                c.CreateMap<Models.ReportVM, Entities.Report>();
                c.CreateMap<Entities.Report, Models.ReportVM>().ForMember(x => x.Id, x => x.NullSubstitute(Guid.Empty));

                c.CreateMap<Entities.User, Models.CookieUser>();

                c.CreateMap<Entities.RepresentingReport, Models.RepresentingReportVM>();
            });

            mapper = config.CreateMapper();
        }

        public static IMapper Mapper
        {
            get { return mapper; }
        }
    }
}