using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackItNow.Models;

namespace TrackItNow.Data
{
    public class TicketRepository : ITicketRepository
    {
        public Ticket Create(NewTicket newTicket)
        {
            var ticket = new Ticket()
            {
                Id = new Guid(),
                Title = newTicket.Title,
                TicketResolutionId = newTicket.TicketResolutionId,
                TicketStatusId = newTicket.TicketStatusId,
                TicketTypeId = newTicket.TicketTypeId,
                Description = newTicket.Description,
                PriorityId = newTicket.PriorityId,
                ProjectId = newTicket.ProjectId,
                EmployeeId = newTicket.EmployeeId,
                CreatedDate = DateTime.Now,
                DateDue = newTicket.DueDate
            };


            string sqlStatement = "Insert Into Ticket (Title, Description, ) Values('Walter')";
            
            SqlConnection con = new SqlConnection(DbSettings.ConnectionString);
            con.Open();


            SqlCommand sqlCommand = new SqlCommand(sql, con);
            sqlCommand.ExecuteNonQuery();
            con.Close();


            return ticket;
        }
    }
}
