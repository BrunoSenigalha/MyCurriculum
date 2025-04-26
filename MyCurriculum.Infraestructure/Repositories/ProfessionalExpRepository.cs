using Microsoft.EntityFrameworkCore;
using MyCurriculum.Domain.Entities;
using MyCurriculum.Infraestructure.Context;
using MyCurriculum.Infraestructure.Repositories.Interfaces;
using MyCurriculum.Models;

namespace MyCurriculum.Infraestructure.Repositories
{
    public class ProfessionalExpRepository : BaseRepository<ProfessionalExp>, IProfessionalExpRepository
    {
        public ProfessionalExpRepository(EntitiesContext context) : base(context)
        {
        }
        //private readonly EntitiesContext _context = context;
    }
}
