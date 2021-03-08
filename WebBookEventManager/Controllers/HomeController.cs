using AutoMapper;
using DTO.Events;
using Entities.Models;
using Entities.Persistence;
using System.Collections.Generic;
using System.Web.Mvc;
using WebBookEventManager.ViewModels;

namespace WebBookEventManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var unitOfWork = new UnitOfWork();
            var events = new List<EventDto>();
            foreach (var eventInDb in unitOfWork.Events.GetAll())
            {
                events.Add(Mapper.Map<Event, EventDto>(eventInDb));
            }

            var viewModel = new HomeViewModel()
            {
                Events = events,
            };
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}