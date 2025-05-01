using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCurriculum.Domain.Entities;
using MyCurriculum.Infraestructure.Repositories.Interfaces;
using MyCurriculum.Models;
using MyCurriculum.Services;

namespace MyCurriculum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly IUnitOfWork _uniteOfWork;

        public LanguageController(IUnitOfWork unitOfWork)
        {
            _uniteOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Language>>> GetLanguages()
        {
            var languages = await _uniteOfWork.LanguageRepository.GetAll();
            return Ok(languages);
        }

        [HttpGet("{id:int:min(1)}", Name = "GetLanguage")]
        public ActionResult<Language> GetLanguage(int id)
        {
            var language = _uniteOfWork.LanguageRepository.Get(l => l.LanguageId == id);
            return language == null ? throw new Exception("ID not found") : (ActionResult<Language>)Ok(language);
        }

        [HttpPost]
        public ActionResult<Language> PostLanguage(Language postedLanguage)
        {
            var language = _uniteOfWork.LanguageRepository.Create(postedLanguage);
            _uniteOfWork.Commit();
            return language != null ? (ActionResult<Language>)Ok(language) : throw new ArgumentNullException("Erro ao tentar salvar a entidade.");
        }

        [HttpPut("{id:int:min(1)}")]
        public ActionResult<Language> PutLanguage(int id, Language modifiedLanguage)
        {
            if (id != modifiedLanguage.LanguageId)
            {
                return BadRequest("ID não encontrado");
            }
            var language = _uniteOfWork.LanguageRepository.Update(modifiedLanguage);
            _uniteOfWork.Commit();
            return language != null ? (ActionResult<Language>)Ok(language) : throw new ArgumentNullException("Erro ao tentar salvar a entidade.");
        }

        [HttpDelete("{id:int:min(1)}")]
        public ActionResult<Language> DeleteLanguage(int id)
        {
            var language = _uniteOfWork.LanguageRepository.Get(l => l.LanguageId == id);
            if (language == null)
            {
                return NotFound("ID não encontrado");
            }
            _uniteOfWork.LanguageRepository.Delete(language);
            _uniteOfWork.Commit();
            return Ok(language);
        }
    }
}
