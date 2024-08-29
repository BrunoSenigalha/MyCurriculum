using System.ComponentModel.DataAnnotations.Schema;

namespace MyCurriculum.Models
{
    [Table("project_tool")]
    public class ProjectTool
    {
        public int ProjectId { get; set; }
        public int ToolId { get; set; }
        public Project? Project { get; set; }
        public Tool? Tool { get; set; }
    }
}
