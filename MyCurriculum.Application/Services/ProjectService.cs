using MyCurriculum.Models;
using MyCurriculum.Repositories;
using MyCurriculum.Services.Interfaces;

namespace MyCurriculum.Services
{
    public class ProjectService(Repositories.ProjectService projectRepository) : IService<Project>
    {
        private readonly Repositories.ProjectService _projectRepository = projectRepository;
        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _projectRepository.GetAll();
        }
        public async Task<Project> GetById(int id)
        {
            return await _projectRepository.GetById(id);
        }
        public async Task<Project> Create(Project project)
        {
            return await _projectRepository.Create(project);
        }
        public async Task<Project> Update(int id, Project project)
        {
            return await _projectRepository.Update(id, project);
        }
        public async Task<Project> Delete(int id)
        {
            return await _projectRepository.Delete(id);
        }
    }
}
