using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCurriculum.Domain.Entities
{
    [Table("Links")]
    public class Link
    {
        [Key]
        [Column("id")]
        public int LinkId { get; set; }

        [Column("url")]
        [StringLength(300)]
        public string? URL { get; set; }

        [Column("curriculum_id")]
        public int CurriculumId { get; set; }

    }
}
