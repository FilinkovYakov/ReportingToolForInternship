namespace Mirantis.ReportingToolForInternship.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class User
    {
        public int Id { get; set; }

        public int ExternalId { get; set; }

        public string Login { get; set; }

        public string FullName { get; set; }

        public virtual IList<Role> Roles { get; set; }
    }
}
