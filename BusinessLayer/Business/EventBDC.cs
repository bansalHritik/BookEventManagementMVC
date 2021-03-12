using DTO.Events;
using Entities.Models;
using Entities.Persistence;
using Shared.Infrastructure.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Business
{
    public class EventBDC : BDC<Event>, IEventBDC
    {
        public IOperationResult AddEvent(EventDto eventDto)
        {
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
        }

        public IOperationResult DeleteEvent(EventDto eventDto)
        {
            throw new NotImplementedException();
        }

        public IOperationResult EditEvent(int id, EventDto eventDto)
        {
            throw new NotImplementedException();
        }

        public IOperationResult GetAllEvents(int id)
        {
            throw new NotImplementedException();
        }

        public IOperationResult GetAllUserCreatedEvents(EventDto eventDto)
        {
            throw new NotImplementedException();
        }

        public IOperationResult GetDetails(int id)
        {
            throw new NotImplementedException();
        }

        public IOperationResult GetEventWithId(int id)
        {
            throw new NotImplementedException();
        }

        public IOperationResult GetInvitaionEvents(string userId)
        {
            throw new NotImplementedException();
        }

        public IOperationResult SaveEvent(EventDto eventDto)
        {
            throw new NotImplementedException();
        }
    }
}
