﻿namespace Mirantis.ReportingToolForInternship.DAL.DataAccessEF
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CustomDBContext : DbContext
    {
        public CustomDBContext()
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<CustomDBContext>());
        }

        public CustomDBContext(string connString) : base(connString)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<CustomDBContext>());
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<FuturePlan> FuturePlans { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}
