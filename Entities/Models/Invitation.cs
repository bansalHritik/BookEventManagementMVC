using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Invitation
    { 
        [Required]
        public string UserEmail{ get; set; }

        public Event Event;
        public int EventId { get; set; }
    }
}
