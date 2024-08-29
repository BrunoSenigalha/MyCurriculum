using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyCurriculum.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MyCurriculum.Models
{
    [Table("curriculum")]
    public class Curriculum
    {
        [Key]
        [Column("id")]
        public int CurriculumId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [Column("picture")]
        public byte[]? Picture { get; set; }

        [Required]
        [Column("name")]
        public string? Name { get; set; }

        [Required]
        [Column("gender")]
        public Gender Gender { get; set; }

        [Required]
        [Column("professional_goals")]
        public string? ProfessionalGoals { get; set; }

        [Required]
        [Column("phone")]
        public string? Phone { get; set; }

        [Required]
        [Column("email")]
        public string? Email { get; set; }

        [Required]
        [Column("linkedIn")]
        public string? LinkedIn { get; set; }

        [Required]
        public Address? Address { get; set; }

        [JsonIgnore]
        public ICollection<Link>? Links { get; set; }

        [JsonIgnore]
        public ICollection<ProfessionalExp>? ProfessionalExperiences { get; set; }

        [JsonIgnore]
        public ICollection<Tool>? Tools { get; set; }

        [JsonIgnore]
        public ICollection<Project>? Projects { get; set; }

        [JsonIgnore]
        public ICollection<Language>? Languages { get; set; }

        [JsonIgnore]
        public ICollection<Course>? Courses { get; set; }

        [JsonIgnore]
        public ICollection<AcademicExperience>? Formacaos { get; set; }
    }
}
