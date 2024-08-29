using MyCurriculum.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MyCurriculum.Models
{

    [Table("courses")]
    public class Course
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("types_courses_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int TypeId { get; set; }

        [Column("description")]
        [Required]
        public string? Description { get; set; }

        public TypeCourse? TypeCourse { get; set; }

        [Column("curriculum_id")]
        public int CurriculumId { get; set; }
        
    }
}
