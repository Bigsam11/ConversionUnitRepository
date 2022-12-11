using ConversionService.Core.Entities;
using ConversionService.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionService.Core.Repository.Impl
{

    public class AuditRepository: IAuditRepository
    {
        private readonly DataContext _dataContext;
        public AuditRepository(DataContext context)
        {
            _dataContext = context;
        }
        public async Task AuditTrail(string api,string requestObject,string responseObject)
        {

            var audit = new Audit
            {
                API = api ?? "",
                RequestObject = requestObject ?? "" ,
                ResponseObject = responseObject ?? "",
                CreatedAt = DateTime.UtcNow

            };

            await _dataContext.Audit.AddAsync(audit);
            await _dataContext.SaveChangesAsync();
        }


    }
}
