using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCurriculum.Models;
using MyCurriculum.Repositories;

namespace MyCurriculum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController(ProjectRepository projectService) : ControllerBase
    {
        private readonly ProjectRepository _projectService = projectService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjectsAsync()
        {
            var projects = await _projectService.GetAll();
            return Ok(projects);
        }

        [HttpGet("{id:int:min(1)}", Name = "GetProject")]
        public async Task<ActionResult<Project>> GetProjectAsync(int id)
        {
            var project = await _projectService.GetById(id);
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<Project>> PostProjectAsync(Project postedProject)
        {
            var project = await _projectService.Create(postedProject);
            return Ok(project);
        }

        [HttpPut("{id:int:min(1)}")]
        public async Task<ActionResult<Project>> PutProjectAsync(int id, Project modifiedProject)
        {
            var project = await _projectService.Update(id, modifiedProject);
            return Ok(project);
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<ActionResult<Project>> DeleteProjectAsync(int id) 
        {
            var project = await _projectService.Delete(id);
            return Ok(project);
        }
    }
}
