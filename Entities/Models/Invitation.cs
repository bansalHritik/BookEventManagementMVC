using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Invitation
    { 
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public Event Event { get; set; }
        public int EventId { get; set; }
    }
}
