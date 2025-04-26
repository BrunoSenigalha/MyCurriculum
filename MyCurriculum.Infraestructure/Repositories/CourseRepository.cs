using Microsoft.EntityFrameworkCore;
using MyCurriculum.Models;
using MyCurriculum.Infraestructure.Context;
using MyCurriculum.Infraestructure.Repositories.Interfaces;
using MyCurriculum.Infraestructure.Repositories;
using MyCurriculum.Domain.Entities;

namespace MyCurriculum.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(EntitiesContext context) : base(context)
        {
        }
    }
}
