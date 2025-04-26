using MyCurriculum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCurriculum.Infraestructure.Repositories.Interfaces
{
    public interface ICourseRepository : IBaseRepository<Course>
    {
        // Add any additional methods specific to Course repository if needed
    }
}
