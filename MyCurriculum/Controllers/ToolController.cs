using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCurriculum.Models;
using MyCurriculum.Repositories;

namespace MyCurriculum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolController(ToolRepository toolService) : ControllerBase
    {
        private readonly ToolRepository _toolService = toolService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tool>>> GetToolsAsync()
        {
            var tools = await _toolService.GetAll();
            return Ok(tools);
        }

        [HttpGet("{id:int:min(1)}", Name = "GetToolById")]
        public async Task<ActionResult<Tool>> GetToolAsync(int id)
        {
            var tool = await _toolService.GetById(id);
            return Ok(tool);
        }

        [HttpPost]
        public async Task<ActionResult<Tool>> PostToolAsync(Tool postedTool)
        {
            var tool = await _toolService.Create(postedTool);
            return Ok(tool);
        }

        [HttpPut("{id:int:min(1)}")]
        public async Task<ActionResult<Tool>> PutToolAsync(int id, Tool modifiedTool)
        {
            var tool = await _toolService.Update(id, modifiedTool);
            return Ok(tool);
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<ActionResult<Tool>> DepeteToolAsync(int id)
        {
            var tool = await _toolService.Delete(id);
            return Ok(tool);
        }
    }
}
