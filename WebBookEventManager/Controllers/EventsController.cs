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
using WebBookEventManager.Models;
using WebBookEventManager.ViewModels;

namespace WebBookEventManager.Controllers
{
    public class EventsController : Controller
    {

        // GET: Events
        // will return event form view
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
            var userTable = new ApplicationDbContext().Users;
            var defaultValues = Mapper.Map<Event, EventFormViewModel>(eventInDb);
            var invities = db.Invitations.Find(m => m.EventId == id);
            string commaSeperatedUser = "";
            foreach (var invitation in invities)
            {
                commaSeperatedUser += userTable.Find(invitation.UserId).Email+ ", ";
            }
            defaultValues.EmailInvities = commaSeperatedUser;
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
            var newEvent = new Event();
            if (eventDto.Id != 0)
            {
                var eventInDb = db.Events.Get(eventDto.Id);
                db.Events.Remove(eventInDb);
            }

            var userID = User.Identity.GetUserId();
            newEvent.AuthorId = userID;
            newEvent = Mapper.Map(eventDto, newEvent);
            db.Events.Add(newEvent);
            db.Complete();

            db.Invitations.RemoveRange(db.Invitations.Find(m => m.EventId == eventDto.Id));
            db.Complete();

            if (eventDto.EmailInvities != null)
            {
                var invities = eventDto.EmailInvities.Split(',');
                
                foreach (var item in invities)
                {
                    var userEmail = item.Trim();
                    var user = new ApplicationDbContext().Users.FirstOrDefault(m => m.Email == userEmail);
                    if (user != null)
                    {
                        db.Invitations.Add(new Invitation()
                        {
                            EventId = newEvent.Id,
                            UserId = user.Id,
                        });
                    }
                    db.Complete();
                }
            }
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


        [AllowAnonymous]
        public ActionResult Detail(int id)
        {
            var unitOfWork = new UnitOfWork();
            var eventDetail = unitOfWork.Events.Get(id);
            var comments = new List<CommentViewModel>();
            var userDb = new ApplicationDbContext().Users;

            foreach (var item in unitOfWork.Comments.Find(m => m.EventId == id))
            {
                var comment = Mapper.Map<Comment, CommentViewModel>(item);
                var userEmail = userDb.Find(item.UserId).Email;
                comment.Username = userEmail;
                comments.Add(comment);
            }

            bool isUserInvited = false;
            if (User.Identity.IsAuthenticated
                && unitOfWork.Invitations.Find(m => m.UserId == User.Identity.GetUserId()
                && m.EventId == id) != null)
            {
                isUserInvited = true;
            }
            var canUserViewDetails = eventDetail.Type == EventType.Private && isUserInvited;
            if (eventDetail.Type == EventType.Public || canUserViewDetails)
            {
                var viewModel = new DetailViewModel()
                {
                    Comments = comments,
                    Event = Mapper.Map<Event, EventDto>(eventDetail),
                };
                return View(viewModel);
            }

            return RedirectToAction("Login", "Account");
        }

        public ActionResult Invited()
        {
            var unitOfWork = new UnitOfWork();
            var currentUserEmail = User.Identity.GetUserId();
            var userInvitationsInDB = unitOfWork.Invitations.Find(m => m.UserId == currentUserEmail);
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