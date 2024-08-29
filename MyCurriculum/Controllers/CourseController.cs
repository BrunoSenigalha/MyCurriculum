using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCurriculum.Models;
using MyCurriculum.Repositories;

namespace MyCurriculum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(CourseRepository courseService) : ControllerBase
    {
        private readonly CourseRepository _courseService = courseService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourseAsync()
        {
            var courses = await _courseService.GetAll();
            return Ok(courses);
        }

        [HttpGet("{id:int:min(1)}", Name = "GetCourse")]
        public async Task<ActionResult<Course>> GetCourseAsync(int id)
        {
            var course = await _courseService.GetById(id);
            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult<Course>> PostCourseAsync(Course postedCourse)
        {
            var course = await _courseService.Create(postedCourse);
            return Ok(course);
        }

        [HttpPut("{id:int:min(1)}")]
        public async Task<ActionResult> PutCourseAsync(int id, Course modifiedCurse)
        {
            var course = await _courseService.Update(id, modifiedCurse);
            return Ok(course);
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<ActionResult> DeleteCourseAsync(int id)
        {
            var course = await _courseService.Delete(id);
            return Ok(course);
        }

    }
}
