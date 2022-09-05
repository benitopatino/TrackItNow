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
    public class ProjectRepository
    {
        public Project Create(Project newProject)
        {
            string sql = @"
                Insert into Project (Name, ProjectStatusId) Values (@pName, @pProjectStatusId)
            ";

            SqlConnection con = new SqlConnection(DbSettings.ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand(sql, con);

            var project = new Project()
            {
                Name = newProject.Name,
                ProjectStatusId = newProject.ProjectStatusId
            };

            cmd.Parameters.Add("@pName", SqlDbType.VarChar).Value = project.Name;
            cmd.Parameters.Add("@pProjectStatusId", SqlDbType.TinyInt).Value = project.ProjectStatusId;

            cmd.ExecuteNonQuery();
            con.Close();

            return project;

        }
    }
}
