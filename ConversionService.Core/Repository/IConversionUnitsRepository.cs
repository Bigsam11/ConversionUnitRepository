using ConversionService.Core.Entities;

namespace ConversionService.Core.Repository
{
    public interface IConversionUnitsRepository
    {
        Task<bool> DeactivateConversionUnit(ConversionUnit conversionUnit);
        Task<IEnumerable<ConversionUnit>> FindAllConversionUnits();
        Task<ConversionUnit> FindConversionUnitById(long Id);
        Task<ConversionUnit> SaveConversionUnit(ConversionUnit conversionUnit);
        Task<ConversionUnit> UpdateActivity(ConversionUnit conversionUnit);

    }
}
