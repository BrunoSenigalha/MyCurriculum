using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCurriculum.Domain.Entities
{
    [Table("address")]
    public class Address
    {
        [Key]
        [Column("id")]
        public int AddressId { get; set; }

        [Required]
        [Column("zip_code")]
        [StringLength(10)]
        public string? ZipCode { get; set; }

        [Required]
        [Column("city")]
        [StringLength(100)]
        public string? City {  get; set; }

        [Required]
        [Column("state")]
        [StringLength(50)]
        public string? State { get; set; }

        [Required]
        [Column("country")]
        [StringLength(100)]
        public string? Country { get; set; }

        [Column("curriculum_id")]
        public int CurriculumId {  get; set; }

    }
}
