using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackItNow.Models
{
    public class ProjectMember
    {
        public Guid MemberId { get; set; }
        public Guid ProjectId { get; set; }

        public Employee Member { get; set; }
        public Project Project { get; set; }
    }
}
