using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConversionService.Core.Enums;

namespace ConversionService.Core.Entities
{
    [Table("ConversionUnit")]
    public class ConversionUnit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public UnitCategory UnitCategory { get; set; }

        [Required, StringLength(200)]
        public string UnitNameOfOrigin { get; set; }

        [Required, StringLength(200)]
        public string UnitNameOfDestination { get; set; }

        public int UserId { get; set; }
        //public  User User { get; set; }
        public float ValuePerUnit { get; set; }

        [Required, StringLength(200)]
        public bool IsActive { get; set; }
        
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
