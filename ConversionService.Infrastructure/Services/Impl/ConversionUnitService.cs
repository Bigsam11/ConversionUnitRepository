using AutoMapper;
using ConversionService.Core.Dtos.Response;
using ConversionService.Core.Repository;
using ConversionService.Core.Enums;
using System.Diagnostics;
using ConversionService.Core.Dtos.Request;
using ConversionService.Core.Entities;
using System.Net.Http;
using ConversionService.Core.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace ConversionAPI.Infrastructure.Services.Impl
{

    public class ConversionUnitService:IConversionUnitService
    {
        private readonly IConversionUnitsRepository _conversionUnitsRepository;
        private readonly IAuditRepository _auditRepository;
        private readonly IHttpContextAccessor _httpRequest;
        public ConversionUnitService(IConversionUnitsRepository conversionUnitsRepository,IAuditRepository auditRepository, IHttpContextAccessor httpRequest)
        {
            this._conversionUnitsRepository = conversionUnitsRepository;
            this._auditRepository = auditRepository;
            this._httpRequest = httpRequest;
        }

        public async Task<ApiCommonResponse> SaveConversionUnit(ConversionRequest conversionRequest)
        {

            var conversionInstance = ObjectMapper.conversionUnitRequestMapper(conversionRequest);
            var savedactivity = await _conversionUnitsRepository.SaveConversionUnit(conversionInstance);
            if (savedactivity == null)
            {
                return CommonResponse.Send(ResponseCodes.FAILURE, null, "Some system errors occurred");
            }
            _auditRepository.AuditTrail(_httpRequest.HttpContext.Request.Path.ToString(), JsonConvert.SerializeObject(conversionRequest), JsonConvert.SerializeObject(savedactivity));
            return CommonResponse.Send(ResponseCodes.SUCCESS, savedactivity, ResponseMessage.ConversionSuccessFullySavedMessage);
        }

        public async Task<ApiCommonResponse> GetAllConversionUnits()
        {
            var conversions = await _conversionUnitsRepository.FindAllConversionUnits();
            if (conversions == null)
            {
                return CommonResponse.Send(ResponseCodes.NO_DATA_AVAILABLE); ;
            }
            _auditRepository.AuditTrail(_httpRequest.HttpContext.Request.Path.ToString(), "", JsonConvert.SerializeObject(conversions));
            return CommonResponse.Send(ResponseCodes.SUCCESS, conversions, ResponseMessage.ConversionSuccessFullyFetchedMessage);
        }

        public async Task<ApiCommonResponse> GetConversionById(long id)
        {
            var conversionInstance = await _conversionUnitsRepository.FindConversionUnitById(id);
            if (conversionInstance == null)
            {
                return CommonResponse.Send(ResponseCodes.NO_DATA_AVAILABLE); ;
            }
            _auditRepository.AuditTrail(_httpRequest.HttpContext.Request.Path.ToString(), id.ToString(), JsonConvert.SerializeObject(conversionInstance));
            return CommonResponse.Send(ResponseCodes.SUCCESS, conversionInstance, ResponseMessage.ConversionSuccessFullyFetchedMessage);
        }

        public async Task<ApiCommonResponse> UpdateConversion(long id, ConversionRequest conversionRequest)
        {
            var conversionToUpdate = await _conversionUnitsRepository.FindConversionUnitById(id);
            if (conversionToUpdate == null)
            {
                return CommonResponse.Send(ResponseCodes.NO_DATA_AVAILABLE); ;
            }

            conversionToUpdate = ObjectMapper.conversionUnitUpdatedRequestMapper(conversionToUpdate, conversionRequest);
            
            var updatedConversion = await _conversionUnitsRepository.UpdateActivity(conversionToUpdate);

            if (updatedConversion == null)
            {
                return CommonResponse.Send(ResponseCodes.FAILURE, null, "Some system errors occurred");
            }
            _auditRepository.AuditTrail(_httpRequest.HttpContext.Request.Path.ToString(), JsonConvert.SerializeObject(conversionRequest), JsonConvert.SerializeObject(updatedConversion));
            return CommonResponse.Send(ResponseCodes.SUCCESS, updatedConversion, ResponseMessage.ConversionSuccessFullyUpdatedMessage);
        }



        public async Task<ApiCommonResponse> DeactivateConversionUnit(long id)
        {
            var converstionToDeactivate = await _conversionUnitsRepository.FindConversionUnitById(id);
            if (converstionToDeactivate == null)
            {
                return CommonResponse.Send(ResponseCodes.NO_DATA_AVAILABLE); ;
            }

            if (!await _conversionUnitsRepository.DeactivateConversionUnit(converstionToDeactivate))
            {
                return CommonResponse.Send(ResponseCodes.FAILURE, null, "Some system errors occurred");
            }
            _auditRepository.AuditTrail(_httpRequest.HttpContext.Request.Path.ToString(), id.ToString(), JsonConvert.SerializeObject(converstionToDeactivate));
            return CommonResponse.Send(ResponseCodes.SUCCESS, ResponseMessage.ConversionSuccessFullyUpdatedMessage);
        }



    }
}
