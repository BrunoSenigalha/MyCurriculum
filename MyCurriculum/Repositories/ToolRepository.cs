using MyCurriculum.Models;
using MyCurriculum.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using MyCurriculum.Entities;

namespace MyCurriculum.Repositories
{
    public class ToolRepository(EntitiesContext context) : IRepository<Tool>
    {
        private readonly EntitiesContext _context = context;
        public async Task<IEnumerable<Tool>> GetAll()
        {
            var tools = await _context.Tools.ToListAsync();
            return tools;
        }

        public async Task<Tool> GetById(int id)
        {
            var tool = await _context.Tools.FindAsync(id);
            return tool == null ? throw new Exception("ID not found") : tool;
        }

        public async Task<Tool> Create(Tool tool)
        {
            if (tool == null)
            {
                throw new ArgumentNullException("Error when trying to save the entity");
            }

            _context.Tools.Add(tool);
            await _context.SaveChangesAsync();
            return tool;
        }

        public async Task<Tool> Delete(int id)
        {
            var tool = await _context.Tools.FindAsync(id) ?? throw new Exception("ID not found");
            return tool;
        }

        public async Task<Tool> Update(int id, Tool tool)
        {
            if (id != tool.Id)
            {
                throw new Exception("The informed ID is incorrect");
            }
            _context.Entry(tool).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return tool;
        }
    }
}
