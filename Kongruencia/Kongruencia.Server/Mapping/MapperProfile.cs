using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kongruencia.Server {

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<string, DateTime>().ConvertUsing(new DateTimeTypeConverter());
            CreateMap<projectMetrics, Metrics>();
            CreateMap<AddCoverageResource, Coverage>()
                .ForMember(dest => dest.Metrics, opt => opt.MapFrom(src => src.Coverage.project.metrics))
                .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => src.Coverage.generated));
            CreateMap<Coverage, CoverageResource>();
            CreateMap<Coverage, BranchResource>();
        }
    }

    public class DateTimeTypeConverter : ITypeConverter<string, DateTime>
    {
        public DateTime Convert(string source, DateTime destination, ResolutionContext context)
        {
            return new DateTime(1970, 1, 1).AddMilliseconds(Int64.Parse(source));
        }
    }
}
