namespace Mirantis.ReportingTool.PL.WebUI.Models.Repositories
{
    using BLL.Contracts;
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

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