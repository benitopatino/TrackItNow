using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackItNow.Models;
using Xunit;

namespace TrackItNow.Data.Test
{
    public class TicketRepositoryTest
    {
        [Theory]
        [InlineData("Ticket Number 3", 1, 4, 3, "This is ticket number 3.", 2, "503E2D5E-F9E2-4421-8B7D-9297F3AA8EE1", "C2D0195B-C5A5-4A24-8D1A-CC2780F6F797", "2022-09-11")]
        [InlineData("Ticket Number 4", 2, 1, 1, "This is ticket number 4.", 1, "77B7408D-5A86-4925-B993-C86B97C8F1B0", "BDADBFC4-6487-4BAC-B0D8-BAEB2CCDDD6C", "2022-03-21")]
        [InlineData("Ticket Number 5", 3, 3, 2, "This is ticket number 5.", 3, "503E2D5E-F9E2-4421-8B7D-9297F3AA8EE1", "C2D0195B-C5A5-4A24-8D1A-CC2780F6F797", "2022-06-21")]
        [InlineData("Ticket Number 6", 1, 2, 1, "This is ticket number 6.", 3, "77B7408D-5A86-4925-B993-C86B97C8F1B0", "BDADBFC4-6487-4BAC-B0D8-BAEB2CCDDD6C", "2022-12-21")]
        public void CreateTicketTest(string Title, byte TicketResolutionId, byte TicketStatusId, byte TicketTypeId, string Description, byte PriorityId, string EmployeeId, string ProjectId, string DueDate)
        {
            TicketRepository ticketRepository = new TicketRepository();

            NewTicket newTicket = new NewTicket()
            {
                Title = Title,
                TicketResolutionId = TicketResolutionId,
                TicketStatusId = TicketStatusId,
                TicketTypeId = TicketTypeId,
                Description = Description,
                PriorityId = PriorityId,
                EmployeeId = EmployeeId,
                ProjectId = ProjectId,
                DateDue = DateTime.Parse(DueDate)
            };

            var ticket = ticketRepository.Create(newTicket);

            Assert.IsType<Ticket>(ticket);

            Assert.Equal(newTicket.Title, ticket.Title);
            Assert.Equal(newTicket.TicketResolutionId, ticket.TicketResolutionId);
            Assert.Equal(newTicket.TicketStatusId, ticket.TicketStatusId);
            Assert.Equal(newTicket.TicketTypeId, ticket.TicketTypeId);
            Assert.Equal(newTicket.Description, ticket.Description);
            Assert.Equal(newTicket.PriorityId, ticket.PriorityId);
            Assert.Equal(newTicket.EmployeeId, ticket.EmployeeId);
            Assert.Equal(newTicket.ProjectId, ticket.ProjectId);
        }


        [Theory]
        [InlineData("F8C1E2EF-F4B4-44AC-8864-94B2F6F9D956")]
        public void GetTicketByIdTest(string ticketId)
        {
            TicketRepository ticketRepository = new TicketRepository();
            var ticket = ticketRepository.GetTicketById(ticketId);

            Assert.Equal("Ticket Number 6", ticket.Title);
        }


        [Theory]
        [InlineData("BDADBFC4-6487-4BAC-B0D8-BAEB2CCDDD6C")]
        public void GetTicketsByProjectTest(string projectId)
        {
            TicketRepository ticketRepository = new TicketRepository();
            var tickets = ticketRepository.GetTicketsByProject(projectId);


            Assert.Equal(14, tickets.Count());
        }

        [Theory]
        [InlineData("503E2D5E-F9E2-4421-8B7D-9297F3AA8EE1")]
        public void GetTicketByEmployeeId(string employeeId)
        {
            TicketRepository ticketRepository = new TicketRepository();
            var tickets = ticketRepository.GetTicketByEmployee(employeeId);

            Assert.Equal(14, tickets.Count());
        }


    }
}
