using ConversionService.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionService.Core.Dtos.Response
{
    public class ConversionResponse
    {
        public int Id { get; set; }

        public UnitCategory UnitCategory { get; set; }

        public string UnitNameOfOrigin { get; set; }

        public string UnitNameOfDestination { get; set; }

        public float ValuePerUnit { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
