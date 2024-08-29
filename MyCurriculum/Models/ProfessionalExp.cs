using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCurriculum.Models
{
    [Table("professional_experiences")]
    public class ProfessionalExp
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("company")]
        public string? Company { get; set; }

        [Column("position")]
        public string? Position { get; set; }

        [Column("actual_job")]
        public bool ActualJob { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("start_date")]
        public DateOnly StartDate { get; set; }

        [Column("end_date")]
        public DateOnly EndDate { get; set; }

        [Column("curriculum_id")]
        public int CurriculumId { get; set; }

    }
}
