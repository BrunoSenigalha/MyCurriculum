using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCurriculum.Entities;
using MyCurriculum.Models;
using MyCurriculum.Repositories;
using MyCurriculum.Repositories.Interfaces;

namespace MyCurriculum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CurriculumController(CurriculumRepository curriculumService) : ControllerBase
    {
        private readonly CurriculumRepository _curriculumService = curriculumService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curriculum>>> GetCurriculumAsync()
        {
            var curriculums = await _curriculumService.GetAll();
            return Ok(curriculums);
        }

        [HttpGet("{id:int:min(1)}", Name = "GetCurriculum")]
        public async Task<ActionResult<Curriculum>> GetCurriculumAsync(int id)
        {
            var curriculum = await _curriculumService.GetById(id);
            return Ok(curriculum);
        }

        [HttpPost]
        public async Task<ActionResult<Curriculum>> PostCurriculumAsync(Curriculum postedCurriculum)
        {
            var curriculum = await _curriculumService.Create(postedCurriculum);
            return Ok(curriculum);
        }

        [HttpPut("{id:int:min(1)}")]
        public async Task<ActionResult> PutCurriculumAsync(int id, Curriculum modifiedCurriculum)
        {
            var curriculum = await _curriculumService.Update(id, modifiedCurriculum);
            return Ok(curriculum);
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<ActionResult> DeleteCurriculumAsync(int id)
        {
            var curriculum = await _curriculumService.Delete(id);
            return Ok(curriculum);
        }
    }
}
