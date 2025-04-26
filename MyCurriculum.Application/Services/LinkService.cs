using MyCurriculum.Models;
using MyCurriculum.Repositories;
using MyCurriculum.Services.Interfaces;

namespace MyCurriculum.Services
{
    public class LinkService(LinkRepository linkRepository) : IService<Link>
    {
        private readonly LinkRepository _linkRepository = linkRepository;
        public async Task<IEnumerable<Link>> GetAll()
        {
            return await _linkRepository.GetAll();
        }
        public async Task<Link> GetById(int id)
        {
            return await _linkRepository.GetById(id);
        }
        public async Task<Link> Create(Link link)
        {
            return await _linkRepository.Create(link);
        }
        public async Task<Link> Update(int id, Link link)
        {
            return await _linkRepository.Update(id, link);
        }
        public async Task<Link> Delete(int id)
        {
            return await _linkRepository.Delete(id);
        }
    }
}
