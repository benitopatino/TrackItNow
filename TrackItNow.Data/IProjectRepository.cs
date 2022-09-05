using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackItNow.Models;

namespace TrackItNow.Data
{
    public interface IProjectRepository
    {
        Project Create(Project newProject);
        Project GetProjectById(string projectId);
        bool Update(Project updateProject);
    }
}
