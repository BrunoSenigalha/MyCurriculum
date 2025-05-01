using MyCurriculum.Domain.Entities;
using MyCurriculum.Infraestructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCurriculum.Infraestructure.Repositories.Interfaces
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(EntitiesContext context) : base(context)
        {
        }
    }
}
