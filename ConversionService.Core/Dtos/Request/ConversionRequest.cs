using ConversionService.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace ConversionService.Core.Dtos.Request
{
    public class ConversionRequest
    {
        public UnitCategory UnitCategory { get; set; }

        public string UnitNameOfOrigin { get; set; }

        public string UnitNameOfDestination { get; set; }

        public float ValuePerUnit { get; set; }

        public int userId { get; set; }

    }
}
