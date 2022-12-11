using ConversionService.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionService.Core.Entities
{

    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Username { get; set; }

        [Required, StringLength(200)]
        public String FirstName { get; set; }

        [Required, StringLength(200)]
        public String LastName { get; set; }

        [Required, StringLength(50)]
        public String Password { get; set; }

        [Required, StringLength(200)]
        public bool IsActive { get; set; }
        public ICollection<ConversionUnit> ConversionUnits { get; set; }
        public ICollection<ConversionAction> ConversionActions { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
