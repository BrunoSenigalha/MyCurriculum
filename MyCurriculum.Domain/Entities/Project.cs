using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MyCurriculum.Domain.Entities
{
    [Table("projects")]
    public class Project
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("project_name")]
        [StringLength(80)]
        public string? ProjectName { get; set; }

        [Required]
        [Column("link")]
        [StringLength(300)]
        public string? Link { get; set; }

        [Required]
        [Column("description")]
        [StringLength(500)]
        public string? Description { get; set; }

        [Column("curriculum_id")]
        public int CurriculumId { get; set; }

        [JsonIgnore]
        public ICollection<Tool>? Tools { get; set; }

    }
}
