using MyCurriculum.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MyCurriculum.Domain.Entities
{

    [Table("courses")]
    public class Course
    {
        [Key]
        [Column("id")]
        public int CourseId { get; set; }

        [Column("title")]
        [Required]
        [StringLength(100)]
        public string? Title { get; set; }

        [Column("description")]
        [Required]
        [StringLength(500)]
        public string? Description { get; set; }

        public TypeCourse? TypeCourse { get; set; }

        [Column("curriculum_id")]
        public int CurriculumId { get; set; }
        
    }
}
