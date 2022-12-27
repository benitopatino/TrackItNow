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
            if (newTicket == null)
                throw new ArgumentNullException(nameof(newTicket));

            string sql = @"Insert Into Ticket (Id, Title, Description, EmployeeId, CreatedDate, DateDue, PriorityId, TicketStatusId, TicketTypeId, ProjectId ) 
                                    Values (@pId,@pTitle, @pDescription, @pEmployeeId, @pCreatedDate,@pDateDue, @pPriorityId, @pTicketStatusId, @pTicketTypeId, @pProjectId)";

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
                ProjectId = Guid.Parse(newTicket.ProjectId),
                EmployeeId = Guid.Parse(newTicket.EmployeeId),
                CreatedDate = DateTime.Now,
                DateDue = newTicket.DateDue
            };

            cmd.Parameters.Add("@pId", SqlDbType.UniqueIdentifier).Value = Guid.NewGuid();
            cmd.Parameters.Add("@pTitle", SqlDbType.VarChar).Value = ticket.Title;
            cmd.Parameters.Add("@pTicketStatusId", SqlDbType.TinyInt).Value = ticket.TicketStatusId;
            cmd.Parameters.Add("@pTicketTypeId", SqlDbType.TinyInt).Value = ticket.TicketTypeId;
            cmd.Parameters.Add("@pDescription", SqlDbType.VarChar).Value = ticket.Description;
            cmd.Parameters.Add("@pPriorityId", SqlDbType.TinyInt).Value = ticket.PriorityId;
            cmd.Parameters.Add("@pProjectId", SqlDbType.UniqueIdentifier).Value = ticket.ProjectId;
            cmd.Parameters.Add("@pEmployeeId", SqlDbType.UniqueIdentifier).Value = ticket.EmployeeId;
            cmd.Parameters.Add("@pCreatedDate", SqlDbType.DateTime).Value = ticket.CreatedDate;
            cmd.Parameters.Add("@pDateDue", SqlDbType.DateTime).Value = ticket.DateDue;

            cmd.ExecuteNonQuery();
            con.Close();

            return ticket;



        }
        public bool Update(Ticket updateTicket)
        {
            string sql = @"
                Update Ticket Set Title =@pTitle, Description = @pDescription, DateDue = @pDateDue, EmployeeId = @pEmployeeId,
                PriorityId = @pPriorityId, TicketStatusId = @pTicketStatusId, TicketTypeId = @pTicketTypeId, TicketResolutionId = @pTicketResolutionId,
                ProjectId = @pProjectId
                where Id = @pUpdateTicketId
            ";

            SqlConnection con = new SqlConnection(DbSettings.ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@pUpdateTicketId", SqlDbType.UniqueIdentifier).Value = Guid.Parse(updateTicket.Id);

            cmd.Parameters.Add("@pTitle", SqlDbType.VarChar).Value = updateTicket.Title;
            cmd.Parameters.Add("@pDescription", SqlDbType.VarChar).Value = updateTicket.Description;
            cmd.Parameters.Add("@pDateDue", SqlDbType.DateTime).Value = updateTicket.DateDue;
            cmd.Parameters.Add("@pEmployeeId", SqlDbType.UniqueIdentifier).Value = updateTicket.EmployeeId;
            cmd.Parameters.Add("@pPriorityId", SqlDbType.TinyInt).Value = updateTicket.PriorityId;
            cmd.Parameters.Add("@pTicketStatusId", SqlDbType.TinyInt).Value = updateTicket.TicketStatusId;
            cmd.Parameters.Add("@pTicketTypeId", SqlDbType.TinyInt).Value = updateTicket.TicketTypeId;
            cmd.Parameters.Add("@pTicketResolutionId", SqlDbType.TinyInt).Value = updateTicket.TicketResolutionId;
            cmd.Parameters.Add("@pProjectId", SqlDbType.UniqueIdentifier).Value = updateTicket.ProjectId;

            int changedRows = cmd.ExecuteNonQuery();
            con.Close();

            return changedRows > 0;
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
                ticket.EmployeeId = reader.GetGuid("EmployeeId");
                ticket.PriorityId = reader.GetByte("PriorityId");
                ticket.TicketStatusId = reader.GetByte("TicketStatusId");
                ticket.TicketTypeId = reader.GetByte("TicketTypeId");
                ticket.TicketResolutionId = reader.GetByte("TicketResolutionId");
                ticket.ProjectId = reader.GetGuid("ProjectId");
            }

            con.Close();

            return ticket;
        }
        public IEnumerable<Ticket> GetTicketsByProject(string projectId)
        {
            string sql = @"Select * from Ticket where ProjectId = @pProjectId";
            IList<Ticket> tickets = new List<Ticket>();
            SqlConnection con = new SqlConnection(DbSettings.ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@pProjectId", SqlDbType.UniqueIdentifier).Value = Guid.Parse(projectId);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Ticket ticket = new Ticket();
                ticket.Id = reader.GetGuid("Id").ToString();
                ticket.Title = reader.GetString("Title");
                ticket.Description = reader.GetString("Description");
                ticket.CreatedDate = reader.GetDateTime("CreatedDate");
                ticket.DateDue = reader.GetDateTime("DateDue");
                ticket.EmployeeId = reader.GetGuid("EmployeeId");
                ticket.PriorityId = reader.GetByte("PriorityId");
                ticket.TicketStatusId = reader.GetByte("TicketStatusId");
                ticket.TicketTypeId = reader.GetByte("TicketTypeId");
                ticket.TicketResolutionId = reader.GetByte("TicketResolutionId");
                ticket.ProjectId = reader.GetGuid("ProjectId");

                tickets.Add(ticket);
            }

            con.Close();

            return tickets;
        }
        public IEnumerable<Ticket> GetTicketsByEmployee(string employeeId)
        {
            string sql = @"Select * from Ticket where EmployeeId = @pEmployeeId";
            IList<Ticket> tickets = new List<Ticket>();
            SqlConnection con = new SqlConnection(DbSettings.ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@pEmployeeId", SqlDbType.UniqueIdentifier).Value = Guid.Parse(employeeId);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Ticket ticket = new Ticket();
                ticket.Id = reader.GetGuid("Id").ToString();
                ticket.Title = reader.GetString("Title");
                ticket.Description = reader.GetString("Description");
                ticket.CreatedDate = reader.GetDateTime("CreatedDate");
                ticket.DateDue = reader.GetDateTime("DateDue");
                ticket.EmployeeId = reader.GetGuid("EmployeeId");
                ticket.PriorityId = reader.GetByte("PriorityId");
                ticket.TicketStatusId = reader.GetByte("TicketStatusId");
                ticket.TicketTypeId = reader.GetByte("TicketTypeId");
                ticket.TicketResolutionId = reader.GetByte("TicketResolutionId");
                ticket.ProjectId = reader.GetGuid("ProjectId");

                tickets.Add(ticket);
            }

            con.Close();

            return tickets;
        }
    }
}
