using ConversionService.Core.Entities;
using ConversionService.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionService.Core.Repository
{
    public interface IConversionActionRepository
    {
        Task<bool> DeactivateConversionAction(ConversionAction conversionAction);
        Task<IEnumerable<ConversionAction>> FindAllConversionAction();
        Task<ConversionAction> FindConversionActionById(long Id);
        Task<ConversionAction> SaveConversionAction(ConversionAction conversionAction);
       
    }
}
