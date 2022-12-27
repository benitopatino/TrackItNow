using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackItNow.Data.Test.Ticket
{
    public class TicketTestData : IEnumerable<object[]>
    {

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new NewTicket()
                {
                    Title = "Ticket New 1",
                    Description = "Ticket 1 description" ,
                    DateDue = new DateTime(2023,05,12),
                    EmployeeId = "3396543A-204E-4A52-B58E-BB47470ECC64", // Test Employee 1
                    PriorityId = 1, // low priority
                    TicketStatusId = 1,// ticket status = new
                    TicketTypeId = 1, // bug fix
                    ProjectId = "E86D69B8-8F50-4477-82A7-F41E023A018B" // Test Project 1
                }
            };
            yield return new object[]
            {
                new NewTicket()
                {
                    Title = "Ticket New 2",
                    Description = "Ticket 2 description" ,
                    DateDue = new DateTime(2023,11,12),
                    EmployeeId = "3396543A-204E-4A52-B58E-BB47470ECC64", // Test Employee 1
                    PriorityId = 2, // medium priority
                    TicketStatusId = 1,// ticket status = new
                    TicketTypeId = 2, // feature fix
                    ProjectId = "E86D69B8-8F50-4477-82A7-F41E023A018B" // Test Project 1
                }
            };
        }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
