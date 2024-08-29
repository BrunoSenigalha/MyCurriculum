using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCurriculum.Entities;
using MyCurriculum.Models;
using MyCurriculum.Repositories;

namespace MyCurriculum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinksController(LinkRepository linkService) : ControllerBase
    {
        private readonly LinkRepository _linkService = linkService;

        [HttpGet]
        public async Task<ActionResult<ICollection<Link>>> GetLinksAsync()
        {
            var links = await _linkService.GetAll();
            return Ok(links);
        }

        [HttpGet("{id:int:min(1)}", Name = "GetLinks")]
        public async Task<ActionResult<Link>> GetLinksByIdAsync(int id)
        {
            var link = await _linkService.GetById(id);
            return Ok(link);
        }

        [HttpPost]
        public async Task<ActionResult> PostLinks(Link postedLink)
        {
            var link = await _linkService.Create(postedLink);
            return Ok(link);
        }

        [HttpPut("{id:int:min(1)}")]
        public async Task<ActionResult> PutLinks(int id, Link modifiedLink)
        {
            var link = await _linkService.Update(id, modifiedLink);
            return Ok(link);
        }

        [HttpDelete("{id:int:min(1)}")]
        public ActionResult DeleteLink(int id)
        {
            var link = _linkService.Delete(id);
            return Ok(link);
        }
    }
}
