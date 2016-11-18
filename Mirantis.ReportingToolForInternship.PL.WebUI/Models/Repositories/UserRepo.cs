namespace Mirantis.ReportingToolForInternship.PL.WebUI.Models.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class UserRepo
    {
        private static List<UserVM> repo;

        static UserRepo()
        {
            repo = new List<UserVM>()
            {
                new UserVM()
                {
                    Name = "Alex",
                    Email = "alex@mail.ru"
                },
                new UserVM()
                {
                    Name = "Max",
                    Email = "max@mail.ru"
                },
                new UserVM()
                {
                    Name = "Anton",
                    Email = "anton@mail.ru"
                }
            };
        }

        public static List<UserVM> Repo
        {
            get { return repo; }
        }

    }
}