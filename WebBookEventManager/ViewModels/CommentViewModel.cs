using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBookEventManager.ViewModels
{
    public class CommentViewModel
    {
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public string Username { get; set; }
    }
}
