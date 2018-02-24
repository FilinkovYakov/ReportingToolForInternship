namespace Mirantis.ReportingTool.PL.WebUI.Models.Repositories
{
	using BLL.Contracts;

	public class ProjectLogicProvider
    {
        private static IProjectLogic _projectLogic;

        public static IProjectLogic ProjectLogic
        {
            get
            {
                return _projectLogic;
            }
            set
            {
				_projectLogic = value;
            }
        }
    }
}