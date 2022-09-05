using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackItNow.Data
{
    public class NewTicket
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateDue { get; set; }
        public string EmployeeId { get; set; }
        public byte PriorityId { get; set; }
        public byte TicketStatusId { get; set; }
        public byte TicketTypeId { get; set; }
        public byte TicketResolutionId { get; set; }
        public Guid ProjectId { get; set; }

    }
}
