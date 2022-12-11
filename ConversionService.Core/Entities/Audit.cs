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
    [Table("Audit")]
    public class Audit
    {
        [Key]
        public long Id { get; set; }

        [Required, StringLength(200)]
        public string API { get; set; }

        [Required]
        public string RequestObject { get; set; }

        [Required]
        public string ResponseObject { get; set; }

       public DateTime CreatedAt { get; set; }
    }
}
