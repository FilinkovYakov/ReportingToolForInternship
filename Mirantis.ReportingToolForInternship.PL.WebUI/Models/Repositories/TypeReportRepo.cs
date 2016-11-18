namespace Mirantis.ReportingToolForInternship.PL.WebUI.Models.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class TypeReportRepo
    {
        private static List<TypeReportVM> repo;

        static TypeReportRepo()
        {
            repo = new List<TypeReportVM>()
            {
                new TypeReportVM()
                {
                    Name = "Daily"
                },
                new TypeReportVM()
                {
                    Name = "Weekly"
                },
                new TypeReportVM
                {
                    Name = "All"
                }
            };
        }

        public static List<TypeReportVM> Repo
        {
            get { return repo; }
        }
    }
}