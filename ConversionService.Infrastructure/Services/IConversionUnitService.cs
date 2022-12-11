using ConversionService.Core.Dtos.Request;
using ConversionService.Core.Dtos.Response;

namespace ConversionAPI.Infrastructure.Services
{
    public interface IConversionUnitService
    {
        Task<ApiCommonResponse> SaveConversionUnit(ConversionRequest conversionRequest);
        Task<ApiCommonResponse> GetAllConversionUnits();
        Task<ApiCommonResponse> GetConversionById(long id);
        Task<ApiCommonResponse> UpdateConversion(long id, ConversionRequest conversionRequest);
        Task<ApiCommonResponse> DeactivateConversionUnit(long id);

    }
}
