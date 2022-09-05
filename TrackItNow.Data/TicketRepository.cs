using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
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
            string sql = @"Insert Into Ticket (Title, Description, EmployeeId, CreatedDate, DateDue, PriorityId, TicketStatusId, TicketTypeId, TicketResolutionId, ProjectId ) 
                                    Values (@pTitle, @pDescription, @pEmployeeId, @pCreatedDate,@pDateDue, @pPriorityId, @pTicketStatusId, @pTicketTypeId, @pTicketResolutionId, @pProjectId)";
            
            SqlConnection con = new SqlConnection(DbSettings.ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand(sql, con);

            var ticket = new Ticket()
            {
                Title = newTicket.Title,
                TicketResolutionId = newTicket.TicketResolutionId,
                TicketStatusId = newTicket.TicketStatusId,
                TicketTypeId = newTicket.TicketTypeId,
                Description = newTicket.Description,
                PriorityId = newTicket.PriorityId,
                ProjectId = newTicket.ProjectId,
                EmployeeId = newTicket.EmployeeId,
                CreatedDate = DateTime.Now,
                DateDue = newTicket.DateDue
            };

            cmd.Parameters.Add("@pTitle", SqlDbType.VarChar).Value = ticket.Title;
            cmd.Parameters.Add("@pTicketResolutionId", SqlDbType.SmallInt).Value = ticket.TicketResolutionId;
            cmd.Parameters.Add("@pTicketStatusId", SqlDbType.SmallInt).Value = ticket.TicketStatusId;
            cmd.Parameters.Add("@pTicketTypeId", SqlDbType.SmallInt).Value = ticket.TicketTypeId;
            cmd.Parameters.Add("@pDescription", SqlDbType.VarChar).Value = ticket.Description;
            cmd.Parameters.Add("@pPriorityId", SqlDbType.SmallInt).Value = ticket.PriorityId;
            cmd.Parameters.Add("@pProjectId", SqlDbType.UniqueIdentifier).Value = Guid.Parse(ticket.ProjectId);
            cmd.Parameters.Add("@pEmployeeId", SqlDbType.UniqueIdentifier).Value = Guid.Parse(ticket.EmployeeId);
            cmd.Parameters.Add("@pCreatedDate", SqlDbType.DateTime).Value = ticket.CreatedDate;
            cmd.Parameters.Add("@pDateDue", SqlDbType.DateTime).Value = ticket.DateDue; 

            cmd.ExecuteNonQuery();
            con.Close();

            return ticket;
        }

        public Ticket GetTicketById(string ticketId)
        {
            string sql = @"Select * from Ticket where Id = @pTicketId";
            Ticket ticket = new Ticket();

            SqlConnection con = new SqlConnection(DbSettings.ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@pTicketId", SqlDbType.UniqueIdentifier).Value = Guid.Parse(ticketId);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ticket.Id = reader.GetGuid("Id").ToString();
                ticket.Title = reader.GetString("Title");
                ticket.Description = reader.GetString("Description");
                ticket.CreatedDate = reader.GetDateTime("CreatedDate");
                ticket.DateDue = reader.GetDateTime("DateDue");
                ticket.EmployeeId = reader.GetGuid("EmployeeId").ToString();
                ticket.PriorityId = reader.GetByte("PriorityId");
                ticket.TicketStatusId = reader.GetByte("TicketStatusId");
                ticket.TicketTypeId = reader.GetByte("TicketTypeId");
                ticket.TicketResolutionId = reader.GetByte("TicketResolutionId");
                ticket.ProjectId = reader.GetGuid("ProjectId").ToString();
            }

            con.Close();

            return ticket;
        }
    }
}
