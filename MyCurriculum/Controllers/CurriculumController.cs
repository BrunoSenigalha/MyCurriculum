using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using MyCurriculum.Domain.Entities;
using MyCurriculum.Entities;
using MyCurriculum.Infraestructure.Repositories.Interfaces;
using MyCurriculum.Services;

namespace MyCurriculum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CurriculumController : ControllerBase
    {
        //private readonly IBaseRepository<Curriculum> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CurriculumController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<Curriculum>>> GetCurriculumAsync()
        {
            var curriculums = await _unitOfWork.CurriculumRepository.GetAll();
            return Ok(curriculums);
        }

        [HttpGet("{id:int:min(1)}", Name = "GetCurriculum")]
        public ActionResult<Curriculum> GetCurriculum(int id)
        {
            var curriculum = _unitOfWork.CurriculumRepository.Get(c => c.CurriculumId == id);
            return curriculum == null ? throw new Exception("ID não encontrado") : (ActionResult<Curriculum>)Ok(curriculum);
        }

        [HttpPost]
        public ActionResult<Curriculum> PostCurriculum(Curriculum postedCurriculum)
        {
            var curriculum = _unitOfWork.CurriculumRepository.Create(postedCurriculum);
            _unitOfWork.Commit();
            return curriculum != null ? (ActionResult<Curriculum>)Ok(curriculum) : throw new ArgumentNullException("Erro ao tentar salvar a entidade.");
        }

        [HttpPut("{id:int:min(1)}")]
        public ActionResult<Curriculum> PutCurriculum(int id, Curriculum modifiedCurriculum)
        {
            if (id != modifiedCurriculum.CurriculumId)
            {
                return BadRequest("ID não encontrado");
            }

            var curriculum = _unitOfWork.CurriculumRepository.Update(modifiedCurriculum);
            _unitOfWork.Commit();
            return Ok(curriculum);
        }

        [HttpDelete("{id:int:min(1)}")]
        public ActionResult<Curriculum> DeleteCurriculum(int id)
        {
            var curriculum = _unitOfWork.CourseRepository.Get(c => c.CurriculumId == id);
            if (curriculum is null)
            {
                return BadRequest("ID não encontrado");
            }
            _unitOfWork.CourseRepository.Delete(curriculum);
            _unitOfWork.Commit();
            return Ok(curriculum);
        }
    }
}
