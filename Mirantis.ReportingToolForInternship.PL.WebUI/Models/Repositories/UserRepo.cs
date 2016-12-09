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
                    Id = 0,
                    Name = "Alex",
                    Login = "alex@mail.ru"
                },
                new UserVM()
                {
                    Id = 1,
                    Name = "Max",
                    Login = "max@mail.ru"
                },
                new UserVM()
                {
                    Id = 2,
                    Name = "Anton",
                    Login = "anton@mail.ru"
                }
            };
        }

        public static List<UserVM> Repo
        {
            get { return repo; }
        }


        public static UserVM GetById (int? id)
        {
            return Repo.FirstOrDefault(user => user.Id == id) ?? new UserVM() { Name = "" };
        }
    }
}