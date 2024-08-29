using MyCurriculum.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCurriculum.Models
{
    [Table("languages")]
    public class Language
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("language")]
        public string? LanguageName { get; set; }

        [Column("conversation_level")]
        public ProficiencyLevel? ConversationLevel { get; set; }

        [Column("comprehension_level")]
        public ProficiencyLevel? ComprehensionLevel { get; set; }

        [Column("writing_level")]
        public ProficiencyLevel? WritingLevel { get; set; }

        [Column("curriculum_id")]
        public int CurriculumId { get; set; }
    }
}
