namespace Mirantis.ReportingToolForInternship.PL.WebUI.Initializers
{
    using BLL.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class PLAutomapperInitializer
    {
        BLLAutomapperInitializer bllInitializer;

        public PLAutomapperInitializer()
        {
            bllInitializer = new BLLAutomapperInitializer();
        }

        public void Initialize()
        {
            bllInitializer.Initialize();
            AutoMapper.Mapper.Initialize(c =>
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

                //c.CreateMap<Entities.Report, Entities.RepresentingReport>()
                //.ForMember(x => x.MentorsFullName, x => x.UseValue(string.Empty))
                //.ForMember(x => x.InternsFullName, x => x.UseValue(string.Empty));

                //c.CreateMap<Entities.RepresentingReport, Models.RepresentingReportVM>();
            });
        }
    }
}