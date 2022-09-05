using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackItNow.Models
{
    public class ProjectMember
    {
        public string MemberId { get; set; }
        public string ProjectId { get; set; }

        public Employee Member { get; set; }
        public Project Project { get; set; }
    }
}
