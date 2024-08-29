using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using MyCurriculum.Entities;
using MyCurriculum.Models;
using MyCurriculum.Repositories.Interfaces;

namespace MyCurriculum.Repositories
{
    public class CurriculumRepository(EntitiesContext context) : IRepository<Curriculum>
    {
        private readonly EntitiesContext _context = context;

        public async Task<IEnumerable<Curriculum>> GetAll()
        {
            var curriculum = await _context.Curriculum.ToListAsync();
            return curriculum;
        }

        public async Task<Curriculum> GetById(int id)
        {
            var curriculum = await _context.Curriculum.FirstOrDefaultAsync(p => p.CurriculumId == id);
            return curriculum == null ? throw new Exception("ID not found") : curriculum;
        }

        public async Task<Curriculum> Create(Curriculum curriculum)
        {
            if (curriculum != null)
            {
                _context.Curriculum.Add(curriculum);
                await _context.SaveChangesAsync();
                return curriculum;
            }

            throw new ArgumentNullException("Error when trying to save the entity");
        }

        public async Task<Curriculum> Update(int curriculumId, Curriculum modifiedCurriculum)
        {
            if (curriculumId != modifiedCurriculum.CurriculumId)
            {
                throw new Exception("The informed ID is incorrect");
            }

            _context.Entry(modifiedCurriculum).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return modifiedCurriculum;
        }

        public async Task<Curriculum> Delete(int curriculumId)
        {
            var curriculum = await _context.Curriculum.FindAsync(curriculumId) ?? throw new Exception("Curriculum not found");
            _context.Curriculum.Remove(curriculum);
            await _context.SaveChangesAsync();
            return curriculum;
        }
    }
}
