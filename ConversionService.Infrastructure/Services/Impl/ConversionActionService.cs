using AutoMapper;
using ConversionService.Core.Dtos.Response;
using ConversionService.Core.Repository;
using ConversionService.Core.Enums;
using System.Diagnostics;
using ConversionService.Core.Dtos.Request;
using ConversionService.Core.Entities;
using System.Net.Http;
using ConversionService.Core.Helpers;
using ConversionService.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ConversionAPI.Infrastructure.Services.Impl
{

    public class ConversionActionService: IConversionActionService
    {
        private readonly IConversionActionRepository _conversionActionRepository;
        private readonly IAuditRepository _auditRepository;
        private readonly IHttpContextAccessor _httpRequest;
        
        public ConversionActionService(IConversionActionRepository conversionActionRepository,
            IAuditRepository auditRepository, IHttpContextAccessor httpRequest
            )
        {
            this._conversionActionRepository = conversionActionRepository;
            this._auditRepository = auditRepository;
            this._httpRequest = httpRequest;
        }

        public async Task<ApiCommonResponse> SaveConversionAction(ConversionActionRequest conversionRequest)
        {

            var conversionInstance = ObjectMapper.conversionActionRequestMapper(conversionRequest);
            var savedactivity = await _conversionActionRepository.SaveConversionAction(conversionInstance);
            if (savedactivity == null)
            {
                return CommonResponse.Send(ResponseCodes.FAILURE);
            }
            _auditRepository.AuditTrail(_httpRequest.HttpContext.Request.Path.ToString(), JsonConvert.SerializeObject(conversionRequest), JsonConvert.SerializeObject(savedactivity));
            return CommonResponse.Send(ResponseCodes.SUCCESS, savedactivity, ResponseMessage.ConvertedActionSuccessFullySavedMessage);

            
        }

        public async Task<ApiCommonResponse> GetAllConversionAction()
        {
            var conversions = await _conversionActionRepository.FindAllConversionAction();
            if (conversions == null)
            {
                return CommonResponse.Send(ResponseCodes.NO_DATA_AVAILABLE); ;
            }
            _auditRepository.AuditTrail(_httpRequest.HttpContext.Request.Path.ToString(), "", JsonConvert.SerializeObject(conversions));
            return CommonResponse.Send(ResponseCodes.SUCCESS, conversions, ResponseMessage.ConvertedActionSuccessFullyFetchedMessage);
        }

        public async Task<ApiCommonResponse> GetConversionById(long id)
        {
            var conversionInstance = await _conversionActionRepository.FindConversionActionById(id);
            if (conversionInstance == null)
            {
                return CommonResponse.Send(ResponseCodes.NO_DATA_AVAILABLE); ;
            }
            _auditRepository.AuditTrail(_httpRequest.HttpContext.Request.Path.ToString(), id.ToString(), JsonConvert.SerializeObject(conversionInstance));
            return CommonResponse.Send(ResponseCodes.SUCCESS, conversionInstance, ResponseMessage.ConvertedActionSuccessFullyFetchedMessage);
        }

       



        public async Task<ApiCommonResponse> DeactivateConversionAction(long id)
        {
            var converstionToDeactivate = await _conversionActionRepository.FindConversionActionById(id);
            if (converstionToDeactivate == null)
            {
                return CommonResponse.Send(ResponseCodes.NO_DATA_AVAILABLE); ;
            }

            if (!await _conversionActionRepository.DeactivateConversionAction(converstionToDeactivate))
            {
                return CommonResponse.Send(ResponseCodes.FAILURE);
            }
            _auditRepository.AuditTrail(_httpRequest.HttpContext.Request.Path.ToString(), id.ToString(), JsonConvert.SerializeObject(converstionToDeactivate));
            return CommonResponse.Send(ResponseCodes.SUCCESS, ResponseMessage.ConvertedActionSuccessFullyDeactivatedMessage);
        }



    }
}
