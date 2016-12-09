namespace Mirantis.ReportingToolForInternship.DAL.DataAccessService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DataServiceMapperInitializer
    {
        public void Initialize()
        {
            AutoMapper.Mapper.Initialize(c =>
            {
                c.CreateMap<DAL.DataAccessService.AuthenticationService.User, Entities.User>();
                c.CreateMap<Entities.User, DAL.DataAccessService.AuthenticationService.User>();

                c.CreateMap<DAL.DataAccessService.AuthenticationService.Role, Entities.Role>();
                c.CreateMap<Entities.Role, DAL.DataAccessService.AuthenticationService.Role>();
            });
        }
    }
}
