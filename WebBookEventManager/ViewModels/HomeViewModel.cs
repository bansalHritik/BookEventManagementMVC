using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO.Events;


namespace WebBookEventManager.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<EventDto> Events { get; set; }
    }
}