using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MyCurriculum.Models
{
    [Table("tools")]
    public class Tool
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("tool_name")]
        public string? ToolName { get; set; }

        [Column("curriculum_id")]
        public int CurriculumId { get; set; }

        public ICollection<ProjectTool>? ProjectTool { get; set; }

        [JsonIgnore]
        public ICollection<Project>? Projects { get; set; }

    }
}
