using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCurriculum.Models;
using MyCurriculum.Repositories;

namespace MyCurriculum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController(LanguageRepository languageService) : ControllerBase
    {
        private readonly LanguageRepository _languageService = languageService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Language>>> GetLanguageAsync()
        {
            var languages = await _languageService.GetAll();
            return Ok(languages);
        }

        [HttpGet("{id:int:min(1)}", Name = "GetLanguage")]
        public async Task<ActionResult<Language>> GetLanguageAsync(int id)
        {
            var language = await _languageService.GetById(id);
            return Ok(language);
        }

        [HttpPost]
        public async Task<ActionResult<Language>> PostLanguageAsync(Language postedLanguage)
        {
            var language = await _languageService.Create(postedLanguage);
            return Ok(language);
        }

        [HttpPut("{id:int:min(1)}")]
        public async Task<ActionResult<Language>> PutLanguageAsync(int id, Language modifiedLanguage)
        {
            var language = await _languageService.Update(id, modifiedLanguage);
            return Ok(language);
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<ActionResult<Language>> DeleteLanguageAsync(int id)
        {
            var language = await _languageService.Delete(id);
            return Ok(language);
        }
    }
}
