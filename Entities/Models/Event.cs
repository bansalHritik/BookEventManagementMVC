using System;
using Shared.Constants.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Event
    {
        public Event()
        {
            EventType = EventType.Public;
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Location { get; set; }

        //TODO: Start time 

        [Required]
        public EventType EventType { get; set; }
        
        public byte? Duration { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [StringLength(500)]
        public string OtherDetails { get; set; }

        public IEnumerable<string> EmailInvites { get; set; }
    }
}
