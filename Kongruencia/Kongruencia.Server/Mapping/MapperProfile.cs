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
            CreateMap<AddCoverageResource, Coverage>();
            CreateMap<Coverage, CoverageResource>();
        }
    }
}
