using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackItNow.Models
{
    public class Project : Entity
    {
        public ProjectStatus Status { get; set; }
        public byte ProjectStatusId { get; set; }

    }
}
