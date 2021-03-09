using AutoMapper;
using DTO.Events;
using Entities.Models;
using Entities.Persistence;
using Shared.Constants.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebBookEventManager.ViewModels;

namespace WebBookEventManager.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            var unitOfWork = new UnitOfWork();

            var pastEvents = new List<EventDto>();
            var upcomingEvents = new List<EventDto>();
            var currentDateTime = DateTime.Now;

            foreach (var evnt in unitOfWork.Events.GetAll())
            {
                if(evnt.Type == EventType.Public)
                {
                    if(evnt.Date < currentDateTime)
                    {
                        pastEvents.Add(Mapper.Map<Event, EventDto>(evnt));
                    }
                    else
                    {
                        upcomingEvents.Add(Mapper.Map<Event, EventDto>(evnt));
                    }
                    
                }
                //else if(!User.Identity.IsAuthenticated)
                //{
                    
                //}
            }

            var viewModel = new HomeViewModel()
            {
                PresentEvents = upcomingEvents,
                PastEvents = pastEvents
            };
            return View(viewModel);
        }
    }
}