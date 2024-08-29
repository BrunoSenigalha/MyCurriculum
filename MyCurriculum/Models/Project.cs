using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MyCurriculum.Models
{
    [Table("projects")]
    public class Project
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("project_name")]
        public string? ProjectName { get; set; }

        [Required]
        [Column("link")]
        public string? Link { get; set; }

        [Required]
        [Column("description")]
        public string? Description { get; set; }

        [Column("curriculum_id")]
        public int CurriculumId { get; set; }

        public ICollection<ProjectTool>? ProjectTool { get; set; }

        [JsonIgnore]
        public ICollection<Tool>? Tools { get; set; }
    }
}
