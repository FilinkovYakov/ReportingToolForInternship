namespace Mirantis.ReportingTool.PL.WebUI.Models.Repositories
{
	using BLL.Contracts;

	public class UserLogicProvider
    {
        private static IUserLogic _userLogic;

        public static IUserLogic UserLogic
        {
            get
            {
                return _userLogic;
            }
            set
            {
                _userLogic = value;
            }
        }
    }
}