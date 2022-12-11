using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionService.Core.Repository
{
    public interface IAuditRepository
    {
        Task AuditTrail(string api, string requestObject, string responseObject);
    }
}
