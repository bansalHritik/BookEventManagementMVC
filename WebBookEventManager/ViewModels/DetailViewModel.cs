using DTO.Comment;
using DTO.Events;
using System.Collections.Generic;

namespace WebBookEventManager.ViewModels
{
    public class DetailViewModel
    {
        public EventDto Event { get; set; }
        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}