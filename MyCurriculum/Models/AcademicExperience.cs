using MyCurriculum.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCurriculum.Models
{
    [Table("formations")]
    public class AcademicExperience
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("course_name")]
        public string? CourseName { get; set; }

        [Column("institution")]
        public string? Institution { get; set; }

        [Column("degree")]
        public Degree Degree { get; set; }

        [Column("types_formations")]
        public TypeFormation TypeFormation { get; set; }

        [Column("status_formation")]
        public StatusFormation StatusFormation { get; set; }

        [Column("studying")]
        public bool IsStudying { get; set; }

        [Column("start_date")]
        public DateOnly StartDate { get; set; }

        [Column("end_date")]
        public DateOnly EndDate { get; set; }

        [Column("curriculum_id")]
        public int CurriculumId { get; set; }
    }
}
