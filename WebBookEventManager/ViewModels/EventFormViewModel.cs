using Shared.Constants.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBookEventManager.ViewModels
{
    public class EventFormViewModel
    {
        public EventFormViewModel()
        {
            EventType = EventType.Public;
        }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Location { get; set; }

        [Required, Display(Name = "Start Time"), DataType(DataType.Time)]
        public string StartTime { get; set; }

        [Range(0.0, 4.0), Display(Name = "Duration(in hours)")]
        public byte? DurationInHours { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [StringLength(500), Display(Name = "Other Details")]
        public string OtherDetails { get; set; }

        [Display(Name = "Event Type")]
        public EventType EventType { get; set; }
    }
}