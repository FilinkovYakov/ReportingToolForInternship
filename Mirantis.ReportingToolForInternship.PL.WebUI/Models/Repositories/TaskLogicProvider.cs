namespace Mirantis.ReportingTool.PL.WebUI.Models.Repositories
{
	using BLL.Contracts;

	public class TaskLogicProvider
    {
        private static ITaskLogic _taskLogic;

        public static ITaskLogic TaskLogic
        {
            get
            {
                return _taskLogic;
            }
            set
            {
				_taskLogic = value;
            }
        }
    }
}