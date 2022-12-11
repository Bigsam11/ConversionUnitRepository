using ConversionService.Core.Entities;
using ConversionService.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ConversionService.Core.Repository.Impl
{
    public class ConversionActionRepository : IConversionActionRepository
    {

        private readonly DataContext _dataContext;
        public ConversionActionRepository(DataContext context)
        {
            _dataContext = context;
        }

        public async Task<bool> DeactivateConversionAction(ConversionAction conversionAction)
        {
            conversionAction.IsActive = false;
            _dataContext.ConversionAction.Update(conversionAction);
            return await SaveChanges();
        }


        public async Task<IEnumerable<ConversionAction>> FindAllConversionAction()
        {
            return await _dataContext.ConversionAction
               .Where(unit => unit.IsActive == true)
               .OrderBy(unit => unit.CreatedAt)
               .ToListAsync();
        }

        public async Task<ConversionAction> FindConversionActionById(long Id)
        {

            var conversionAction = await _dataContext.ConversionAction
                .Where(unit => unit.IsActive == true && unit.Id == Id)
                .FirstOrDefaultAsync();

            if (conversionAction == null)
            {
                return null;
            }

            return conversionAction;

        }


        public async Task<ConversionAction> SaveConversionAction(ConversionAction conversionAction)
        {
            var savedConversionAction = await _dataContext.ConversionAction.AddAsync(conversionAction);
            if (await SaveChanges())
            {
                return savedConversionAction.Entity;
            }
            return null;
        }




        private async Task<bool> SaveChanges()
        {
            try
            {
                return await _dataContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
