using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyCurriculum.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MyCurriculum.Domain.Entities
{
    [Table("curriculum")]
    public class Curriculum
    {
        [Key]
        [Column("id")]
        public int CurriculumId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [Column("picture")]
        [StringLength(100)]
        public byte[]? Picture { get; set; }

        [Required]
        [Column("name")]
        [StringLength(100)]
        public string? Name { get; set; }

        [Column("genders")]
        public Gender Gender { get; set; }

        [Required]
        [Column("professional_goals")]
        [StringLength(100)]
        public string? ProfessionalGoals { get; set; }

        [Required]
        [Column("phone")]
        [StringLength(15)]
        public string? Phone { get; set; }

        [Required]
        [Column("email")]
        [StringLength(100)]
        public string? Email { get; set; }

        [Required]
        [Column("linkedIn")]
        [StringLength(150)]
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
        public ICollection<AcademicExperience>? AcademicExperiences { get; set; }
    }
}
