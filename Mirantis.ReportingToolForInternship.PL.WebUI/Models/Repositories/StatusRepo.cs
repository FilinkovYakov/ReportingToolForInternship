namespace Mirantis.ReportingTool.PL.WebUI.Models.Repositories
{
	using System.Collections.Generic;

	public class StatusRepo
    {
        private static List<string> allStatuses;
        private static List<string> taskTypes;

        static StatusRepo()
        {
			allStatuses = new List<string> { "All" };

			taskTypes = new List<string>()
            {
                "Closed", "In development", "Open"
			};

			allStatuses.AddRange(taskTypes);
        }

        public static List<string> AllTypes
        {
            get { return allStatuses; }
        }

        public static List<string> TaskTypes
        {
            get { return taskTypes; }
        }
    }
}