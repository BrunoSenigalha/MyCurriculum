using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCurriculum.Domain.Entities;
using MyCurriculum.Infraestructure.Repositories.Interfaces;
using MyCurriculum.Models;

namespace MyCurriculum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tool>>> GetTools()
        {
            var tools = await _unitOfWork.ToolRepository.GetAll();
            return Ok(tools);
        }

        [HttpGet("{id:int:min(1)}", Name = "GetTool")]
        public ActionResult<Tool> GetTool(int id)
        {
            var tool = _unitOfWork.ToolRepository.Get(t => t.ToolId == id);
            return tool == null ? throw new Exception("ID not found") : (ActionResult<Tool>)Ok(tool);
        }

        [HttpPost]
        public ActionResult<Tool> PostTool(Tool postedTool)
        {
            var tool = _unitOfWork.ToolRepository.Create(postedTool);
            _unitOfWork.Commit();
            return tool != null ? (ActionResult<Tool>)Ok(tool) : throw new ArgumentNullException("Error when trying to save the entity.");
        }

        [HttpPut("{id:int:min(1)}")]
        public ActionResult<Tool> PutTool(int id, Tool modifiedTool)
        {
            if (id != modifiedTool.ToolId)
            {
                return BadRequest("ID not found");
            }
            var tool = _unitOfWork.ToolRepository.Update(modifiedTool);
            _unitOfWork.Commit();
            return tool != null ? (ActionResult<Tool>)Ok(tool) : throw new ArgumentNullException("Error when trying to save the entity.");
        }

        [HttpDelete("{id:int:min(1)}")]
        public ActionResult<Tool> DeleteTool(int id)
        {
            var tool = _unitOfWork.ToolRepository.Get(t => t.ToolId == id);
            if (tool == null)
            {
                return NotFound("ID not found");
            }
            var deletedTool = _unitOfWork.ToolRepository.Delete(tool);
            _unitOfWork.Commit();
            return Ok(deletedTool);
        }
    }
}
