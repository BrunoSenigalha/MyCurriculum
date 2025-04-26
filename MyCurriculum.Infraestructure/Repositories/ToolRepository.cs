using Microsoft.EntityFrameworkCore;
using MyCurriculum.Domain.Entities;
using MyCurriculum.Infraestructure.Context;
using MyCurriculum.Infraestructure.Repositories.Interfaces;

namespace MyCurriculum.Infraestructure.Repositories
{
    public class ToolRepository : BaseRepository<Tool>, IToolRepository
    {
        public ToolRepository(EntitiesContext context) : base(context)
        {
        }
    }
}
