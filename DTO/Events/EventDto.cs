using Shared.Constants.Enums;

namespace DTO.Events
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public EventType EventType { get; set; }
    }
}
