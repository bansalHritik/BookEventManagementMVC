using AutoMapper;
using DTO.Events;
using Entities.Models;
using Entities.Persistence;
using Microsoft.AspNet.Identity;
using Shared.Constants.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebBookEventManager.ViewModels;

namespace WebBookEventManager.Controllers.API
{
    public class EventsController : ApiController
    {
        
        UnitOfWork _context;
        public EventsController()
        {
            _context = new UnitOfWork();
        }

        [HttpGet]
        public IHttpActionResult Invited(string id)
        {
            var UserInvited = _context.Invitations.Find(m =>m.UserId==id);
            var invitedEvents = new List<EventDto>();
            foreach(var invitation in UserInvited)
            {
                var evnt = _context.Events.Get(invitation.EventId);
                invitedEvents.Add(Mapper.Map<Event, EventDto>(evnt));
            }
            return Ok(invitedEvents);
        }

        // GET /api/events/1
        [HttpGet]
        public IHttpActionResult UserEvents(string id)
        {
            var userCreatedEvents = _context.Events.Find(m => m.AuthorId == id);
            var temp = userCreatedEvents.Select(m => Mapper.Map<Event, EventDto>(m));
            return Ok(temp);
        }
        
        public IHttpActionResult GetEvents()
        {
            var pastEvents = new List<EventDto>();
            var upcomingEvents = new List<EventDto>();

            var currentDateTime = DateTime.Now;

            foreach (var evnt in _context.Events.GetAll())
            {
                if (evnt.Type == EventType.Private)
                {
                    if (User.Identity.IsAuthenticated)
                    {
                        var userId = User.Identity.GetUserId();
                        var invitations = _context.Invitations
                            .Find(m => (m.UserId == userId && m.EventId == evnt.Id));
                        if (invitations == null && userId != evnt.AuthorId)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                if (evnt.Date < currentDateTime)
                {
                    pastEvents.Add(Mapper.Map<Event, EventDto>(evnt));
                }
                else
                {
                    upcomingEvents.Add(Mapper.Map<Event, EventDto>(evnt));
                }
            }

            var viewModel = new HomeViewModel()
            {
                PresentEvents = upcomingEvents,
                PastEvents = pastEvents
            };
            return Ok(viewModel);
        }

        // POST /api/events
        [HttpPost]
        public IHttpActionResult CreateEvent(EventDto eventDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var comment = Mapper.Map<EventDto, Event>(eventDto);
            _context.Events.Add(comment);
            _context.Complete();
            return Created(new Uri(Request.RequestUri + "/" + eventDto.Id), eventDto);
        }

        // PUT /api/Event/1
        [HttpPut]
        public IHttpActionResult UpdateEvent(int id, EventDto EventDto)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }
            var EventInDB = _context.Events.Find(c => c.Id == id);
            if (EventInDB == null)
            {
                NotFound();
            }
            Mapper.Map(EventDto, EventInDB);
            _context.Complete();
            return Ok();
        }

        // DELETE /api/Events/1
        [HttpDelete]
        public void DeleteEvent(int id)
        {
            var EventInDB = _context.Events.Get(id);
            if (EventInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Events.Remove(EventInDB);
            _context.Complete();
        }
    }
}
