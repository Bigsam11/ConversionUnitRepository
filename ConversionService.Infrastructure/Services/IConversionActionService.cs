using ConversionService.Core.Dtos.Request;
using ConversionService.Core.Dtos.Response;
using ConversionService.Core.Enums;
using ConversionService.Core.Helpers;
using ConversionService.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionService.Infrastructure.Services
{
    public interface IConversionActionService
    {
        Task<ApiCommonResponse> SaveConversionAction(ConversionActionRequest conversionRequest);
        Task<ApiCommonResponse> GetAllConversionAction();
        Task<ApiCommonResponse> GetConversionById(long id);
        Task<ApiCommonResponse> DeactivateConversionAction(long id);

    }
    
}
