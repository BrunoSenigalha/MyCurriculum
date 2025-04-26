using MyCurriculum.Models;
using MyCurriculum.Repositories;
using MyCurriculum.Services.Interfaces;

namespace MyCurriculum.Services
{
    public class LanguageService(LanguageRepository languageRepository) : IService<Language>
    {
        private readonly LanguageRepository _languageRepository = languageRepository;
        public async Task<IEnumerable<Language>> GetAll()
        {
            return await _languageRepository.GetAll();
        }
        public async Task<Language> GetById(int id)
        {
            return await _languageRepository.GetById(id);
        }
        public async Task<Language> Create(Language language)
        {
            return await _languageRepository.Create(language);
        }
        public async Task<Language> Update(int id, Language language)
        {
            return await _languageRepository.Update(id, language);
        }
        public async Task<Language> Delete(int id)
        {
            return await _languageRepository.Delete(id);
        }
    }
}
