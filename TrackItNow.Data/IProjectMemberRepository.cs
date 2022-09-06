using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackItNow.Models;

namespace TrackItNow.Data
{
    public interface IProjectMemberRepository
    {
       ProjectMember Create(ProjectMember newProjectMember);
    }
}
