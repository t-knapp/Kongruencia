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
            
            // TODO: Yo, do some mapping stuff.
            CreateMap<coverage, Coverage>()
                .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => src.generated))
                .ForMember(
                    dest => dest.Conditionals,
                    opt => opt.MapFrom(src => new Coverage.Metric(int.Parse(src.project.metrics.conditionals), int.Parse(src.project.metrics.coveredconditionals)))
                )
                .ForMember(
                    dest => dest.Methods,
                    opt => opt.MapFrom(src => new Coverage.Metric(int.Parse(src.project.metrics.methods), int.Parse(src.project.metrics.coveredmethods)))
                )
                .ForMember(
                    dest => dest.Elements,
                    opt => opt.MapFrom(src => new Coverage.Metric(int.Parse(src.project.metrics.elements), int.Parse(src.project.metrics.coveredelements)))
                )
                .ForMember(
                    dest => dest.Statements,
                    opt => opt.MapFrom(src => new Coverage.Metric(int.Parse(src.project.metrics.statements), int.Parse(src.project.metrics.coveredstatements)))
                );
        }
    }

    public class DateTimeTypeConverter : ITypeConverter<string, DateTime>
    {
        public DateTime Convert(string source, DateTime destination, ResolutionContext context)
        {
            return new DateTime(1970, 1, 1).AddMilliseconds(long.Parse(source));
        }
    }
}
