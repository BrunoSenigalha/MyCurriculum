using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCurriculum.Domain.Entities;
using MyCurriculum.Entities;
using MyCurriculum.Infraestructure.Repositories.Interfaces;
using MyCurriculum.Models;

namespace MyCurriculum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionalExpController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProfessionalExpController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfessionalExp>>> GetProfessionalExps()
        {
            var professionalExps = await _unitOfWork.ProfessionalExpRepository.GetAll();
            return Ok(professionalExps);
        }

        [HttpGet("{id:int:min(1)}", Name = "GetProfessionalExp")]
        public ActionResult<ProfessionalExp> GetProfessionalExp(int id)
        {
            var professionalExp = _unitOfWork.ProfessionalExpRepository.Get(pe => pe.ProfessionalExpId == id);
            return professionalExp == null ? throw new Exception("ID not found") : (ActionResult<ProfessionalExp>)Ok(professionalExp);
        }

        [HttpPost]
        public ActionResult<ProfessionalExp> PostProfessionalExp(ProfessionalExp postedProfessionalExp)
        {
            var professionalExp = _unitOfWork.ProfessionalExpRepository.Create(postedProfessionalExp);
            _unitOfWork.Commit();
            return professionalExp != null ? (ActionResult<ProfessionalExp>)Ok(professionalExp) : throw new ArgumentNullException("Error when trying to save the entity.");
        }

        [HttpPut("{id:int:min(1)}")]
        public ActionResult<ProfessionalExp> PutProfessionalExp(int id, ProfessionalExp modifiedProfessionalExp)
        {
            if (id != modifiedProfessionalExp.ProfessionalExpId)
            {
                return BadRequest("ID not found");
            }
            var professionalExp = _unitOfWork.ProfessionalExpRepository.Update(modifiedProfessionalExp);
            _unitOfWork.Commit();
            return professionalExp != null ? (ActionResult<ProfessionalExp>)Ok(professionalExp) : throw new ArgumentNullException("Error when trying to save the entity.");
        }

        [HttpDelete("{id:int:min(1)}")]
        public ActionResult<ProfessionalExp> DeleteProfessionalExp(int id)
        {
            var professionalExp = _unitOfWork.ProfessionalExpRepository.Get(pe => pe.ProfessionalExpId == id);
            if (professionalExp == null)
            {
                return NotFound("ID not found");
            }
            _unitOfWork.ProfessionalExpRepository.Delete(professionalExp);
            _unitOfWork.Commit();
            return Ok(professionalExp);
        }
    }
}
