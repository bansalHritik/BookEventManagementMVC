using AutoMapper;
using DTO.Events;
using Entities.Models;
using Entities.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBookEventManager.Controllers
{
    public class EventsController : Controller
    {
        // GET: Events

        public ActionResult Create()
        {
            return View("EventForm");
        }

        public ActionResult Save(EventDto eventDto)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }
            var unitOfWork = new UnitOfWork();
            var eventModel = Mapper.Map<EventDto, Event>(eventDto);
            var events = unitOfWork.Events.GetAll();
            unitOfWork.Events.Add(eventModel);
            unitOfWork.Complete();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Manage()
        {
            return View();
        }

        public ActionResult Detail(int id)
        {
            var unitOfWork = new UnitOfWork();
            var eventInDB = unitOfWork.Events.Get(id);
            return View(Mapper.Map<Event, EventDto>(eventInDB));
        }
    }
}