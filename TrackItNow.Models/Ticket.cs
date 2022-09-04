using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackItNow.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid EmployeeId { get; set; }
        public byte PriorityId { get; set; }
        public byte TicketStatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DateDue { get; set; }
        public byte TicketTypeId { get; set; }
        public byte TicketResolutionId { get; set; }
        public byte ProjectId { get; set; }


        public Employee Employee { get; set; }
        public Priority Priority { get; set; } // Done
        public TicketStatus Status { get; set; } // done
        public TicketType Type { get; set; } // done
        public TicketResolution Resolution { get; set; } // dfonr
        public Project Project { get; set; }
    }
}
