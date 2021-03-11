using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Comment
    {
        public int Id { get; set; }
        
        public Event Event { get; set; }
        public int EventId { get; set; }

        [StringLength(255)]
        public string Content { get; set; }
    }
}
