using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackItNow.Models
{
    public class Comment
    {
       public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid AuthorId { get; set; }
        public Guid TicketId { get; set; }
        public DateTime DateCreated { get; set; }

        public Employee Author { get; set; }
        public Ticket Ticket { get; set; }

    }
}
