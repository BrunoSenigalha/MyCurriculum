using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCurriculum.Domain.Entities;
using MyCurriculum.Infraestructure.Repositories.Interfaces;


namespace MyCurriculum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            var projects = await _unitOfWork.ProjectRepository.GetAll();
            return Ok(projects);
        }

        [HttpGet("{id:int:min(1)}", Name = "GetProject")]
        public ActionResult<Project> GetProject(int id)
        {
            var project = _unitOfWork.ProjectRepository.Get(p => p.ProjectId == id);
            return project == null ? throw new Exception("ID not found") : (ActionResult<Project>)Ok(project);
        }

        [HttpPost]
        public ActionResult<Project> PostProject(Project postedProject)
        {
            var project = _unitOfWork.ProjectRepository.Create(postedProject);
            _unitOfWork.Commit();
            return project != null ? (ActionResult<Project>)Ok(project) : throw new ArgumentNullException("Error when trying to save the entity.");
        }

        [HttpPut("{id:int:min(1)}")]
        public ActionResult<Project> PutProject(int id, Project modifiedProject)
        {
            if (id != modifiedProject.ProjectId)
            {
                return BadRequest("ID not found");
            }
            var project = _unitOfWork.ProjectRepository.Update(modifiedProject);
            _unitOfWork.Commit();
            return project != null ? (ActionResult<Project>)Ok(project) : throw new ArgumentNullException("Error when trying to save the entity.");
        }

        [HttpDelete("{id:int:min(1)}")]
        public ActionResult<Project> DeleteProject(int id)
        {
            var project = _unitOfWork.ProjectRepository.Get(p => p.ProjectId == id);
            if (project == null)
            {
                return NotFound("ID not found");
            }
            var deletedProject = _unitOfWork.ProjectRepository.Delete(project);
            _unitOfWork.Commit();
            return Ok(deletedProject);
        }
    }
}
