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

        [Theory]
        [InlineData("AB621BC3-377C-4C9E-846C-07AF6E8A334D")]
        public void GetProjectByIdTest(string projectId)
        {
            ProjectRepository projectRepository = new ProjectRepository();
            var project = projectRepository.GetProjectById(projectId);

            Assert.IsType<Project>(project);
            Assert.Equal("Project #5", project.Name);
            Assert.Equal(3, project.ProjectStatusId);

        }

        [Theory]
        [InlineData("AB621BC3-377C-4C9E-846C-07AF6E8A334D")]
        public void UpdateProjectTest(string projectId)
        {
            ProjectRepository projectRepository = new ProjectRepository();
            var project = projectRepository.GetProjectById(projectId);
            project.Name = "THIS IS AN UPDATED PROJECT";
            project.ProjectStatusId = 1;

            bool updated = projectRepository.Update(project);
            var updatedProject = projectRepository.GetProjectById(projectId);

            Assert.True(updated);
            Assert.Equal("THIS IS AN UPDATED PROJECT", updatedProject.Name);
            Assert.Equal(1, updatedProject.ProjectStatusId);

        }

    }
}
