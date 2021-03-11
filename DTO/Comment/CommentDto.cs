using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int EventId { get; set; }
    }
}
