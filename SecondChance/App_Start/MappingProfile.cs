using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SecondChance.Models;

namespace SecondChance.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<Luser, Luser>();
            });

            IMapper mapper = config.CreateMapper();
            var source = new Luser();
            var dest = mapper.Map<Luser, Luser>(source);
        }
    }
}