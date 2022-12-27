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
    public class ProjectMemberRepository : IProjectMemberRepository
    {
        public ProjectMember Create(ProjectMember newProjectMember)
        {
            string sql = @"
                Insert into ProjectMember (MemberId, ProjectId) Values (@pMemberId, @pProjectId)
            ";

            SqlConnection con = new SqlConnection(DbSettings.ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@pMemberId", SqlDbType.UniqueIdentifier).Value = newProjectMember.MemberId;
            cmd.Parameters.Add("@pProjectId", SqlDbType.UniqueIdentifier).Value = newProjectMember.ProjectId;

            cmd.ExecuteNonQuery();
            con.Close();

            return newProjectMember;
        }
    }
}
