using Microsoft.AspNetCore.Mvc;
using MyCurriculum.Domain.Entities;
using MyCurriculum.Infraestructure.Repositories.Interfaces;
using MyCurriculum.Models;
using MyCurriculum.Services;

namespace MyCurriculum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourseAsync()
        {
            var courses = await _unitOfWork.CourseRepository.GetAll();
            return Ok(courses);
        }

        [HttpGet("{id:int:min(1)}", Name = "GetCourse")]
        public ActionResult<Course> GetCourse(int id)
        {
            var course = _unitOfWork.CourseRepository.Get(c => c.CourseId == id);
            return course == null ? throw new Exception("ID not found") : (ActionResult<Course>)Ok(course);
        }

        [HttpPost]
        public ActionResult<Course> PostCourse(Course postedCourse)
        {
            var course = _unitOfWork.CourseRepository.Create(postedCourse);
            _unitOfWork.Commit();
            return course != null ? (ActionResult<Course>)Ok(course) : throw new ArgumentNullException("Erro ao tentar salvar a entidade.");
        }

        [HttpPut("{id:int:min(1)}")]
        public ActionResult<Course> PutCourse(int id, Course modifiedCourse)
        {
            if (id != modifiedCourse.CourseId)
            {
                return BadRequest("ID not found");
            }
            var course = _unitOfWork.CourseRepository.Update(modifiedCourse);
            _unitOfWork.Commit();
            return Ok(course);
        }

        [HttpDelete("{id:int:min(1)}")]
        public ActionResult<Course> DeleteCourse(int id)
        {
            var course = _unitOfWork.CourseRepository.Get(c => c.CourseId == id);
            if (course == null)
            {
                return NotFound("Course not found");
            }
            _unitOfWork.CourseRepository.Delete(course);
            _unitOfWork.Commit();
            return Ok(course);
        }
    }
}
