using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCurriculum.Models
{
    [Table("Links")]
    public class Link
    {
        [Key]
        [Column("id")]
        public int LinkId { get; set; }

        [Column("url")]
        public string? URL { get; set; }

        [Column("curriculum_id")]
        public int CurriculumId { get; set; }

    }
}
