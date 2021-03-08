using AutoMapper;
using DTO.Events;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBookEventManager.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Event, EventDto>();
            Mapper.CreateMap<EventDto, Event>();
        }
    }
}