using DTO.DTO;
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
        public ActionResult Index()
        {
            return View();
        }

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
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Manage()
        {
            return View();
        }

        public ActionResult Detail(int id)
        {
            return View();
        }
    }
}