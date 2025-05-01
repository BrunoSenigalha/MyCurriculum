using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using MyCurriculum.Domain.Entities;
using MyCurriculum.Infraestructure.Repositories.Interfaces;
using MyCurriculum.Models;
using MyCurriculum.Services;

namespace MyCurriculum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public LinksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Link>>> GetLinks()
        {
            var links = await _unitOfWork.LinkRepository.GetAll();
            return Ok(links);
        }

        [HttpGet("{id:int:min(1)}", Name = "GetLink")]
        public ActionResult<Link> GetLink(int id)
        {
            var link = _unitOfWork.LinkRepository.Get(l => l.LinkId == id);
            return link == null ? throw new Exception("ID not found") : (ActionResult<Link>)Ok(link);
        }

        [HttpPost]
        public ActionResult<Link> PostLink(Link postedLink)
        {
            var link = _unitOfWork.LinkRepository.Create(postedLink);
            _unitOfWork.Commit();
            return link != null ? (ActionResult<Link>)Ok(link) : throw new ArgumentNullException("Error when trying to save the entity.");
        }

        [HttpPut("{id:int:min(1)}")]
        public ActionResult<Link> PutLink(int id, Link modifiedLink)
        {
            if (id != modifiedLink.LinkId)
            {
                return BadRequest("ID not found");
            }
            var link = _unitOfWork.LinkRepository.Update(modifiedLink);
            _unitOfWork.Commit();
            return link != null ? (ActionResult<Link>)Ok(link) : throw new ArgumentNullException("Error when trying to save the entity.");
        }

        [HttpDelete("{id:int:min(1)}")]
        public ActionResult<Link> DeleteLink(int id)
        {
            var link = _unitOfWork.LinkRepository.Get(l => l.LinkId == id);
            if (link == null)
            {
                return NotFound("ID not found");
            }
            var deletedLink = _unitOfWork.LinkRepository.Delete(link);
            _unitOfWork.Commit();
            return Ok(deletedLink);
        }
    }
}
