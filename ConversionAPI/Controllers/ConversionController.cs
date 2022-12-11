using ConversionAPI.Infrastructure.Services;
using ConversionService.Core.Dtos.Request;
using ConversionService.Core.Dtos.Response;
using Microsoft.AspNetCore.Mvc;


namespace ConversionService.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ConversionController : ControllerBase
    {

        private readonly IConversionUnitService _conversionUnitServices;

        public ConversionController(IConversionUnitService conversionUnitServices)
        {
            this._conversionUnitServices = conversionUnitServices;
        }

        [HttpGet("GetAllConversionUnits")]
        public async Task<ApiCommonResponse> GetAllConversionUnits()
        {
            return await _conversionUnitServices.GetAllConversionUnits();
        }

        
        [HttpGet("GetConversionUnitById/{id}")]
        public async Task<ApiCommonResponse> GetConversionUnitById(long id)
        {
            return await _conversionUnitServices.GetConversionById(id);
        }

        [HttpPost("AddNewConversionUnit")]
        public async Task<ApiCommonResponse> AddNewConversionUnit([FromBody] ConversionRequest conversion)
        {
            return await _conversionUnitServices.SaveConversionUnit(conversion);
        }

        [HttpPut("UpdateConversionUnit/{id}")]
        public async Task<ApiCommonResponse> UpdateConversionUnit(long id, ConversionRequest conversionRequest)
        {
            return await _conversionUnitServices.UpdateConversion(id, conversionRequest);
        }

        [HttpDelete("DeactivateConversion/{id}")]
        public async Task<ApiCommonResponse> DeactivateConversion(int id)
        {
            return await _conversionUnitServices.DeactivateConversionUnit(id);
        }

    }
}
