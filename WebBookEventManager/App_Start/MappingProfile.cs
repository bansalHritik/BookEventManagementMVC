using AutoMapper;
using DTO.Comment;
using DTO.Events;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBookEventManager.ViewModels;

namespace WebBookEventManager.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Event, EventDto>();
            Mapper.CreateMap<EventDto, Event>();

            Mapper.CreateMap<Comment, CommentDto>()
                    .ForMember(dest => dest.Comment, 
                                opt => opt.MapFrom(src => src.Content)
                     );
            Mapper.CreateMap<CommentDto, Comment>()
                    .ForMember(dest => dest.Content, 
                                opt => opt.MapFrom(src => src.Comment));


            Mapper.CreateMap<Event, EventFormViewModel>();
            Mapper.CreateMap<EventFormViewModel, Event>();


            Mapper.CreateMap<Event, Event>();
        }
    }
}