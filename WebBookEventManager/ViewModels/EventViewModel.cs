using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBookEventManager.ViewModels
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string StartTime { get; set; }
        public string Description { get; set; }
    }
}