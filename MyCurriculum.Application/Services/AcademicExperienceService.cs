using MyCurriculum.Models;
using MyCurriculum.Repositories;
using MyCurriculum.Services.Interfaces;

namespace MyCurriculum.Services
{
    public class AcademicExperienceService(AcademicExperienceRepository academicExperienceRepository) : IService<AcademicExperience>
    {
        private readonly AcademicExperienceRepository _academicExperienceRepository = academicExperienceRepository;
        public async Task<IEnumerable<AcademicExperience>> GetAll()
        {
            return await _academicExperienceRepository.GetAll();
        }
        public async Task<AcademicExperience> GetById(int id)
        {
            return await _academicExperienceRepository.GetById(id);
        }
        public async Task<AcademicExperience> Create(AcademicExperience academicExperience)
        {
            return await _academicExperienceRepository.Create(academicExperience);
        }
        public async Task<AcademicExperience> Update(int id, AcademicExperience academicExperience)
        {
            return await _academicExperienceRepository.Update(id, academicExperience);
        }
        public async Task<AcademicExperience> Delete(int id)
        {
            return await _academicExperienceRepository.Delete(id);
        }
    }
}
