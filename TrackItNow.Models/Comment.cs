using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackItNow.Models
{
    public class Comment
    {
       public string Id { get; set; }
        public string Content { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid TicketId { get; set; }
        public DateTime DateCreated { get; set; }

        public Employee Employee { get; set; }
        public Ticket Ticket { get; set; }

    }
}
