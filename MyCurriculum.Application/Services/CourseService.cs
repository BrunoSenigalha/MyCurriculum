using MyCurriculum.Models;
using MyCurriculum.Repositories;
using MyCurriculum.Services.Interfaces;

namespace MyCurriculum.Services
{
    public class CourseService(CourseRepository courseRepository) : IService<Course>
    {
        private readonly CourseRepository _courseRepository = courseRepository;
        public async Task<IEnumerable<Course>> GetAll()
        {
            return await _courseRepository.GetAll();
        }
        public async Task<Course> GetById(int id)
        {
            return await _courseRepository.GetById(id);
        }
        public async Task<Course> Create(Course course)
        {
            return await _courseRepository.Create(course);
        }
        public async Task<Course> Update(int id, Course course)
        {
            return await _courseRepository.Update(id, course);
        }
        public async Task<Course> Delete(int id)
        {
            return await _courseRepository.Delete(id);
        }
    }
}
