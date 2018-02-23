namespace Mirantis.ReportingTool.BLL.Core
{
    using AutoMapper;
    using Entities;

    class BLLAutomapper
    {
        private static IMapper mapper;

        static BLLAutomapper()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Report, RepresentingReport>();
            });

            mapper = config.CreateMapper();
        }

        public static IMapper Mapper
        {
            get { return mapper; }
        }
    }
}
