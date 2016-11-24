namespace Mirantis.ReportingToolForInternship.PL.WebUI.Models.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class TypeOccuringRepo
    {
        private static List<string> allTypes;
        private static List<string> reportsTypes;

        static TypeOccuringRepo()
        {
            reportsTypes = new List<string>()
            {
                "Daily", "Weekly"
            };

            allTypes = new List<string>(reportsTypes);
            allTypes.Add("All");
        }

        public static List<string> AllTypes
        {
            get { return allTypes; }
        }

        public static List<string> ReportsTypes
        {
            get { return reportsTypes; }
        }
    }
}