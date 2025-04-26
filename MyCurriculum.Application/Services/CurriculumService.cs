using MyCurriculum.Models;
using MyCurriculum.Repositories;
using MyCurriculum.Services.Interfaces;

namespace MyCurriculum.Services
{
    public class CurriculumService(CurriculumRepository curriculumRepository) : IService<Curriculum>
    {
        private readonly CurriculumRepository _curriculumRepository = curriculumRepository;
        public async Task<IEnumerable<Curriculum>> GetAll()
        {
            return await _curriculumRepository.GetAll();
        }
        public async Task<Curriculum> GetById(int id)
        {
            return await _curriculumRepository.GetById(id);
        }
        public async Task<Curriculum> Create(Curriculum curriculum)
        {
            return await _curriculumRepository.Create(curriculum);
        }
        public async Task<Curriculum> Update(int id, Curriculum curriculum)
        {
            return await _curriculumRepository.Update(id, curriculum);
        }
        public async Task<Curriculum> Delete(int id)
        {
            return await _curriculumRepository.Delete(id);
        }
    }
}
