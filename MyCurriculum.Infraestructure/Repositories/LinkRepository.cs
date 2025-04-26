using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using MyCurriculum.Domain.Entities;
using MyCurriculum.Infraestructure.Context;
using MyCurriculum.Infraestructure.Repositories;
using MyCurriculum.Infraestructure.Repositories.Interfaces;
using MyCurriculum.Models;

namespace MyCurriculum.Infraestructure.Repositories
{
    public class LinkRepository : BaseRepository<Link>, ILinkRepository
    {
        public LinkRepository(EntitiesContext context) : base(context)
        {
        }
        //private readonly EntitiesContext _context = context;
    }
}