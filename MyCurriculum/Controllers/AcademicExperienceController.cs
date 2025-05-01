using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using MyCurriculum.Domain.Entities;
using MyCurriculum.Infraestructure.Repositories.Interfaces;

namespace MyCurriculum.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicExperienceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AcademicExperienceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<AcademicExperience>>> GetAcademicExpAsync()
        {
            var academicExperiences = await _unitOfWork.AcademicExperienceRepository.GetAll();
            return Ok(academicExperiences);
        }

        [HttpGet("{id:int:min(1)}", Name = "GetAcademicExp")]
        public ActionResult<AcademicExperience> GetAcademicExp(int id)
        {
            var academicExperience = _unitOfWork.AcademicExperienceRepository.Get(c => c.AcademicExpId == id);
            //if (academicExperience is null)
            //{
            //    throw new Exception("ID não encontrado");
            //}
            //return Ok(academicExperience);
            return academicExperience == null ? throw new Exception("ID não encontrado") : (ActionResult<AcademicExperience>)Ok(academicExperience);
        }

        [HttpPost]
        public ActionResult<AcademicExperience> PostAcademicExp(AcademicExperience postedAcademicExperience)
        {
            var academicExperience = _unitOfWork.AcademicExperienceRepository.Create(postedAcademicExperience);
            _unitOfWork.Commit();
            return academicExperience != null
                ? (ActionResult<AcademicExperience>)Ok(academicExperience)
                : throw new ArgumentNullException(nameof(postedAcademicExperience), "Erro ao tentar salvar a entidade.");
        }

        [HttpPut("{id:int:min(1)}")]
        public ActionResult<AcademicExperience> PutAcademicExp(int id, AcademicExperience modifiedAcademicExperience)
        {
            if (id != modifiedAcademicExperience.AcademicExpId)
            {
                return BadRequest("ID não encontrado");
            }
            var academicExperience = _unitOfWork.AcademicExperienceRepository.Update(modifiedAcademicExperience);
            _unitOfWork.Commit();
            return Ok(academicExperience);
        }

        [HttpDelete("{id:int:min(1)}")]
        public ActionResult<AcademicExperience> DeleteAcademicExp(int id)
        {
            var academicExperience = _unitOfWork.AcademicExperienceRepository.Get(c => c.AcademicExpId == id);
            if (academicExperience is null)
            {
                return BadRequest("ID não encontrado");
            }
            _unitOfWork.AcademicExperienceRepository.Delete(academicExperience);
            _unitOfWork.Commit();
            return Ok(academicExperience);
        }
    }
}
