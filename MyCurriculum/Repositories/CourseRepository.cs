using MyCurriculum.Entities;
using Microsoft.EntityFrameworkCore;
using MyCurriculum.Models;
using MyCurriculum.Repositories.Interfaces;

namespace MyCurriculum.Repositories
{
    public class CourseRepository(EntitiesContext context) : IRepository<Course>
    {
        private readonly EntitiesContext _context = context;

        public async Task<IEnumerable<Course>> GetAll()
        {
            var course = await _context.Courses.ToListAsync();
            return course;
        }

        public async Task<Course> GetById(int id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            return course == null ? throw new Exception("ID not found") : course;
        }

        public async Task<Course> Create(Course course)
        {
            if (course != null)
            {
                _context.Courses.Add(course);
                await _context.SaveChangesAsync();
                return course;
            }

            throw new ArgumentNullException(nameof(course));
        }

        public async Task<Course> Update(int id, Course course)
        {
            if (id == course.Id)
            {
                _context.Entry(course).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return course;
            }
            throw new Exception("The informed ID is incorrect");
        }

        public async Task<Course> Delete(int courseId)
        {
            var course = await _context.Courses.FindAsync(courseId) ?? throw new ArgumentNullException("ID not found");
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return course;
        }
    }
}
