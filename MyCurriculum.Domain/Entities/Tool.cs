using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MyCurriculum.Domain.Entities
{
    [Table("tools")]
    public class Tool
    {
        [Key]
        [Column("id")]
        public int ToolId { get; set; }

        [Column("tool_name")]
        [StringLength(80)]
        public string? ToolName { get; set; }

        [Column("curriculum_id")]
        public int CurriculumId { get; set; }

        [JsonIgnore]
        public ICollection<Project>? Projects { get; set; }

    }
}
