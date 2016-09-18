using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SecondChance.Dtos;
using SecondChance.Models;

namespace SecondChance.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Job, Job>();
            Mapper.CreateMap<Job, JobDto>();
            Mapper.CreateMap<JobDto, Job>();
            Mapper.CreateMap<Luser, LuserDto>();
            Mapper.CreateMap<LuserDto, Luser>();
            Mapper.CreateMap<Employer, EmployerDto>();
            Mapper.CreateMap<EmployerDto, Employer>();
        }
    }
}