namespace Mirantis.ReportingToolForInternship.PL.WebUI.Models.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class ReportRepo
    {
        private static List<ReportVM> repo;

        static ReportRepo()
        {
            repo = new List<ReportVM>()
            {
                new ReportVM()
                {
                    MentorName = UserRepo.Repo[0].Name,
                    InternName = UserRepo.Repo[1].Name,
                    Type = TypeReportRepo.Repo[0].Name,
                    Date = DateTime.Now.AddDays(-3),
                    IsDraft = false,
                    Activities = new List<ActivityVM>()
                    {
                        new ActivityVM()
                        {
                            Description = "Installed Visual Studio 2015",
                            Questions = new List<QuestionVM>()
                            {
                                new QuestionVM()
                                {
                                    Description = "Something bad happened"
                                }
                            }
                        },
                        new ActivityVM()
                        {
                            Description = "Installed Notepad++"
                        }
                    },
                    FuturePlans = new List<FuturePlanVM>()
                    {
                        new FuturePlanVM()
                        {
                            Description = "I'll install Skype"
                        }
                    }
                },

                new ReportVM()
                {
                    MentorName = UserRepo.Repo[0].Name,
                    InternName = UserRepo.Repo[1].Name,
                    Type = TypeReportRepo.Repo[0].Name,
                    Date = DateTime.Now.AddDays(-1),
                    IsDraft = false,
                    Activities = new List<ActivityVM>()
                    {
                        new ActivityVM()
                        {
                            Description = "Installed Resharper",
                            Questions = new List<QuestionVM>()
                            {
                                new QuestionVM()
                                {
                                    Description = "Something bad happened"
                                }
                            }
                        },
                        new ActivityVM()
                        {
                            Description = "Installed Skype"
                        }
                    },
                    FuturePlans = new List<FuturePlanVM>()
                    {
                        new FuturePlanVM()
                        {
                            Description = "I'll install JRE"
                        }
                    }
                },

                new ReportVM()
                {
                    MentorName = UserRepo.Repo[0].Name,
                    InternName = UserRepo.Repo[2].Name,
                    Type = TypeReportRepo.Repo[0].Name,
                    Date = DateTime.Now.AddDays(-2),
                    IsDraft = false,
                    Activities = new List<ActivityVM>()
                    {
                        new ActivityVM()
                        {
                            Description = "Installed JDK",
                            Questions = new List<QuestionVM>()
                            {
                                new QuestionVM()
                                {
                                    Description = "Something bad happened"
                                }
                            }
                        },
                        new ActivityVM()
                        {
                            Description = "Installed IDEA"
                        }
                    },
                    FuturePlans = new List<FuturePlanVM>()
                    {
                        new FuturePlanVM()
                        {
                            Description = "I'll install Maven"
                        }
                    }
                }
            };
        }

        public static List<ReportVM> Repo
        {
            get { return repo; }
        }
    }
}