using MyCurriculum.Entities;
using MyCurriculum.Models;
using MyCurriculum.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MyCurriculum.Repositories
{
    public class LanguageRepository(EntitiesContext context) : IRepository<Language>
    {
        private readonly EntitiesContext _context = context;
        public async Task<IEnumerable<Language>> GetAll()
        {
            var languages = await _context.Languages.ToListAsync();
            return languages;
        }

        public async Task<Language> GetById(int id)
        {
            var language = await _context.Languages.FirstOrDefaultAsync(x => x.Id == id);
            return language == null ? throw new Exception("Id not found") : language;
        }

        public async Task<Language> Create(Language language)
        {
            if (language == null)
            {
                throw new ArgumentNullException(nameof(language));
            }
            _context.Languages.Add(language);
            await _context.SaveChangesAsync();
            return language;
        }

        public async Task<Language> Delete(int id)
        {
            var language = await _context.Languages.FindAsync(id) ?? throw new Exception("Id not found");
            _context.Languages.Remove(language);
            await _context.SaveChangesAsync();
            return language;
        }

        public async Task<Language> Update(int id, Language language)
        {
            if(id != language.Id)
            {
                throw new ArgumentException("The informed ID is incorrect");
            }
            _context.Languages.Entry(language).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return language;
        }
    }
}
