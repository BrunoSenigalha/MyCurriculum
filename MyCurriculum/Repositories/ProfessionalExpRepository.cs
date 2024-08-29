using Microsoft.EntityFrameworkCore;
using MyCurriculum.Entities;
using MyCurriculum.Models;
using MyCurriculum.Repositories.Interfaces;

namespace MyCurriculum.Repositories
{
    public class ProfessionalExpRepository(EntitiesContext context) : IRepository<ProfessionalExp>
    {
        private readonly EntitiesContext _context = context;
        public async Task<IEnumerable<ProfessionalExp>> GetAll()
        {
            var professionalExp = await _context.ProfessionalExp.ToListAsync();
            return professionalExp;
        }

        public async Task<ProfessionalExp> GetById(int id)
        {
            var professionalExp = await _context.ProfessionalExp.FirstOrDefaultAsync(p => p.Id == id);
            return professionalExp == null ? throw new Exception("ID not found") : professionalExp;
        }

        public async Task<ProfessionalExp> Create(ProfessionalExp professionalExp)
        {
            if (professionalExp == null)
            {
                throw new ArgumentNullException("Error when trying to save the entity");
            }

            _context.ProfessionalExp.Add(professionalExp);
            await _context.SaveChangesAsync();
            return professionalExp;
        }

        public async Task<ProfessionalExp> Delete(int id)
        {
            var professionalExp = await _context.ProfessionalExp.FindAsync(id) ?? throw new Exception("ID not found");
            _context.ProfessionalExp.Remove(professionalExp);
            await _context.SaveChangesAsync();
            return professionalExp;
        }

        public async Task<ProfessionalExp> Update(int id, ProfessionalExp professionalExp)
        {
            if (id != professionalExp.Id)
            {
                throw new Exception("Informed ID is incorrect");
            }

            _context.Entry(professionalExp).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return professionalExp;
        }
    }
}
