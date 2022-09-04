using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackItNow.Models
{
    public class Project 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ProjectStatus Status { get; set; }
        public byte ProjectStatusId { get; set; }

    }
}
