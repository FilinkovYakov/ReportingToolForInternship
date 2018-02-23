namespace Mirantis.ReportingTool.DAL.DataAccessService
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ServiceMapper
    {
        private static IMapper mapper;

        static ServiceMapper()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<AuthenticationService.Role, Entities.Role>();
                c.CreateMap<Entities.Role, AuthenticationService.Role>();

                c.CreateMap<AuthenticationService.User, Entities.User>();
                c.CreateMap<Entities.User, AuthenticationService.User>();
            });
        
            mapper = config.CreateMapper();
        }

        public static IMapper Mapper
        {
            get { return mapper; }
        }
    }
}