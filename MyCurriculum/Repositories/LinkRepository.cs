using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using MyCurriculum.Entities;
using MyCurriculum.Models;
using MyCurriculum.Repositories.Interfaces;

namespace MyCurriculum.Repositories
{
    public class LinkRepository(EntitiesContext context) : IRepository<Link>
    {
        private readonly EntitiesContext _context = context;

        public async Task<IEnumerable<Link>> GetAll()
        {
            var links = await _context.Links.ToListAsync();
            return links;
        }

        public async Task<Link> GetById(int id)
        {
            var link = await _context.Links.FindAsync(id);
            return link ?? throw new Exception("ID not found");
        }

        public async Task<Link> Create(Link entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Links.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Link> Delete(int id)
        {
            var link = await _context.Links.FindAsync(id) ?? throw new Exception("Link not found");
            _context.Links.Remove(link);
            await _context.SaveChangesAsync();
            return link;
        }

        public async Task<Link> Update(int id, Link entity)
        {
            if (id != entity.LinkId)
            {
                throw new Exception("The informed ID is incorrect");
            }
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
