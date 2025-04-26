using MyCurriculum.Domain.Entities;
using MyCurriculum.Repositories;
using MyCurriculum.Services.Interfaces;

namespace MyCurriculum.Services
{
    public class ToolService(Repositories.ToolService toolRepository) : IService<Tool>
    {
        private readonly Repositories.ToolService _toolRepository = toolRepository;
        public async Task<IEnumerable<Tool>> GetAll()
        {
            return await _toolRepository.GetAll();
        }
        public async Task<Tool> GetById(int id)
        {
            return await _toolRepository.GetById(id);
        }
        public async Task<Tool> Create(Tool tool)
        {
            return await _toolRepository.Create(tool);
        }
        public async Task<Tool> Update(int id, Tool tool)
        {
            return await _toolRepository.Update(id, tool);
        }
        public async Task<Tool> Delete(int id)
        {
            return await _toolRepository.Delete(id);
        }
    }
}
