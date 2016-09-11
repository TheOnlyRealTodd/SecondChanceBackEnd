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
            Mapper.CreateMap<Job, Job>();
        }
    }
}