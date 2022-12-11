using ConversionService.Core.Entities;
using ConversionService.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionService.Core.Dtos.Request
{
    public class ConversionActionRequest
    {
        public UnitCategory UnitCategory { get; set; }

        public string UnitNameOfOrigin { get; set; }

        public string UnitNameOfDestination { get; set; }

        public int UserId { get; set; }

        public float valueToConvert { get; set; }
        public float ValuePerUnit { get; set; }

        public float ValueResult { get; set; }

    }
}
