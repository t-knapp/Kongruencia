using AutoMapper;
using Server.Controllers.Coverages;
using Server.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AddCoverageResource, Coverage>();
        }
    }
}
