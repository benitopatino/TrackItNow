using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackItNow.Models
{
    public class Ticket
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string EmployeeId { get; set; }
        public byte PriorityId { get; set; }
        public byte TicketStatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DateDue { get; set; }
        public byte TicketTypeId { get; set; }
        public byte TicketResolutionId { get; set; }
        public string ProjectId { get; set; }


        public Employee Employee { get; set; }
        public Priority Priority { get; set; }
        public TicketStatus Status { get; set; }
        public TicketType Type { get; set; }
        public TicketResolution Resolution { get; set; }
        public Project Project { get; set; }
    }
}
