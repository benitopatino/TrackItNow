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
    public class ProjectRepository : IProjectRepository
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
        public Project GetProjectById(string projectId)
        {
            string sql = @"Select * from Project where Id = @pProjectId";

            Project project = new Project();

            SqlConnection con = new SqlConnection(DbSettings.ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@pProjectId", SqlDbType.UniqueIdentifier).Value = Guid.Parse(projectId);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                project.Id = reader.GetGuid("Id").ToString();
                project.Name = reader.GetString("Name");
                project.ProjectStatusId = reader.GetByte("ProjectStatusId");
            }

            con.Close();

            return project;

        }
        public bool Update(Project updateProject)
        {
            string sql = @"
                Update Project Set Name = @pName, ProjectStatusId = @pProjectStatusId
                where Id = @pUpdateProjectId
            ";

            SqlConnection con = new SqlConnection(DbSettings.ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@pUpdateProjectId", SqlDbType.UniqueIdentifier).Value = Guid.Parse(updateProject.Id);

            cmd.Parameters.Add("@pName", SqlDbType.VarChar).Value = updateProject.Name;
            cmd.Parameters.Add("@pProjectStatusId", SqlDbType.TinyInt).Value = updateProject.ProjectStatusId;

            int changedRows = cmd.ExecuteNonQuery();
            con.Close();

            return changedRows > 0;
        }
    }
}
