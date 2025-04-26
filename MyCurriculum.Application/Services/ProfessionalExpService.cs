using MyCurriculum.Models;
using MyCurriculum.Repositories;
using MyCurriculum.Services.Interfaces;

namespace MyCurriculum.Services
{
    public class ProfessionalExpService(Repositories.ProfessionalExpService professionalExpRepository) : IService<ProfessionalExp>
    {
        private readonly Repositories.ProfessionalExpService _professionalExpRepository = professionalExpRepository;
        public async Task<IEnumerable<ProfessionalExp>> GetAll()
        {
            return await _professionalExpRepository.GetAll();
        }
        public async Task<ProfessionalExp> GetById(int id)
        {
            return await _professionalExpRepository.GetById(id);
        }
        public async Task<ProfessionalExp> Create(ProfessionalExp professionalExp)
        {
            return await _professionalExpRepository.Create(professionalExp);
        }
        public async Task<ProfessionalExp> Update(int id, ProfessionalExp professionalExp)
        {
            return await _professionalExpRepository.Update(id, professionalExp);
        }
        public async Task<ProfessionalExp> Delete(int id)
        {
            return await _professionalExpRepository.Delete(id);
        }
    }
   
}
