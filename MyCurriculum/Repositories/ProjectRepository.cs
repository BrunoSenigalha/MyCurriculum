using Microsoft.EntityFrameworkCore;
using MyCurriculum.Entities;
using MyCurriculum.Models;
using MyCurriculum.Repositories.Interfaces;

namespace MyCurriculum.Repositories
{
    public class ProjectRepository(EntitiesContext context) : IRepository<Project>
    {
        private readonly EntitiesContext _context = context;

        public async Task<IEnumerable<Project>> GetAll()
        {
            var projects = await _context.Projects.ToListAsync();
            return projects;
        }

        public async Task<Project> GetById(int id)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);
            return project == null ? throw new Exception("ID not found") : project;
        }

        public async Task<Project> Create(Project project)
        {
            if (project != null)
            {
                _context.Projects.Add(project);
                await _context.SaveChangesAsync();
                return project;
            }
            throw new ArgumentNullException(nameof(project));
        }

        public async Task<Project> Delete(int id)
        {
            var project = await _context.Projects.FindAsync(id) ?? throw new Exception("ID not found");
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<Project> Update(int id, Project project)
        {
           if (id != project.Id)
            {
                throw new ArgumentException("The informed ID is incorrect");
            }
           _context.Projects.Entry(project).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return project;
        }
    }
}
