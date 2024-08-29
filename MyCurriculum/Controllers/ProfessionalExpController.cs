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
    public class ProfessionalExpController(ProfessionalExpRepository professionalExp) : ControllerBase
    {
        private readonly ProfessionalExpRepository _professionalExp = professionalExp;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfessionalExp>>> GetProfessionalExpAsync()
        {
            var professionalExp = await _professionalExp.GetAll();
            return Ok(professionalExp);
        }

        [HttpGet("{id:int:min(1)}", Name = "GetProfessionalExp")]
        public async Task<ActionResult<ProfessionalExp>> GetProfessionalExpAsync(int id)
        {
            var professionalExp = await _professionalExp.GetById(id);
            return Ok(professionalExp);
        }

        [HttpPost]
        public async Task<ActionResult<ProfessionalExp>> PostProfessionalExpAsync(ProfessionalExp postedProfessionalExp)
        {
            var professionalExp = await _professionalExp.Create(postedProfessionalExp);
            return Ok(professionalExp);
        }

        [HttpPut("{id:int:min(1)}")]
        public async Task<ActionResult> PutProfessionalExpAsync(int id, ProfessionalExp modifiedProfessionalExp)
        {
            var professionalExp = await _professionalExp.Update(id, modifiedProfessionalExp);
            return Ok(professionalExp);
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<ActionResult> DeleteProfessionalExpAsync(int id)
        {
            var professionalExp = await _professionalExp.Delete(id);
            return Ok(professionalExp);
        }
    }
}
