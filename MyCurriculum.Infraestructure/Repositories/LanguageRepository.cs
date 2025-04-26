using MyCurriculum.Models;
using Microsoft.EntityFrameworkCore;
using MyCurriculum.Infraestructure.Context;
using MyCurriculum.Infraestructure.Repositories.Interfaces;
using MyCurriculum.Infraestructure.Repositories;
using MyCurriculum.Domain.Entities;

namespace MyCurriculum.Infraestructure.Repositories
{
    public class LanguageRepository : BaseRepository<Language>, ILanguageRepository
    {
        public LanguageRepository(EntitiesContext context) : base(context)
        {
        }
    }
}
