using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackItNow.Models;
using Xunit;

namespace TrackItNow.Data.Test
{
    public class ProjectMemberRepositoryTest
    {
        [Theory]
        [InlineData("EC7F5419-7FC0-4576-8411-0F9BB1119100", "AB621BC3-377C-4C9E-846C-07AF6E8A334D")]
        [InlineData("EC7F5419-7FC0-4576-8411-0F9BB1119100", "9F6FC536-D7B8-499C-AD9A-0B162B95902A")]
        [InlineData("503E2D5E-F9E2-4421-8B7D-9297F3AA8EE1", "BDADBFC4-6487-4BAC-B0D8-BAEB2CCDDD6C")]
        [InlineData("46628C4B-27F8-4A8D-90DA-EE3358859DC2", "BDADBFC4-6487-4BAC-B0D8-BAEB2CCDDD6C")]
        public void CreateProjectMemberTest(string memberId, string projectId)
        {
            ProjectMemberRepository projectMemberRepository = new ProjectMemberRepository();

            ProjectMember projectMember = new ProjectMember()
            {
                MemberId = memberId,
                ProjectId = projectId
            };
            
            var newProjectMember = projectMemberRepository.Create(projectMember);

            Assert.IsType<ProjectMember>(newProjectMember);

            Assert.Equal(memberId, newProjectMember.MemberId);
            Assert.Equal(projectId, newProjectMember.ProjectId);

        }

    }
}
