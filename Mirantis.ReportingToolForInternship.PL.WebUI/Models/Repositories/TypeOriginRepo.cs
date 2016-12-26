using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mirantis.ReportingToolForInternship.PL.WebUI.Models.Repositories
{
    public class TypeOriginRepo
    {
        private static List<string> allTypes;
        private static List<string> reportsTypes;

        static TypeOriginRepo()
        {
            allTypes = new List<string> { "All" };

            reportsTypes = new List<string>()
            {
                "Mentor's", "Intern's"
            };

            allTypes.AddRange(reportsTypes);
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