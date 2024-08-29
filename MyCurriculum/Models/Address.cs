using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCurriculum.Models
{
    [Table("address")]
    public class Address
    {
        [Key]
        [Column("id")]
        public int AddressId { get; set; }

        [Required]
        [Column("zip_code")]
        public string? ZipCode { get; set; }

        [Required]
        [Column("city")]
        public string? City {  get; set; }

        [Required]
        [Column("state")]
        public string? State { get; set; }

        [Required]
        [Column("country")]
        public string? Country { get; set; }

        [Column("curriculum_id")]
        public int CurriculumId {  get; set; }

    }
}
