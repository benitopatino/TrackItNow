using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackItNow.Models;

namespace TrackItNow.Data
{
    public interface ITicketRepository
    {
        Ticket Create(NewTicket newTicket);
        Ticket GetTicketById(string ticketId);
        bool Update(Ticket updateTicket);
        IEnumerable<Ticket> GetTicketsByProject(string projectId);
        IEnumerable<Ticket> GetTicketsByEmployee(string employeeId);

    }
}
