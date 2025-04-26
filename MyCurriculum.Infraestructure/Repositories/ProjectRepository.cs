using Microsoft.EntityFrameworkCore;
using MyCurriculum.Infraestructure.Context;
using MyCurriculum.Infraestructure.Repositories;
using MyCurriculum.Infraestructure.Repositories.Interfaces;
using MyCurriculum.Domain.Entities;


namespace MyCurriculum.Infraestructure.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(EntitiesContext context) : base(context)
        {
        }
        //private readonly EntitiesContext _context = context;
    }
}
