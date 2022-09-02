using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackItNow.Models
{
    public abstract class Entity
    {
        public byte Id { get; set; }
        public virtual string Name { get; set; }
    }
}
