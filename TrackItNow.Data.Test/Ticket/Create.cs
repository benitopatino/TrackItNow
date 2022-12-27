using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using SUT = TrackItNow.Data;

namespace TrackItNow.Data.Test.Ticket
{
    public class Create_Should
    {
        [Theory]
        [ClassData(typeof(TicketTestData))]
        public void ReturnTicket_GivenNormalParameters(NewTicket model)
        {

            // arrange 
            var ticketRepo = new SUT.TicketRepository();

            // act 

            var newTicket = ticketRepo.Create(model);

            // assert
            
            Assert.NotNull(newTicket); // New Ticket is created 
        }

        [Fact]
        public void ThrowAnArgumentNullException_WithNullParameter()
        {
            // arrange

            var ticketRepo = new SUT.TicketRepository();

            // assert 
            //act
            var ex = Assert.Throws<ArgumentNullException>(() => ticketRepo.Create(null));
        }

        [Theory]
        [ClassData(typeof(TicketFailingTestData))]
        public void ThrowSqlException_WithMissingForeignKeyProperties(NewTicket model) 
        {
            // arrange 
            var ticketRepo = new SUT.TicketRepository();

            // act // assert

            var ex = Assert.Throws<SqlException>(() => ticketRepo.Create(model));
        }

    }
}
 