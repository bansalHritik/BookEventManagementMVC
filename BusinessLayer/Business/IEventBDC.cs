using DTO.Events;
using Shared.Infrastructure.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Business
{
    public interface IEventBDC
    {
        IOperationResult GetAllEvents(int id);
        IOperationResult AddEvent(EventDto eventDto);
        IOperationResult DeleteEvent(EventDto eventDto);
        IOperationResult GetEventWithId(int id);
        IOperationResult EditEvent(int id, EventDto eventDto);
        IOperationResult SaveEvent(EventDto eventDto);
        IOperationResult GetAllUserCreatedEvents(EventDto eventDto);
        IOperationResult GetDetails(int id);
        IOperationResult GetInvitaionEvents(string userId);
    }
}
