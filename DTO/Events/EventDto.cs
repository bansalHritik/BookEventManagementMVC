using Shared.Constants.Enums;
using System;

namespace DTO.Events
{
    public class EventDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }

        public DateTime StartTime { get; set; }

        public byte Duration { get; set; }

        public string Description { get; set; }

        public string OtherDetails { get; set; }

        public EventType EventType { get; set; }
    }
}
