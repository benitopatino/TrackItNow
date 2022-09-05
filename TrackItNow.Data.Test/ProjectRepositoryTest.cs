using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackItNow.Models;
using Xunit;

namespace TrackItNow.Data.Test
{
    public class ProjectRepositoryTest
    {

        [Theory]
        [InlineData("Project #3", 1)]
        [InlineData("Project #4", 2)]
        [InlineData("Project #5", 3)]
        public void CreateProjectTest(string name, byte ProjectStatusId)
        {
            ProjectRepository projectRepository = new ProjectRepository();

            Project newProject = new Project()
            {
                Name = name,
                ProjectStatusId = ProjectStatusId
            };

            var project = projectRepository.Create(newProject);

            Assert.IsType<Project>(project);
            Assert.Equal(name, project.Name);
            Assert.Equal(ProjectStatusId, project.ProjectStatusId);
        }

    }
}
