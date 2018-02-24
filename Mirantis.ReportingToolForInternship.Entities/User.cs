namespace Mirantis.ReportingTool.Entities
{
	using System.Collections.Generic;

	public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string FullName { get; set; }

        public virtual IList<Role> Roles { get; set; }
    }
}