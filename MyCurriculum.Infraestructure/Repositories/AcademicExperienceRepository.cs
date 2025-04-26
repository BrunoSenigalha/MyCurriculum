using Microsoft.EntityFrameworkCore;
using MyCurriculum.Domain.Entities;
using MyCurriculum.Infraestructure.Context;
using MyCurriculum.Infraestructure.Repositories.Interfaces;
using NuGet.Protocol.Core.Types;
using System.Linq.Expressions;

namespace MyCurriculum.Infraestructure.Repositories
{
    public class AcademicExperienceRepository : BaseRepository<AcademicExperience>, IAcademicExperienceRepository
    {
        public AcademicExperienceRepository(EntitiesContext context) : base(context)
        {
        }

    }
}
