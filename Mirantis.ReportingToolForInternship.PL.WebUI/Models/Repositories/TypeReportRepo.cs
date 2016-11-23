namespace Mirantis.ReportingToolForInternship.PL.WebUI.Models.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class TypeReportRepo
    {
        private static List<TypeReportVM> allTypes;
        private static List<TypeReportVM> reportsTypes;

        static TypeReportRepo()
        {
            reportsTypes = new List<TypeReportVM>()
            {
                new TypeReportVM()
                {
                    Name = "Daily"
                },
                new TypeReportVM()
                {
                    Name = "Weekly"
                },
            };

            allTypes = new List<TypeReportVM>(reportsTypes);
            allTypes.Add(new TypeReportVM { Name = "All" });
        }

        public static List<TypeReportVM> ReportsTypes
        {
            get { return reportsTypes; }
        }

        public static List<TypeReportVM> AllTypes
        {
            get { return allTypes; }
        }
    }
}