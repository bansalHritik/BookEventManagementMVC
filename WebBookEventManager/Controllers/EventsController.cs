using AutoMapper;
using DTO.Comment;
using DTO.Events;
using Entities.Models;
using Entities.Persistence;
using Microsoft.AspNet.Identity;
using Shared.Constants.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebBookEventManager.ViewModels;

namespace WebBookEventManager.Controllers
{
    public class EventsController : Controller
    {
        // GET: Events
        [Authorize] // will return event form view
        public ActionResult Create()
        {
            return View("EventForm", new EventFormViewModel());
        }

        // will get event from db and pass it to the form.
        public ActionResult Edit(int id)
        {
            var db = new UnitOfWork();
            var eventInDb = db.Events.Get(id);
            if (eventInDb == null)
            {
                return HttpNotFound("Can't edit a non existing event.");
            }
            var defaultValues = Mapper.Map<Event, EventFormViewModel>(eventInDb);
            return View("EventForm", defaultValues);

        }

        [ValidateAntiForgeryToken, HttpPost]
        public ActionResult Save(EventDto eventDto)
        {
            if (!ModelState.IsValid)
            {
                return View("EventForm", new EventFormViewModel());
            }
            var db = new UnitOfWork();
            if (eventDto.Id != 0)
            {
                var eventInDb = db.Events.Get(eventDto.Id);
                db.Events.Remove(eventInDb);
                var newEvent = Mapper.Map<EventDto, Event>(eventDto);
                newEvent.AuthorId = eventInDb.AuthorId;
                db.Events.Add(newEvent);
            }
            else
            {
                var userID = User.Identity.GetUserId();
                var newEvent = new Event() { AuthorId = userID };
                var eventModel = Mapper.Map(eventDto, newEvent);
                db.Events.Add(eventModel);
            }
            db.Complete();
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Manage()
        {
            var db = new UnitOfWork();
            var currentUserId = User.Identity.GetUserId();
            var userCreatedEvents = db.Events.Find(m => m.AuthorId == currentUserId);
            var temp = userCreatedEvents.Select(m => Mapper.Map<Event, EventDto>(m));
            return View(temp);
        }

        public ActionResult All()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Detail(int id)
        {
            var unitOfWork = new UnitOfWork();
            var eventInDB = unitOfWork.Events.Get(id);
            var comments = new List<CommentDto>();
            foreach (var item in unitOfWork.Comments.Find(m => m.EventId == id))
            {
                comments.Add(new CommentDto()
                {
                    Comment = item.Content,
                });
            }
            if (User.Identity.IsAuthenticated && eventInDB.Type == EventType.Private || eventInDB.Type == EventType.Public)
            {
                var viewModel = new DetailViewModel()
                {
                    Comments = comments,
                    Event = Mapper.Map<Event, EventDto>(eventInDB),
                };
                return View(viewModel);
            }

            return RedirectToAction("Login", "Account");
        }

        public ActionResult Invited()
        {
            var unitOfWork = new UnitOfWork();
            var currentUserEmail = User.Identity.GetUserId();
            var userInvitationsInDB = unitOfWork.Invitations.Find(m => m.UserEmail == currentUserEmail);
            var invitations = new List<EventDto>();
            foreach (var invite in userInvitationsInDB)
            {
                var eventInDb = unitOfWork.Events.Get(invite.EventId);
                invitations.Add(Mapper.Map<Event, EventDto>(eventInDb));
            }
            return View(invitations);
        }
    }
}