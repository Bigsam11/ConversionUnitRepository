using ConversionAPI.Infrastructure.Services;
using ConversionService.Core.Dtos.Request;
using ConversionService.Core.Dtos.Response;
using ConversionService.Core.Entities;
using ConversionService.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConversionService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversionActionController : ControllerBase
    {
        private readonly IConversionActionService _conversionActionService;
        public ConversionActionController(IConversionActionService conversionActionService)
        {
            this._conversionActionService = conversionActionService;
        }

        // GET: api/<ConversionActionController>
        [HttpGet("GetAllConversionActions")]
        public async Task<ApiCommonResponse> GetAllConversionActions()
        {
            return await  _conversionActionService.GetAllConversionAction();
        }

        // GET api/<ConversionActionController>/5
        [HttpGet("GetConversionActionById/{id}")]
        public async Task<ApiCommonResponse> GetConversionActionById(long id)
        {
            return await _conversionActionService.GetConversionById(id);
        }

        // POST api/<ConversionActionController>
        [HttpPost("InitiateConversion")]
        public async Task<ApiCommonResponse> InitiateConversion([FromBody] ConversionActionRequest conversionActionRequest)
        {
            return await _conversionActionService.SaveConversionAction(conversionActionRequest);
        }


        // DELETE api/<ConversionActionController>/5
        [HttpDelete("DeactivateConversion/{id}")]
        public async Task<ApiCommonResponse> Delete(int id)
        {
            return await _conversionActionService.DeactivateConversionAction(id);
        }
    }
}
