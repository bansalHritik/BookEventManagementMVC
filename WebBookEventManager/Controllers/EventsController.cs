using AutoMapper;
using DTO.Events;
using Entities.Models;
using Entities.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBookEventManager.ViewModels;
using Microsoft.AspNet.Identity;
using Shared.Constants.Enums;

namespace WebBookEventManager.Controllers
{
    public class EventsController : Controller
    {
        // GET: Events
        [Authorize]
        public ActionResult Create()
        {
            return View("EventForm");
        }

        public ActionResult Edit(int id)
        {
            var viewModel = new EventFormViewModel();
            return View("EventForm", viewModel);
        }

        [ValidateAntiForgeryToken, HttpPost]
        public ActionResult Save(EventDto eventDto)
        {
            var userID = User.Identity.GetUserId();
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }
            var unitOfWork = new UnitOfWork();
            var newEvent = new Event()
            {
                AuthorId = User.Identity.GetUserId(),
            };
            var eventModel = Mapper.Map(eventDto, newEvent);
            var events = unitOfWork.Events.GetAll();
            unitOfWork.Events.Add(eventModel);
            unitOfWork.Complete();
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
            var eventInDB = unitOfWork.Events.Get(id);
            unitOfWork.Comments.Add(new Comment()
            {
                Content = "sdkfjksbdsjbkd sdfsd sdsndfsdn sdm",
                EventId = id,
            });
            unitOfWork.Complete();
            if (User.Identity.IsAuthenticated && eventInDB.Type == EventType.Private || eventInDB.Type == EventType.Public)
            {
                return View(Mapper.Map<Event, EventDto>(eventInDB));
            }
           
            return RedirectToAction("Login", "Account");
        }
    }
}